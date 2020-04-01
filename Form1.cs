using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String HGK()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string response = wc.DownloadString("http://www.cbr.ru/scripts/XML_daily.asp");
            string Rate = System.Text.RegularExpressions.Regex.Match(response, @"Гонконгский доллар</Name><Value>([0-9]+.[0-9]+)</Value>").Groups[1].Value;
            return Rate;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Text = "1 RUB = " + HGK() + " HGK";
        }
    }
}
