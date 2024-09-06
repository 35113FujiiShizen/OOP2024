using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RssReader {

    public partial class Form1 : Form {
        List<RssItem> xitems;
        public Form1() {
            InitializeComponent();
            var rssDict = new Dictionary<string, string>() {
                {"https://news.yahoo.co.jp/rss/topics/top-picks.xml","主要"},
                {"https://news.yahoo.co.jp/rss/topics/domestic.xml","国内"},
                {"https://news.yahoo.co.jp/rss/topics/world.xml","国際"},
                {"https://news.yahoo.co.jp/rss/topics/business.xml","経済"},
                {"https://news.yahoo.co.jp/rss/topics/entertainment.xml","エンタメ" },
                {"https://news.yahoo.co.jp/rss/topics/sports.xml","スポーツ"},
                {"https://news.yahoo.co.jp/rss/topics/it.xml","IT"},
                {"https://news.yahoo.co.jp/rss/topics/science.xml","科学"},
                {"https://news.yahoo.co.jp/rss/topics/local.xml","地域"},
            };
            comboBox1.Items.AddRange(rssDict.Keys.ToArray());
            comboBox1.DataSource = new BindingSource(rssDict, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }


        private void tbGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(comboBox1.Text);
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
            if (lbRssTitle.SelectedItem != null) {
                var selectedTitle = lbRssTitle.SelectedItem.ToString();
                var selectedItem = xitems.FirstOrDefault(item => item.Title == selectedTitle);

                if (selectedItem != null) {
                    webView21.Source = new Uri(selectedItem.Link);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            
        }
    }
    //データ格納用クラス
    public class RssItem {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
