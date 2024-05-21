using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruta_de_grafos
{
    public partial class Form1 : Form
    {
        private Grafo grafo;

        public Form1()
        {
            InitializeComponent();
            grafo = new Grafo();
            InicializarGrafo();
            panelGrafo.Paint += new PaintEventHandler(this.panelGrafo_Paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void InicializarGrafo()
        {
            // Crear vértices
            Vertice santaAna = new Vertice("Santa Ana");
            Vertice sanSalvador = new Vertice("San Salvador");
            Vertice laLibertad = new Vertice("La Libertad");
            Vertice sanMiguel = new Vertice("San Miguel");
            Vertice usulutan = new Vertice("Usulután");

            // Agregar vértices al grafo
            grafo.AddVertice(santaAna);
            grafo.AddVertice(sanSalvador);
            grafo.AddVertice(laLibertad);
            grafo.AddVertice(sanMiguel);
            grafo.AddVertice(usulutan);

            // Crear aristas
            grafo.AddArista(santaAna, sanSalvador, 67);
            grafo.AddArista(sanSalvador, laLibertad, 20);
            grafo.AddArista(laLibertad, sanMiguel, 90);
            grafo.AddArista(sanMiguel, usulutan, 40);
            grafo.AddArista(usulutan, santaAna, 100);

            // Opcionalmente, puedes crear aristas en ambos sentidos
            grafo.AddArista(sanSalvador, santaAna, 67);
            grafo.AddArista(laLibertad, sanSalvador, 20);
            grafo.AddArista(sanMiguel, laLibertad, 90);
            grafo.AddArista(usulutan, sanMiguel, 40);
            grafo.AddArista(santaAna, usulutan, 100);
        }

        private void buttonAnchura_Click(object sender, EventArgs e)
        {
            string inicio = textBoxInicio.Text;
            var resultado = grafo.RecorridoAnchura(new Vertice(inicio));
            MostrarResultado(resultado);
        }

        private void buttonProfundidad_Click(object sender, EventArgs e)
        {
            string inicio = textBoxInicio.Text;
            var resultado = grafo.RecorridoProfundidad(new Vertice(inicio));
            MostrarResultado(resultado);
        }

        private void MostrarResultado(List<Vertice> resultado)
        {
            textBoxResultado.Clear();
            foreach (var vertice in resultado)
            {
                textBoxResultado.AppendText(vertice.Nombre + Environment.NewLine);
            }
        }

        private void panelGrafo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DibujarGrafo(g);
        }

        private void DibujarGrafo(Graphics g)
        {
            // Define posiciones fijas para los vértices para este ejemplo
            Dictionary<string, Point> posiciones = new Dictionary<string, Point>
            {
                { "Santa Ana", new Point(50, 50) },
                { "San Salvador", new Point(200, 50) },
                { "La Libertad", new Point(200, 150) },
                { "San Miguel", new Point(350, 150) },
                { "Usulután", new Point(350, 250) }
            };

            // Dibujar aristas
            foreach (var vertice in grafo.Vertices)
            {
                if (grafo.AdjacencyList.ContainsKey(vertice))
                {
                    foreach (var arista in grafo.AdjacencyList[vertice])
                    {
                        Point p1 = posiciones[vertice.Nombre];
                        Point p2 = posiciones[arista.Destino.Nombre];
                        g.DrawLine(Pens.Black, p1, p2);
                        // Opcional: Dibujar la distancia
                        Point midPoint = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                        g.DrawString(arista.Distancia.ToString(), this.Font, Brushes.Black, midPoint);
                    }
                }
            }

            // Dibujar vértices
            foreach (var kvp in posiciones)
            {
                Point p = kvp.Value;
                g.FillEllipse(Brushes.LightBlue, p.X - 10, p.Y - 10, 20, 20);
                g.DrawEllipse(Pens.Black, p.X - 10, p.Y - 10, 20, 20);
                g.DrawString(kvp.Key, this.Font, Brushes.Black, p.X + 10, p.Y + 10);
            }
        }
    }

    // Clases para el Grafo
    public class Vertice
    {
        public string Nombre { get; set; }

        public Vertice(string nombre)
        {
            Nombre = nombre;
        }

        public override bool Equals(object obj)
        {
            return obj is Vertice vertice && Nombre == vertice.Nombre;
        }

        public override int GetHashCode()
        {
            return Nombre.GetHashCode();
        }
    }

    public class Arista
    {
        public Vertice Origen { get; set; }
        public Vertice Destino { get; set; }
        public int Distancia { get; set; }

        public Arista(Vertice origen, Vertice destino, int distancia)
        {
            Origen = origen;
            Destino = destino;
            Distancia = distancia;
        }
    }

    public class Grafo
    {
        private Dictionary<Vertice, List<Arista>> adjList;

        public Grafo()
        {
            adjList = new Dictionary<Vertice, List<Arista>>();
        }

        public IEnumerable<Vertice> Vertices => adjList.Keys;

        public Dictionary<Vertice, List<Arista>> AdjacencyList => adjList;

        public void AddVertice(Vertice vertice)
        {
            if (!adjList.ContainsKey(vertice))
            {
                adjList[vertice] = new List<Arista>();
            }
        }

        public void AddArista(Vertice origen, Vertice destino, int distancia)
        {
            if (!adjList.ContainsKey(origen))
                AddVertice(origen);
            if (!adjList.ContainsKey(destino))
                AddVertice(destino);
            adjList[origen].Add(new Arista(origen, destino, distancia));
        }

        public List<Vertice> RecorridoAnchura(Vertice inicio)
        {
            List<Vertice> visitados = new List<Vertice>();
            Queue<Vertice> queue = new Queue<Vertice>();
            queue.Enqueue(inicio);

            while (queue.Count > 0)
            {
                Vertice actual = queue.Dequeue();
                if (!visitados.Contains(actual))
                {
                    visitados.Add(actual);
                    if (adjList.ContainsKey(actual))
                    {
                        foreach (Arista arista in adjList[actual])
                        {
                            queue.Enqueue(arista.Destino);
                        }
                    }
                }
            }
            return visitados;
        }

        public List<Vertice> RecorridoProfundidad(Vertice inicio)
        {
            List<Vertice> visitados = new List<Vertice>();
            Stack<Vertice> stack = new Stack<Vertice>();
            stack.Push(inicio);

            while (stack.Count > 0)
            {
                Vertice actual = stack.Pop();
                if (!visitados.Contains(actual))
                {
                    visitados.Add(actual);
                    if (adjList.ContainsKey(actual))
                    {
                        foreach (Arista arista in adjList[actual])
                        {
                            stack.Push(arista.Destino);
                        }
                    }
                }
            }
            return visitados;
        }
    }
}