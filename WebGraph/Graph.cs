using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rank
{
    class Graph<T>
    {
        public HashSet<Edge<T>> Edges { get; private set; }
        public HashSet<Vertex<T>> Vertices { get; private set; }

        public Graph()
        {
            Edges = new HashSet<Edge<T>>();
            Vertices = new HashSet<Vertex<T>>();
        }

        public void AddEdge(T from, T to)
        {
            if (from.Equals(to))
            {
                return;
            }

            var vertexFrom = new Vertex<T>(from);
            var vertexTo = new Vertex<T>(to);

            Vertices.Add(vertexFrom);
            Vertices.Add(vertexTo);

            Edges.Add(new Edge<T>(vertexFrom, vertexTo));
        }

        public int RoutesFrom(T from)
        {
            int result = 0;
            Edges.ToList().ForEach(edge =>
            {
                if (edge.From.Value.Equals(from))
                    result++;
            });
            return result;
        }

        public int RoutesTo(T to)
        {
            int result = 0;
            Edges.ToList().ForEach(edge =>
            {
                if (edge.To.Value.Equals(to))
                    result++;
            });
            return result;
        }

        public HashSet<T> LinksTo(T to)
        {
            HashSet<T> result = new HashSet<T>();
            Edges.ToList().ForEach(edge =>
            {
                if (edge.To.Value.Equals(to))
                    result.Add(edge.From.Value);
            });
            return result;
        }

        public bool ContainsInFrom(T value)
        {

            foreach (var item in Edges)
            {
                if (item.From.Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Edge<T>
    {
        public Vertex<T> From { get; private set; }
        public Vertex<T> To { get; private set; }

        public Edge(Vertex<T> from, Vertex<T> to)
        {
            this.From = from ?? throw new ArgumentNullException(nameof(from));
            this.To = to ?? throw new ArgumentNullException(nameof(to));
        }

        public override bool Equals(object obj)
        {
            var edge = obj as Edge<T>;
            return edge != null &&
                   EqualityComparer<Vertex<T>>.Default.Equals(From, edge.From) &&
                   EqualityComparer<Vertex<T>>.Default.Equals(To, edge.To);
        }

        public override int GetHashCode()
        {
            var hashCode = -1781160927;
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertex<T>>.Default.GetHashCode(From);
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertex<T>>.Default.GetHashCode(To);
            return hashCode;
        }
    }

    class Vertex<T>
    {
        public T Value { get; private set; }

        public Vertex(T value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            var vertex = obj as Vertex<T>;
            return vertex != null &&
                Value.Equals(Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
