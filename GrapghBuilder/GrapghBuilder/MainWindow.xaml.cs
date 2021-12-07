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
        private void ImageMouseDown(object sender, MouseButtonEventArgs e)
        {
            int i = 0;
            
            var pos = e.GetPosition((IInputElement)sender);
            TextBlock text = new TextBlock()
            {
                FontSize = 20,
                Foreground = Brushes.Black
            };
            
            //text.Name = i.ToString();
            Logic.GraphTopper top = new Logic.GraphTopper(i.ToString(), new List<Logic.GraphEdge>(), new Ellipse(){ Width = 50,
            Height = 50, Fill = Brushes.Gray, Name = "ellipse"});
            Canvas.SetLeft(top.El, pos.X - 17);
            Canvas.SetTop(top.El, pos.Y - 11);
            Canvas.SetLeft(text, pos.X );
            Canvas.SetTop(text, pos.Y);
            main.Children.Add(top.El);
            main.Children.Add(text);
            sdfsd(top);
            i++;
        }

        private void sdfsd(Logic.GraphTopper top)
        {
            GraphSchema.currentGraph.Add(top);
        }

        private void DeleteTopper(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                Ellipse activeEllipse = (Ellipse) e.OriginalSource;
                main.Children.Remove(activeEllipse);
            }
        }
    }
}
