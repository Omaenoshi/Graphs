using System;
using System.Collections.Generic;
using System.Linq;
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
            var pos = e.GetPosition((IInputElement)sender);

            Logic.GraphTopper top = new Logic.GraphTopper("1", new List<Logic.GraphEdge>(), new Ellipse(){ Width = 50,
            Height = 50, Fill = Brushes.Red});
            TextBlock text = new TextBlock()
            {
                Text = top.Name,
                FontSize = 20,
                Foreground = Brushes.White
            };
            Canvas.SetLeft(top.El, pos.X - 17);
            Canvas.SetTop(top.El, pos.Y - 11);
            Canvas.SetLeft(text, pos.X );
            Canvas.SetTop(text, pos.Y);
            main.Children.Add(top.El);
            main.Children.Add(text);
        }
    }
}
