using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    //データ格納用クラス
    public class RssItem {
        public string Title { get; set; }
        public string Link { get; set; }
    }
    public partial class Form1 : Form {
        List<RssItem> xitems;
        public Form1() {
            InitializeComponent();
        }

        private void tbGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbRssUrl.Text);
                var xdoc = XDocument.Load(url);
                //var xitems = xdoc.Root.Descendants("item");
                xitems = xdoc.Root.Descendants("item")
                                       .Select(item => new RssItem {
                                           Title = item.Element("title").Value,
                                           Link = item.Element("link").Value,
                                       }).ToList();
                foreach (var title in xitems) {
                    lbRssTitle.Items.Add(title.Title);
                }

            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            webView1.Navigate(xitems[lbRssTitle.SelectedIndex].Link);
        }
    }

}
