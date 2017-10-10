using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XPath_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        XmlDocument doc = new XmlDocument();

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "XML|* .xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please select a valid XML document", "Path Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please insert a XPath Expression", "Field Empty",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                else
            {
                richTextBox1.Clear();
                doc.Load(textBox1.Text);
                XmlNode root = doc.DocumentElement;
                try
                {
                    XmlNodeList nodeList = root.SelectNodes(textBox2.Text);
                    if (nodeList.Count == 0)
                    {
                        MessageBox.Show("Results not found", "Not Found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        foreach (XmlNode node in nodeList)
                        {
                            richTextBox1.AppendText(node.InnerText);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Opps, This XML Path is not Valid!", "Invalid XPath",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
