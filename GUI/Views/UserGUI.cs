using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Views
{
    public partial class UserGUI : UserControl
    {
        public UserGUI()
        {
            InitializeComponent();
        }

        List<string> lista = new List<string> { "Usuario", "Contraseña" };

        public void fillHeader(List<string> pheader)
        {
            foreach (string s in pheader)
            {
                Label label = new Label
                {
                    Text = s,
                    AutoSize = true,
                };
                pHeader.Controls.Add(label);

            }
 
        }

    }
}
