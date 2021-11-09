using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Rank
{

    class PageRankResult
    {
        public List<PageRankRecord> Records { get; private set; }
        public Graph<int> PageNumbersGraph { get; private set; }

        public PageRankResult(List<PageRankRecord> records, Graph<int> pageNumbersGraph)
        {
            Records = records ?? throw new ArgumentNullException(nameof(records));
            PageNumbersGraph = pageNumbersGraph ?? throw new ArgumentNullException(nameof(pageNumbersGraph));
        }
    }

    class PageRankRecord
    {
        public int Number { get; private set; }
        public double PageRank { get; private set; }
        public string url { get; private set; }
        public int LinksToHere { get; private set; }
        public int LinksFromoHere { get; private set; }

        public PageRankRecord(int number, double pageRank, string url, int linksToHere, int linksFromoHere)
        {
            this.Number = number;
            this.PageRank = pageRank;
            this.url = url;
            this.LinksToHere = linksToHere;
            this.LinksFromoHere = linksFromoHere;
        }
    }

    class PageRank
    {
        private static Action<int, int, int, string, long, double> onProgressChangeCallback;
        private static Action<PageRankResult> onCalculationCompletedCallback;

        public static void Calc(string url)
        {
            new Thread(() =>
            {
                Graph<string> pagesGraph = GetAllInnerLinks(url);
                Dictionary<string, double> pageRanks = PageRank.CalcPageRanks(pagesGraph);
                Dictionary<string, double> sortedPageRanks = pageRanks.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Dictionary<string, int> pageRankNumbers = new Dictionary<string, int>();
                int counter = 1;
                sortedPageRanks.Keys.ToList().ForEach(key =>
                {
                    pageRankNumbers.Add(key, counter++);
                });

                Graph<int> pageNumbersGraph = new Graph<int>();
                pagesGraph.Edges.ToList().ForEach(edge =>
                {
                    int from = pageRankNumbers[edge.From.Value];
                    int to = pageRankNumbers[edge.To.Value];
                    pageNumbersGraph.AddEdge(from, to);
                });

                List<PageRankRecord> records = new List<PageRankRecord>();
                sortedPageRanks.Keys.ToList().ForEach(key =>
                {
                    records.Add(new PageRankRecord(

                        pageRankNumbers[key],
                        pageRanks[key],
                        key,
                        pagesGraph.RoutesTo(key),
                        pagesGraph.RoutesFrom(key)));
                });

                onCalculationCompletedCallback?.Invoke(new PageRankResult(records, pageNumbersGraph));

            }).Start();
        }

        public static void OnProgressChanged(Action<int, int, int, string, long, double> callback)
        {
            onProgressChangeCallback = callback;
        }

        public static void OnCalculationCompleted(Action<PageRankResult> callback)
        {
            onCalculationCompletedCallback = callback;
        }

        private static Dictionary<string, double> CalcPageRanks(Graph<string> pagesGraph)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            pagesGraph.Vertices.ToList().ForEach(vertex => result.Add(vertex.Value, 1.0));

            for (int i = 0; i < 100; i++)
            {
                result = Iterate(result, pagesGraph);
            }

            return result;
        }

        private static Dictionary<string, double> Iterate(Dictionary<string, double> source, Graph<string> pagesGraph)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            source.Keys.ToList().ForEach(key => result.Add(key, source[key]));

            double d = 0.5;
            result.Keys.ToList().ForEach(key =>
            {
                double newValue = 0;
                pagesGraph.LinksTo(key).ToList().ForEach(keyLinksTo =>
                {
                    newValue += 1.0 * source[keyLinksTo] / pagesGraph.RoutesFrom(keyLinksTo);
                });

                result[key] = (1 - d) + d * newValue;
            });

            return result;
        }

        private static double averagePing = 0;
        private static Graph<string> GetAllInnerLinks(string url)
        {
            Graph<string> result = new Graph<string>();

            HashSet<string> urlsToAnalyzeQueue = new HashSet<string>();
            HashSet<string> visitedUrls = new HashSet<string>();
            string baseUrl = ExtractBaseUrl(url);
            urlsToAnalyzeQueue.Add(RemoveLastSlash(url));

            while (urlsToAnalyzeQueue.Count > 0)
            {
                string analyzingUrl = urlsToAnalyzeQueue.First();
                urlsToAnalyzeQueue.Remove(analyzingUrl);
                visitedUrls.Add(analyzingUrl);

                analyzingUrl = RemoveLastSlash(analyzingUrl);

                if (analyzingUrl.Contains('#'))
                {
                    continue;
                }

                if (analyzingUrl.Contains('#'))
                {
                    Console.WriteLine(analyzingUrl);
                }


                HtmlWeb hw = new HtmlWeb();
                HtmlDocument doc;
                HtmlNodeCollection selectedNodes;
                Stopwatch stopwatch = new Stopwatch();
                try
                {
                    stopwatch.Start();
                    doc = hw.Load(analyzingUrl);
                    TimeSpan pingTimeSpan = stopwatch.Elapsed;
                    stopwatch.Stop();
                    selectedNodes = doc.DocumentNode.SelectNodes("//a[@href]");
                }
                catch (Exception ex)
                {
                    continue;
                }
                if (selectedNodes == null)
                {
                    continue;
                }

                foreach (HtmlNode link in selectedNodes)
                {
                    string attributeValue = link.GetAttributeValue("href", "");
                    string linkItem = RemoveLastSlash(GetAbsoluteUrlString(baseUrl, attributeValue));
                    if (baseUrl.Equals(ExtractBaseUrl(linkItem)))
                    {
                        if (linkItem.Contains('#'))
                        {
                            continue;
                        }
                        result.AddEdge(analyzingUrl, linkItem);
                        if (!visitedUrls.Contains(linkItem))
                        {
                            urlsToAnalyzeQueue.Add(linkItem);
                        }
                    }
                }

                long ping = stopwatch.ElapsedMilliseconds;
                averagePing = (averagePing * (visitedUrls.Count - 1) + ping) / visitedUrls.Count;

                onProgressChangeCallback?.Invoke(result.Vertices.Count, result.Edges.Count, urlsToAnalyzeQueue.Count, analyzingUrl, ping, averagePing);
            }
            return result;
        }

        private static string ExtractBaseUrl(string url)
        {
            try
            {
                return new Uri(url).GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string RemoveLastSlash(string text)
        {
            if (text.Length == 0 || text[text.Length - 1] != '/')
            {
                return text;
            }
            else
            {
                return text.Substring(0, text.Length - 1);
            }
        }

        private static string GetAbsoluteUrlString(string baseUrl, string url)
        {
            try
            {
                var uri = new Uri(url, UriKind.RelativeOrAbsolute);
                if (!uri.IsAbsoluteUri)
                    uri = new Uri(new Uri(baseUrl), uri);
                return uri.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
