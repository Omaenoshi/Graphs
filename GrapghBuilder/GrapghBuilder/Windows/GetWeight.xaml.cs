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
using System.Windows.Shapes;

namespace GrapghBuilder.Windows
{
    public partial class GetWeight : Window
    {
        public GetWeight(Canvas canvas)
        {
            InitializeComponent();
            myCanvas = canvas;
        }
        public bool IsClosed { get; private set; }
        public int Weight { get; private set; }
        public string NAMEE { get; set; }
        private Canvas myCanvas;
        private void get(object sender, RoutedEventArgs e)
        {
            Weight = int.Parse(tbWeight.Text);

            MainWindow main1 = new MainWindow();
            MainWindow.stGr.Edges.Add(new Logic.GraphEdge(Weight, main1.FindTops(NAMEE)));

            myCanvas.Children.Add(MainWindow.ln);
            main1.IsClicked = false;
            this.Close();
        }
    }
}
