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
        public GetWeight(Canvas canvas, string crName)
        {
            InitializeComponent();
            myCanvas = canvas;
            CrName = crName;
        }
        public string CrName { get; private set; }
        public bool IsClosed { get; private set; }
        public int Weight { get; private set; }
        public static string NAMEE { get; set; }

        private Canvas myCanvas;
        public Logic.GraphEdge curEdge { get; set; } = new Logic.GraphEdge(0, null);
        private void get(object sender, RoutedEventArgs e)
        {
            Weight = int.Parse(tbWeight.Text);

            MainWindow main1 = new MainWindow();
            MainWindow.stGr.Edges.Add(new Logic.GraphEdge(Weight, MainWindow.FindTops(CrName)));
            //curEdge = new Logic.GraphEdge(Weight, MainWindow.FindTops(CrName));
            MainWindow.FindTops(CrName).Edges.Add(new Logic.GraphEdge(Weight, MainWindow.stGr));

            myCanvas.Children.Add(MainWindow.ln);
            main1.IsClicked = false;
            this.Close();
        }
    }
}
