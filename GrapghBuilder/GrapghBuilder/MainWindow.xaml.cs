using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GrapghBuilder.Logic;

namespace GrapghBuilder
{
    /*обхода взвешенного графа в ширину и глубину*/
    public partial class MainWindow : Window
    {
        private static GraphSchema schema = new GraphSchema();
        public MainWindow()
        {
            InitializeComponent();
            // schema.GraphParse("../../Temporary/Input.txt");
            // var topper = Algorithms.DFS(schema, schema.Toppers[0]);
        }
        int i = 0;
        public static GraphTopper stGr { get; set; } = new GraphTopper(null, null, null);
        private void CreateTop(object sender, MouseButtonEventArgs e)
        {
            var curPoint = Mouse.GetPosition(main);
            GraphTopper newTop = new GraphTopper($"_{i}", new List<GraphEdge>(),
            new Views.TopElem(new Border()
            {
                Name = $"_{i}",
                Width = 50,
                Height = 50,
                CornerRadius = new CornerRadius(90),
                Background = Brushes.Gray
            },
            new TextBlock()
            {
                Name = $"_{i}",
                Text = i.ToString(),
                Foreground = Brushes.White,
                FontSize = 14,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            }));
            Canvas.SetLeft(newTop.El.bTop, curPoint.X - 17);
            Canvas.SetTop(newTop.El.bTop, curPoint.Y - 11);
            Canvas.SetLeft(newTop.El.tTop, curPoint.X + 1);
            Canvas.SetTop(newTop.El.tTop, curPoint.Y );
            newTop.El.bTop.Child = newTop.El.tTop;
            main.Children.Add(newTop.El.bTop);
            i++;
            schema.Toppers.Add(newTop);
        }

        private void DeleteTop(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Border)
            {
                Border activeBd = (Border)e.OriginalSource;
                main.Children.Remove(activeBd);
                schema.Toppers.Remove(FindTops(activeBd.Name));
            }
            else
            {
                TextBlock activeBd = (TextBlock)e.OriginalSource;
                main.Children.Remove((Border)activeBd.Parent);
                schema.Toppers.Remove(FindTops(((Border)activeBd.Parent).Name));
            }
        }

        public static Line ln;
        public bool IsClicked { get; set; }

        
        private void CreateEdge(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Border)
            {
                Border actbd = (Border)e.OriginalSource;
                ln = new Line() { Name = $"_{i}", StrokeThickness = 5, Stroke = Brushes.Black };
                stGr = FindTops(actbd.Name);
                ln.X1 = Mouse.GetPosition(main).X;
                ln.Y1 = Mouse.GetPosition(main).Y;
                IsClicked = true;
            }
            if(e.OriginalSource is Canvas)
            {
                CreateTop(sender, e);
            }
            
        }

        
        private void EndEdge(object sender, MouseButtonEventArgs e)
        {
            if (IsClicked)
            {
                if (e.OriginalSource is Border)
                {
                    Border actbd = (Border)e.OriginalSource;

                    ln.X2 = Mouse.GetPosition(main).X;
                    ln.Y2 = Mouse.GetPosition(main).Y;
                    Windows.GetWeight gw = new Windows.GetWeight(main, actbd.Name);
                    gw.Show();
                   // Windows.GetWeight.NAMEE = actbd.Name;
                    //FindTops(actbd.Name).Edges.Add(gw.curEdge);
                    // stGr.Edges.Add(new GraphEdge(0, FindTops(actbd.Name)));
                    //
                    // main.Children.Add(ln);
                    // IsClicked = false;
                }
            }
        }
        public static GraphTopper FindTops(string name)
        {
            GraphTopper top = new GraphTopper(null, null, null);
            foreach (var c in schema.Toppers)
            {
                if (c.Name == name)
                {
                    top = c;
                    return top;
                }
            }
            return top;
        }

        public Border FindBd(string name)
        {
            Border curBd = new Border();
            foreach (var cur in main.Children.OfType<Border>())
            {
                if (name == cur.Name)
                    curBd = cur;
            }

            return curBd;
        }
        private void dfs(object sender, RoutedEventArgs e)
        {
            Algorithms.DFS(schema, schema.Toppers[0], FindBd(schema.Toppers[0].Name));
        }
    }
}
