using HtmlAgilityPack;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Rank
{
    public partial class Form1 : Form
    {
        private Microsoft.Msagl.Drawing.Graph graphComponent;
        private Microsoft.Msagl.GraphViewerGdi.GViewer viewerGraphComponent;

        public Form1()
        {
            InitializeComponent();

            PageRank.OnCalculationCompleted(pageRankResult =>
            {

                Invoke((MethodInvoker)delegate
                {
                    if (pageRankResult.Records.Count <= 200)
                        try
                        {
                            RenderGraph(pageRankResult.PageNumbersGraph);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Graph render failed!\n" + ex.Message, "Error");
                        }


                    double averagePageRank = 0;
                    int counter = 0;
                    richTextBox1.Clear();
                    int count = 1;
                    string newLine = Environment.NewLine;
                    pageRankResult.Records
                    .ForEach(record =>
                    {
                        if (count < 11)
                        {
                            richTextBox1.Text += count + ". " + record.url;
                            richTextBox1.Text += " : " + record.PageRank + newLine;
                            if (record.LinksFromoHere > 0)
                            {
                                averagePageRank += record.PageRank;
                                counter++;
                            }
                        }
                        count++;
                        
                        /***************POSSIBLE INFO
                                record.Number
                                record.PageRank
                                record.url
                                record.LinksToHere
                                record.LinksFromoHere
                        ******************************/
                    });
                    panelGraph.Visible = true;
                    richTextBox1.Visible = true;
                    averagePageRank /= 1.0 * counter;
                    labelAveragePageRank.Text = averagePageRank.ToString();
                });
            });

            PageRank.OnProgressChanged((int pagesFound, int linksFound, int pagesLeft, string currentUrl, long ping, double averagePing) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    labelPagesFound.Text = pagesFound.ToString();
                    labelLinksFound.Text = linksFound.ToString();
                    labelPagesLeft.Text = pagesLeft.ToString();
                    labelCurrentUrl.Text = currentUrl;
                });
            });
        }

        private void RenderGraph(Graph<int> graph)
        {
            new Thread(() =>
            {
                graphComponent = new Microsoft.Msagl.Drawing.Graph("graph");
                graph.Edges.ToList().ForEach(edge => graphComponent.AddEdge(edge.From.Value.ToString(), edge.To.Value.ToString()));
                graphComponent.Nodes.ToList().ForEach(node => node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle);
                Invoke((MethodInvoker)delegate
                {
                    viewerGraphComponent.Graph = graphComponent;
                });
            }).Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewerGraphComponent = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewerGraphComponent.ToolBarIsVisible = false;
            viewerGraphComponent.AutoScroll = true;
            viewerGraphComponent.Click += GraphNode_Click;
            graphComponent = new Microsoft.Msagl.Drawing.Graph("graph");
            viewerGraphComponent.Graph = graphComponent;
            viewerGraphComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            panelGraph.Controls.Add(viewerGraphComponent);
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            panelGraph.Visible = false;
            PageRank.Calc(textBoxStartUrl.Text);
        }

        private void GraphNode_Click(object sender, EventArgs e)
        {
            GViewer viewer = sender as GViewer;
            if (viewer.SelectedObject is Microsoft.Msagl.Drawing.Node)
            {
                Microsoft.Msagl.Drawing.Node node = viewer.SelectedObject as Microsoft.Msagl.Drawing.Node;
                int clickedNode = int.Parse(node.LabelText.Split('"')[0]);              
            }
        }

        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
