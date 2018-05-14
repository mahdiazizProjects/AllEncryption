using System;
using encryptionfiles;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;
using System.Diagnostics;

namespace Steganography_with_Cycling_Chaos
{
    public partial class Form1 : Form
    {
        //long offset = 0x10000000; // 256 megabytes 
        //long length = 0x20000000; // 512 megabytes 
        MemoryMappedViewAccessor accessor;
        encryption enc;
        byte[] bytes;
        string filename;
        string filepath;
        string filesave1;
        BinaryReader br;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filepath == null)
                return;
            //string[] temp = filepath.Split('.');
            //string outputfile = temp[0];
            //BinaryWriter bw = new BinaryWriter(File.Create(outputfile + "copy" + "." + temp[1],Convert.ToInt32(accessor.Capacity)), Encoding.Default);
            Stopwatch myWatch;
            encryption enc=new encryption();
            char[]cc=Pass.Text.ToCharArray();
            if (cc.Length < 3)
                return;
            int I = Convert.ToInt32(I_text.Text);
            double lamda1 = -1;
            double lamda2 = -1;
            double lamda3 = -1;
            double Gamma = -1;
            double M = -1;
            int size_block=Convert.ToInt32(blocks.Text);
            //int num_blocks = (Convert.ToInt32(bytes.Length) / size_block) ;
            bool is_decryption = dec.Checked;
            /////////////////
            myWatch = new Stopwatch();
            myWatch.Start();
            if (cc.Length >= 0)
            {
                double Xzero = enc.key_maker(-1.5, 3, cc[0]);
                double Yzero = enc.key_maker(-1.5, 3, cc[1]);
                double Zzero = enc.key_maker(-1.5, 3, cc[2]);
                if (cc.Length > 3)
                {
                    lamda1 = enc.key_maker(2.7, 0.3, cc[3]);
                    if (cc.Length > 4)
                    {
                        lamda2 = enc.key_maker(2.7, 0.3, cc[4]);
                        if (cc.Length > 5)
                        {
                            lamda3 = enc.key_maker(2.7, 0.3, cc[5]);
                            if (cc.Length > 6)
                            {
                                Gamma = enc.key_maker(2.9, 0.2, cc[6]);
                                if (cc.Length > 7)
                                {
                                    M = enc.key_maker(.2, 0.1, cc[7]);
                                }
                                else
                                {
                                    M = 0.25;
                                }
                            }
                            else
                            {
                                Gamma = 3.05; M = 0.25;
                            }
                        }
                        else
                        {
                            lamda3 = 2.87; Gamma = 3.05; M = 0.25;
                        }
                    }
                    else
                    {
                        lamda2 = 3.01; lamda3 = 2.87; Gamma = 3.05; M = 0.25;
                    }
                }
                else
                {
                    lamda1 = 2.98; lamda2 = 3.01; lamda3 = 2.87; Gamma = 3.05; M = 0.25;
                }
                elapsed_time.Text = myWatch.Elapsed.ToString();

                string[] temp = filepath.Split('.');
                string outputfile = temp[0];

                enc = new encryption(lamda1, lamda2, lamda3, Xzero, Yzero, Zzero, Gamma, M, I);
                enc.stegno( size_block, dec.Checked,br,temp);
                myWatch.Stop();
                //for (int ii = 0; ii < result.Length; ii++)
                //{
                //    bw.Write(result[ii]);
                //}
                //bw.Close();
                
            }
            else
            {
                MessageBox.Show("طول کلید حداقل باید سه حرف باشد");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                br = new BinaryReader(File.Open(filepath, FileMode.Open), Encoding.ASCII);
                //bytes = br.ReadBytes(100000);
                //br.Close();
                //br.Dispose();
                //using (var mmf = MemoryMappedFile.CreateFromFile(filepath, FileMode.Open, "ImgA"))
                //{
                //    // Create a random access view, from the 256th megabyte (the offset) 
                //    // to the 768th megabyte (the offset plus length). 
                //    accessor = mmf.CreateViewAccessor();
                //    //int colorSize = Marshal.SizeOf(typeof(MyColor));
                //    //MyColor color;

                //    //// Make changes to the view. 
                //    //for (long i = 0; i < length; i += colorSize)
                //    //{
                //    //    accessor.Read(i, out color);
                //    //    color.Brighten(10);
                //    //    accessor.Write(i, ref color);
                //    //}
                //}
            }

        }

  
    }
}
