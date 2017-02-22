using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace XMLParser
{
    public partial class Form1 : Form
    {
        public string fileName;
        private XmlDocument doc;
        private XmlElement root;

        public Form1()
        {
            InitializeComponent();
            //this.button1.Click += new System.EventHandler(this.button1_Click);
            //this.button2.Click += new System.EventHandler(this.button2_Click);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectWordFile();
        }

        private string SelectWordFile()
        {

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "XML Document|*.xml";
                dialog.InitialDirectory = Environment.CurrentDirectory;

                // Retore the directory before closing
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                    textBox1.Text = dialog.FileName;
                    rtbText.Text = dialog.FileName;
                    rtbText.Clear();
                }
            }



            return fileName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rtbText.Text = fileName;
            //string str;
            //doc = new XmlDocument();
            //doc.Load(fileName);
            //root = doc.DocumentElement;
            XDocument xDocument = XDocument.Load(fileName);
            XmlDocument doc = new XmlDocument();
            XmlDocument doc2 = new XmlDocument();
            doc.LoadXml(xDocument.ToString());

            //XmlTextReader reader = new XmlTextReader(fileName);
            try
            {
                StringBuilder sb = new StringBuilder();
                XmlNodeList xnList;
                XmlNode root = doc.DocumentElement;

                xnList = root.SelectNodes("descendant::group[@restype='x-cp-audio-item']");
                foreach (XmlNode node in xnList)
                {
                   
                    sb.AppendLine(node.InnerText);
                    sb.AppendLine();
                    
                }

                rtbText.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                rtbText.Text = "XML Failed to load" + fileName;
            }

        }

        private void rtbText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbText.Text);
        }
    }

} 
