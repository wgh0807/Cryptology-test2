using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace 密码学大作业2Test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string MD5(string encryptString)
        {
            byte[] result = Encoding.Default.GetBytes(encryptString);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string encryptResult = BitConverter.ToString(output).Replace("-", "");
            return encryptResult;
        }

        public static string SHA1(string content)
        {
            Encoding encode = Encoding.UTF8;
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] bytes_in = encode.GetBytes(content);
                byte[] bytes_out = sha1.ComputeHash(bytes_in);
                sha1.Dispose();
                string result = BitConverter.ToString(bytes_out);
                result = result.Replace("-", "");
                return result;
        }

        private void openFilleButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
            OpenFileDialog file1 = new OpenFileDialog();
            file1.Filter = "文本文件|*.txt";
            if (file1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = File.OpenText(file1.FileName);
                while (sr.EndOfStream != true)
                {
                    inputBox.Text += sr.ReadLine()+"\n";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int l = comboBox1.Text.Length;
            int i = comboBox1.Text.IndexOf("MD5");
            int j = comboBox1.Text.IndexOf("SHA1");
            if(i!=0 && j != 0 || (l!=3 && l!=4))
            {
                if (j != -1)
                {
                    comboBox1.Text = "SHA1";
                }
                else
                {
                    comboBox1.Text = "MD5";
                }
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string str = inputBox.Text;
            if (comboBox1.Text.Equals("SHA1"))
            {
                outputBox.Text = SHA1(str);
            }
            else
            {
                outputBox.Text = MD5(str);
            }
        }

       
        
    }
    
}
