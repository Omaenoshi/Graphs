using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GrapghBuilder.Views
{
    public class TopElem
    {
        public Border bTop { get; set; }
        public TextBlock tTop { get; set; }

        public TopElem(Border btop, TextBlock ttop)
        {
            bTop = btop;
            tTop = ttop;
        }
    }
}
