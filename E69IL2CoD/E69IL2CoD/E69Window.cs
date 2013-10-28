using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E69IL2CoD
{
    public partial class E69Window : Form
    {

        public E69Window()
        {
            InitializeComponent();
            this.configureLanguage();
        }

        private void configureLanguage()
        {
            ResourceManager recursos = new System.Resources.ResourceManager("E69IL2CoD.Properties.Resources", this.GetType().Assembly);
            CultureInfo cultura= new System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper());

            this.Text = recursos.GetString("mainWindow", cultura);
            this.groupBoxSpeed.Text = recursos.GetString("groupSpeed", cultura);
        }
    }
}
