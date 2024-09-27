using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RssReader {

    public partial class Form1 : Form {
        List<RssItem> xitems;
        Dictionary<string, string> rssDict;
        public Form1() {
            InitializeComponent();
            rssDict = new Dictionary<string, string>() {
                {"主要","https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
                {"国内","https://news.yahoo.co.jp/rss/topics/domestic.xml"},
                {"国際","https://news.yahoo.co.jp/rss/topics/world.xml"},
                {"経済","https://news.yahoo.co.jp/rss/topics/business.xml"},
                {"エンタメ","https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
                {"スポーツ","https://news.yahoo.co.jp/rss/topics/sports.xml"},
                {"IT","https://news.yahoo.co.jp/rss/topics/it.xml"},
                {"科学","https://news.yahoo.co.jp/rss/topics/science.xml"},
                {"地域","https://news.yahoo.co.jp/rss/topics/local.xml"},
            };
            comboBox1.Items.AddRange(rssDict.Keys.ToArray());
        }


        private void tbGet_Click(object sender, EventArgs e) {

            try {
                if (comboBox1.Text.Contains("http")) {
                    using (var wc = new WebClient()) {
                        var url = wc.OpenRead(comboBox1.Text);
                        var xdoc = XDocument.Load(url);
                        //var xitems = xdoc.Root.Descendants("item");
                        xitems = xdoc.Root.Descendants("item")
                                               .Select(item => new RssItem {
                                                   Title = item.Element("title").Value,
                                                   Link = item.Element("link").Value,
                                               }).ToList();
                        lbRssTitle.Items.Clear();
                        foreach (var title in xitems) {
                            lbRssTitle.Items.Add(title.Title);
                        }
                    }
                } else {
                    using (var wc = new WebClient()) {
                        var url = wc.OpenRead(rssDict[comboBox1.Text]);
                        var xdoc = XDocument.Load(url);
                        //var xitems = xdoc.Root.Descendants("item");
                        xitems = xdoc.Root.Descendants("item")
                                               .Select(item => new RssItem {
                                                   Title = item.Element("title").Value,
                                                   Link = item.Element("link").Value,
                                               }).ToList();
                        lbRssTitle.Items.Clear();
                        foreach (var title in xitems) {
                            lbRssTitle.Items.Add(title.Title);
                        }
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("正しい値を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

        }
        private void tbReg_Click(object sender, EventArgs e) {
            if (comboBox2.Text != "" && comboBox1.Text != "") {
                if (rssDict.Values.Contains("http"))
                {
                    comboBox1.Items.Add(comboBox2.Text);
                    rssDict.Add(comboBox2.Text, comboBox1.Text);
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                } else{

                };
                
            } else {
                MessageBox.Show("URLまたはお気に入り登録欄もしくはその両方が未入力です。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    //データ格納用クラス
    public class RssItem {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
