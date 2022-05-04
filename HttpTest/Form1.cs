using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpTest
{
    public partial class Form1 : Form
    {
        private static StringBuilder _address;

        public Form1()
        {
            

            List<SearchName> searchList = new List<SearchName>
            {
                new SearchName
                {
                    Name = "Google", 
                    Description = "https://www.google.ru/search?q="
                },

                new SearchName()
                {
                    Name = "Bing",
                    Description = "https://www.bing.com/search?q="
                }
            };
            InitializeComponent();
            btnLoad.Enabled = false;

            cbSearch.DataSource = searchList;
            cbSearch.DisplayMember = "Name";

            cbSearch.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lbHeaders.Items.Clear();
            edContent.Clear();

            if (string.IsNullOrWhiteSpace(edAddAddress.Text))
                return;
            #region WebClient
            //if (string.IsNullOrWhiteSpace(edAddAddress.Text))
            //    return;
            //WebClient web = new WebClient();
            //using (StreamReader stream = new StreamReader(web.OpenRead(edAddAddress.Text)))
            //{
            //    string line;
            //    while ((line = stream.ReadLine()) != null)
            //    {
            //        edContent.Text += line;
            //    }
            //}

            #endregion

            #region HttpRequest

            try
            {
                lbHeaders.Items.Clear();


                Uri uri = new Uri(_address.Append(edAddAddress.Text).ToString());

                lbHeaders.Items.Add($"Addres: {_address}");

                ServicePoint point = ServicePointManager.FindServicePoint(uri);

                if (point != null)
                {
                    lbHeaders.Items.Add($"Connection limit:" +
                                        $"{point.ConnectionLimit}");
                    lbHeaders.Items.Add($"Connection name:" +
                                        $"{point.ConnectionName}");
                }
                

                // сформировали запрос, но не отправили
                //HttpWebRequest request = WebRequest.Create(edAddAddress.Text)
                //    as HttpWebRequest;
                HttpWebRequest request = WebRequest.Create(uri)
                    as HttpWebRequest;
                
                request.CookieContainer = new CookieContainer();

                // получаем ответ 
                HttpWebResponse response = request.GetResponse()
                    as HttpWebResponse;

                // отображаем каждій заголовок
                foreach (string header in response.Headers)
                {
                    lbHeaders.Items.Add($"{header}: " +
                                        $"{response.Headers[header]}");
                }

                using (StreamReader reader = new StreamReader(
                           response.GetResponseStream()))
                {
                    edContent.Text = reader.ReadToEnd();
                }

                lbHeaders.Items.Add("Cookies: ");
                foreach (Cookie cookie in response.Cookies)
                {
                    lbHeaders.Items.Add(cookie);
                }

                //lbHeade
            }
            catch (Exception exception) 
            {
                edContent.Clear();
                edContent.Text = exception.Message;
            }
            

            #endregion
        }

        private void edAddAddress_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchName searchName = cbSearch.SelectedItem as SearchName;
            
            if (searchName == null)
                _address = new StringBuilder("https://www.google.ru/search?q=");
            else
                _address = new StringBuilder(searchName.Description);
            searchName = null;

            btnLoad.Enabled = true;
        }
    }
}
