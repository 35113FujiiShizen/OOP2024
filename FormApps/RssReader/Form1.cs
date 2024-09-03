using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RssReader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void tbGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbRssUrl.Text);
                var xdoc = XDocument.Load(url);
                //var xitems = xdoc.Root.Descendants("item");
                var xtitles = xdoc.Root.Descendants("item")
                                       .Select(item => new {
                                          title = item.Element("title").Value,
                                          link = item.Element("link").Value,
                                       });
                foreach (var title in xtitles){
                    lbRssTitle.Items.Add(title.title);
                }

            }
        }
    }
}
