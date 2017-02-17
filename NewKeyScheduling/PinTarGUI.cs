using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewKeyScheduling
{
    public partial class PinTarGUI : Form
    {
       // PinTar pinTar1, pinTar2;
        public PinTarGUI()
        {
            InitializeComponent();
        }

        private void btKeyStream_Click(object sender, EventArgs e)
        {
            PinTar pinTar1 = new PinTar();
            if (rtPlainText.Text == "")
            {
                MessageBox.Show("Please enter the secret key");
            }

            if (cbNumber.SelectedItem.ToString() == null)
            {
                MessageBox.Show("Please Select the Keystream size");
            }
            else
            {
                pinTar1.init(Encoding.ASCII.GetBytes(rtPlainText.Text));
                int size = Convert.ToInt16(cbNumber.SelectedItem.ToString());
                byte[] resultKey = pinTar1.KeyedHashFunction(size);
                string returnedKey = pinTar1.ByteArrayToString(resultKey);

                rtoutputKey.Text = returnedKey;
            }
        }

        private void PinTarGUI_Load(object sender, EventArgs e)
        {
            cbNumber.SelectedIndex = 0;
        }

        private void btcompareMessage_Click(object sender, EventArgs e)
        {
            try
            {
                //PinTar pinTar2 = new PinTar();
                //pinTar2.init(Encoding.ASCII.GetBytes(RTauthenticationMessage.Text));
                string digest = rthashDigest.Text;
                //int size = ((Encoding.ASCII.GetBytes(digest)).Length)*4;
               
                //byte[] hashDigest = pinTar2.KeyedHashFunction(size);
               
                //string returnedhashDigest = pinTar2.ByteArrayToString(hashDigest);
               
                //if (digest.Equals(returnedhashDigest))
                //{
                //    MessageBox.Show("Matched :)");
                //}
                //else
                //{
                //    MessageBox.Show("sorry :(");
                //}
                Statistics stats = new Statistics();
               double val = stats.Correlation(RTauthenticationMessage.Text, Encoding.ASCII.GetBytes(digest));
               MessageBox.Show(val.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
