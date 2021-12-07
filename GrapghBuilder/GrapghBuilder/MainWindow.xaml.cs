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
        private void CreateTop(object sender, MouseButtonEventArgs e)
        {
            var curPoint = Mouse.GetPosition(main);
            GraphTopper newTop = new GraphTopper(" ", new List<GraphEdge>(),
            new Views.TopElem(new Border() {Width = 50, Height = 50, CornerRadius = new CornerRadius(90), Background = Brushes.Gray }, 
            new TextBlock() { Text = i.ToString(), Foreground = Brushes.White, FontSize = 14, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center}));
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
            if(e.OriginalSource is Border)
            {
                Border activeBd = (Border)e.OriginalSource;
                main.Children.Remove(activeBd);
            }
            else
            {
                TextBlock activeBd = (TextBlock)e.OriginalSource;
                main.Children.Remove((Border)activeBd.Parent);
            }
        }
        static Line ln = new Line() { StrokeThickness = 5, Stroke = Brushes.Black};

        private void CreateEdge(object sender, MouseButtonEventArgs e)
        {
            ln.X1 = Mouse.GetPosition(main).X;
            ln.Y1 = Mouse.GetPosition(main).Y;
            
        }

        private void EndEdge(object sender, MouseButtonEventArgs e)
        {
            ln.X2 = Mouse.GetPosition(main).X;
            ln.Y2 = Mouse.GetPosition(main).Y;

            main.Children.Add(ln);
        }
    }
}
