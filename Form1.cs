using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Encrypter/Decrypter";
        }


        

        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        string lLlLlL = "pvp@xdiscordb0t";
        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //var str = textBox1.Text;
            //var encryptedString = EncryptString(str,str);

            //textBox2.Text = $"encrypted string = {encryptedString}";

                       var nullorempty = textBox1.Text;

            if (String.IsNullOrWhiteSpace(nullorempty))
            {

            }
            else
            {


                byte[] data = UTF8Encoding.UTF8.GetBytes(nullorempty);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(lLlLlL));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        textBox2.Text = Convert.ToBase64String(results, 0, results.Length);
                    }

                    textBox1.Text = "";
                    textBox3.Text = "";
                    button3.Text = "Copy";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (String.IsNullOrWhiteSpace(Convert.FromBase64String(textBox1.Text).ToString()))
            {

            }
            else
            {

                byte[] data = Convert.FromBase64String(textBox1.Text);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(lLlLlL));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        textBox3.Text = UTF8Encoding.UTF8.GetString(results);
                    }
                }
                textBox1.Text = "";
                textBox2.Text = "";
                button3.Text = "Copy";
            }
        }
    }
}

