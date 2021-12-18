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
        public MainWindow()
        {
            InitializeComponent();
        }
        int i = 0;
        static GraphTopper stGr = new GraphTopper(null, null, null);
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
            Logic.GraphSchema.currentGraph.Add(newTop);
        }

        private void DeleteTop(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Border)
            {
                Border activeBd = (Border)e.OriginalSource;
                main.Children.Remove(activeBd);
                GraphSchema.currentGraph.Remove(FindTops(activeBd.Name));
            }
            else
            {
                TextBlock activeBd = (TextBlock)e.OriginalSource;
                main.Children.Remove((Border)activeBd.Parent);
                GraphSchema.currentGraph.Remove(FindTops(((Border)activeBd.Parent).Name));
            }
        }

        Line ln;
        static bool IsClicked { get; set; }
        private void CreateEdge(object sender, MouseButtonEventArgs e)
        {
            ln = new Line() { StrokeThickness = 5, Stroke = Brushes.Black };
            if (e.OriginalSource is Border)
            {
                Border actbd = (Border)e.OriginalSource;
                stGr = FindTops(actbd.Name);
                ln.X1 = Mouse.GetPosition(main).X;
                ln.Y1 = Mouse.GetPosition(main).Y;
            }
            IsClicked = true;
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

                    stGr.Edges.Add(new GraphEdge(0, FindTops(actbd.Name)));

                    main.Children.Add(ln);
                    IsClicked = false;
                }
            }
        }
        private GraphTopper FindTops(string name)
        {
            GraphTopper top = new GraphTopper(null, null, null);
            foreach (var c in GraphSchema.currentGraph)
            {
                if (c.Name == name)
                {
                    top = c;
                    return top;
                }
            }
            return top;
        }
    }
}
