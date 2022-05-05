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

namespace WeatheFilmInfo
{
    public partial class Form1 : Form
    {
        private static double _dol;
        private static double _shyr;
        private static string _city;
        private static string _country;

        private static string _API =
            "b60b6379f292249a4741a3a7a5826d67";

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void ListDirectoryFTP()
        //{
        //    if (string.IsNullOrWhiteSpace(.Text))
        //    return;

        //    FtpWebRequest request = WebRequest.Create(edAddress.Text) as FtpWebRequest;
        //    request.Method = WebRequestMethods.Ftp.ListDirectory;
        //    request.UseBinary = false;

        //    FtpWebResponse response = request.GetResponse() as FtpWebResponse;
        //    lbResult.Items.Clear();
        //    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        //    {
        //        //string files = reader.ReadToEnd();
        //        //lbResult.Items.Add(files);
        //        string item;
        //        while ((item = reader.ReadLine()) != null)
        //        {
        //            lbResult.Items.Add(item);
        //        }
        //    }

        //    response.Close();
        //}

        //private void DownloadFileFtp()
        //{
        //    if (lbResult.SelectedIndex == ListBox.NoMatches)
        //        return;

        //    using (SaveFileDialog dlg = new SaveFileDialog())
        //    {
        //        dlg.InitialDirectory = @"c:\";
        //        dlg.FileName = lbResult.SelectedItem.ToString();
        //        if (dlg.ShowDialog() != DialogResult.OK)
        //            return;

        //        string path = edAddress.Text + "/" + lbResult.SelectedItem.ToString();

        //        FtpWebRequest request = WebRequest.Create(path) as FtpWebRequest;
        //        request.Method = WebRequestMethods.Ftp.DownloadFile;
        //        request.UseBinary = true;

        //        FtpWebResponse response = request.GetResponse() as FtpWebResponse;

        //        FileStream fs = new FileStream(dlg.FileName,
        //            FileMode.Create, FileAccess.Write);

        //        byte[] buff = new byte[1024];
        //        using (Stream reader = response.GetResponseStream())
        //        {
        //            int len;
        //            while ((len = reader.Read(buff, 0, buff.Length)) > 0)
        //            {
        //                fs.Write(buff, 0, len);
        //            }
        //        }

        //        response.Close();
        //        MessageBox.Show("Download complete!!!");
        //    }
        //}

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (edDol == null && edShyr == null
                              && edCity == null 
                              && edCountry == null)
                return;

            if (edCity == null && edCountry == null 
                               && edDol != null 
                               && edShyr !=null)
            {
                _dol = Int32.Parse(edDol.Text);
                _shyr = Int32.Parse(edShyr.Text);

                GetWeather();
            }
            else
            {
                if (edCity != null && edCountry != null)
                {
                    _city = edCity.Text;
                    _country = edCountry.Text;
                }
                else
                    return;

                GetCoordinats();
            }

        }
        private void GetWeather()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.InitialDirectory = @"E:\kod\NetworkProgramming\NetworkProgramming\WeatheFilmInfo\test";
                dlg.FileName = "Weather.json";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                string coordApi = "https://api.openweathermap.org/data/2.5/" +
                                        "//weather?lat={lat}&lon={lon}&appid={API key}";

                FtpWebRequest request = WebRequest.Create(coordApi) as FtpWebRequest;

                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.UseBinary = true;

                FtpWebResponse response = request.GetResponse() as FtpWebResponse;

                FileStream fs = new FileStream(dlg.FileName,
                    FileMode.Create, FileAccess.Write);

                byte[] buff = new byte[1024];
                using (Stream reader = response.GetResponseStream())
                {
                    int len;
                    while ((len = reader.Read(buff, 0, buff.Length)) > 0)
                    {
                        fs.Write(buff, 0, len);
                    }
                }

                response.Close();
                MessageBox.Show("Download complete!!!");
            }
        }
        private void GetCoordinats()
        {
            // может, это из-за этого? , я создаю файл 
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.InitialDirectory = @"E:\kod\NetworkProgramming\NetworkProgramming\WeatheFilmInfo\test";
                dlg.FileName = "Coord.json";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                string coordApi = $"http://api.openweathermap.org/geo/1.0/direct?q={_city}," +
                                  $"{_country}&limit={1}&appid={_API}";


                Uri uri = new Uri(coordApi);
                ServicePoint point = ServicePointManager.FindServicePoint(uri);


                HttpWebRequest request = WebRequest.Create(uri)
                    as HttpWebRequest;

                HttpWebResponse response = request.GetResponse()
                    as HttpWebResponse;

                FileStream fs = new FileStream(dlg.FileName,
                    FileMode.Create, FileAccess.Write);

                //FileInfo fileInfo = new FileInfo();

                StringBuilder content;

                using (StreamReader reader = new StreamReader(
                           response.GetResponseStream()))
                {
                    content = new StringBuilder(reader.ReadToEnd());


                    // у меня почему-то здесь в 204 строке использует 
                    // еще один потток я немного не понимаю почему 

                }

                string pathTest = @"E:\kod\NetworkProgramming\NetworkProgramming\WeatheFilmInfo\test\CoordTest.json";

                using (StreamWriter writer = new StreamWriter(pathTest))
                {
                    writer.WriteLine(content.ToString());
                }
                //fileInfo.CreateText().Write(content);


                response.Close();
                MessageBox.Show("Download complete!!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}