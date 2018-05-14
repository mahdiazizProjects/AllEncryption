using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Runtime.InteropServices;
namespace encryptionfiles
{
    class encryption
    {
        int Height;
        int Width;
        double[] domains;
        double l1, l2, l3, m, gamma;
        double domain;
        double xzero; double yzero; double zzero;
        int I;
        public encryption(double L1, double L2, double L3, double Xzero, double Yzero, double Zzero, double Gamma, double M,int I)
        {
            this.I = I;
            domains = new double[I];
            l1 = L1;
            l2 = L2;
            l3 = L3;
            m = M;
            gamma = Gamma;
            xzero = Xzero;
            yzero = Yzero;
            zzero = Zzero;
            domain = 4.0 / (I-1);

        }
        public encryption()
        {
            domains = new double[256];
        }
        public void stegno(int size_block, bool decryption, BinaryReader br, string[] tempstring)
        {
            int length = (int)br.BaseStream.Length;
            int num_blocks = length / size_block;
            BinaryWriter bw = new BinaryWriter(File.Create(tempstring[0] + "copy" + "." + tempstring[1], length), Encoding.ASCII);
            restrict();
            int index = 0;
            ///////////////////////////////////////////////////////////////Color///////////////
            double Xnegative1 = xzero;
            double Ynegative1 = yzero;
            double Znegative1 = zzero;
            double X = (l1 * Xnegative1) - (Math.Pow(Xnegative1, 3)) - (gamma * Math.Pow(Math.Abs(Ynegative1), m) * Xnegative1);
            double Y = (l2 * Ynegative1) - (Math.Pow(Ynegative1, 3)) - (gamma * Math.Pow(Math.Abs(Znegative1), m) * Ynegative1);
            double Z = (l3 * Znegative1) - (Math.Pow(Znegative1, 3)) - (gamma * Math.Pow(Math.Abs(Xnegative1), m) * Znegative1);
            double select = turning(X, Y, Z);
            Xnegative1 = X; Ynegative1 = Y; Znegative1 = Z;
            for (int iii = 0; iii < 100; iii++)
            {
                X = (l1 * Xnegative1) - (Math.Pow(Xnegative1, 3)) - (gamma * Math.Pow(Math.Abs(Ynegative1), m) * Xnegative1);
                Y = (l2 * Ynegative1) - (Math.Pow(Ynegative1, 3)) - (gamma * Math.Pow(Math.Abs(Znegative1), m) * Ynegative1);
                Z = (l3 * Znegative1) - (Math.Pow(Znegative1, 3)) - (gamma * Math.Pow(Math.Abs(Xnegative1), m) * Znegative1);
                select = turning(X, Y, Z);
                Xnegative1 = X; Ynegative1 = Y; Znegative1 = Z;
            }
            for (int ii = 0; ii < domains.Length - 1; ii++)
                if (domains[ii] <= select && domains[ii + 1] > select)
                {
                    index = ii;
                    break;
                }
            Random rr = new Random(index);
            int[] r1 = sq_rand_gen(num_blocks, rr);
            ///////////////////////////////////////////////////////////////Color///////////////
            X = (l1 * Xnegative1) - (Math.Pow(Xnegative1, 3)) - (gamma * Math.Pow(Math.Abs(Ynegative1), m) * Xnegative1);
            Y = (l2 * Ynegative1) - (Math.Pow(Ynegative1, 3)) - (gamma * Math.Pow(Math.Abs(Znegative1), m) * Ynegative1);
            Z = (l3 * Znegative1) - (Math.Pow(Znegative1, 3)) - (gamma * Math.Pow(Math.Abs(Xnegative1), m) * Znegative1);
            select = turning(X, Y, Z);
            Xnegative1 = X; Ynegative1 = Y; Znegative1 = Z;
            for (int ii = 0; ii < domains.Length - 1; ii++)
                if (domains[ii] <= select && domains[ii + 1] > select)
                {
                    index = ii;
                    break;
                }
            rr = new Random(index);
            // the last block is exactly copy to the that of the resultant file because of the reading problem
            int[] r2 = sq_rand_gen(num_blocks, rr);
            ////////////////////////////////////////////////////////////////////////////////////////
            for (int kk = 0; kk < r1.Length; kk++)
            {
                int dest_block_num = r1[kk];
                int source_block_num = r2[kk];
                if (!decryption)
                {
                    br.BaseStream.Seek(source_block_num * size_block, SeekOrigin.Begin);
                    bw.Seek(dest_block_num * size_block, SeekOrigin.Begin);
                }
                else
                {
                    br.BaseStream.Seek(dest_block_num * size_block, SeekOrigin.Begin);
                    bw.Seek(source_block_num * size_block, SeekOrigin.Begin);
                }
                for (int ll = 0; ll < size_block; ll++)
                {
                    int temp1 = rr.Next(255);
                    int temp2 = Convert.ToInt32(br.ReadByte());
                    int temp3 = temp2 ^ temp1;
                    byte temp = Convert.ToByte(temp3);
                    bw.Write(temp);
                }
            }
            // for the last block
            br.BaseStream.Seek(num_blocks * size_block, SeekOrigin.Begin);
            bw.Seek(num_blocks * size_block, SeekOrigin.Begin);
            int remainning = length-num_blocks * size_block;
            for (int ii = 0; ii < remainning; ii++)
            {
                int temp1 = rr.Next(255);
                int temp2 = Convert.ToInt32(br.ReadByte());
                int temp3 = temp2 ^ temp1;
                byte temp = Convert.ToByte(temp3);
                bw.Write(temp);
            }
            bw.Flush();
            bw.Close();
            bw.Dispose();
            br.Close();
            br.Dispose();
        }
        //public void stegno(MemoryMappedViewAccessor accessor, int num_blocks, int size_block, bool decryption,BinaryWriter bw)
        //{
        //    //byte[] result = new byte[image.Length];
        //    restrict();
        //    int index = 0;
        //    ///////////////////////////////////////////////////////////////Color///////////////
        //    double Xnegative1 = xzero;
        //    double Ynegative1 = yzero;
        //    double Znegative1 = zzero;
        //    double X = (l1 * Xnegative1) - (Math.Pow(Xnegative1, 3)) - (gamma * Math.Pow(Math.Abs(Ynegative1), m) * Xnegative1);
        //    double Y = (l2 * Ynegative1) - (Math.Pow(Ynegative1, 3)) - (gamma * Math.Pow(Math.Abs(Znegative1), m) * Ynegative1);
        //    double Z = (l3 * Znegative1) - (Math.Pow(Znegative1, 3)) - (gamma * Math.Pow(Math.Abs(Xnegative1), m) * Znegative1);
        //    double select = turning(X, Y, Z);
        //    Xnegative1 = X; Ynegative1 = Y; Znegative1 = Z;
        //    for (int iii = 0; iii < 100; iii++)
        //    {
        //        X = (l1 * Xnegative1) - (Math.Pow(Xnegative1, 3)) - (gamma * Math.Pow(Math.Abs(Ynegative1), m) * Xnegative1);
        //        Y = (l2 * Ynegative1) - (Math.Pow(Ynegative1, 3)) - (gamma * Math.Pow(Math.Abs(Znegative1), m) * Ynegative1);
        //        Z = (l3 * Znegative1) - (Math.Pow(Znegative1, 3)) - (gamma * Math.Pow(Math.Abs(Xnegative1), m) * Znegative1);
        //        select = turning(X, Y, Z);
        //        Xnegative1 = X; Ynegative1 = Y; Znegative1 = Z;
        //    }
        //    for (int ii = 0; ii < domains.Length - 1; ii++)
        //        if (domains[ii] <= select && domains[ii + 1] > select)
        //        {
        //            index = ii;
        //            break;
        //        }
        //    Random rr = new Random(index);
        //    int[] r1 = sq_rand_gen(num_blocks, rr);
        //    ///////////////////////////////////////////////////////////////Color///////////////
        //    X = (l1 * Xnegative1) - (Math.Pow(Xnegative1, 3)) - (gamma * Math.Pow(Math.Abs(Ynegative1), m) * Xnegative1);
        //    Y = (l2 * Ynegative1) - (Math.Pow(Ynegative1, 3)) - (gamma * Math.Pow(Math.Abs(Znegative1), m) * Ynegative1);
        //    Z = (l3 * Znegative1) - (Math.Pow(Znegative1, 3)) - (gamma * Math.Pow(Math.Abs(Xnegative1), m) * Znegative1);
        //    select = turning(X, Y, Z);
        //    Xnegative1 = X; Ynegative1 = Y; Znegative1 = Z;
        //    for (int ii = 0; ii < domains.Length - 1; ii++)
        //        if (domains[ii] <= select && domains[ii + 1] > select)
        //        {
        //            index = ii;
        //            break;
        //        }
        //    rr = new Random(index);
        //    int[] r2 = sq_rand_gen(num_blocks, rr);
        //    //byte[] randbytes = new byte[image.Length];
        //    ////////////////////////////////////////////////////////////////////////////////////////
        //    for (int kk = 0; kk < r1.Length; kk++)
        //    {
        //        int dest_block_num = r1[kk];
        //        int source_block_num = r2[kk];
        //        for (int ll = 0; ll < size_block; ll++)
        //        {
        //            if (!decryption)
        //            {
        //                byte randbyte =Convert.ToByte(rr.Next(255));
        //                int index_pixel_source = (source_block_num) * size_block + ll;
        //                int index_pixel_dest = (dest_block_num) * size_block + ll;
        //                //int hex = int.Parse(image[index_pixel_source].Name, System.Globalization.NumberStyles.HexNumber);
        //                int source=Convert.ToInt32(accessor.ReadByte(index_pixel_source));
        //                byte temp =Convert.ToByte(Convert.ToInt32(randbyte) ^source);
        //                bw.Write(temp);
        //                //result[index_pixel_dest] = Color.FromArgb(temp);
        //                //accessor.Write(index_pixel_dest,temp);
        //            }
        //            else
        //            {
        //                byte randbyte = Convert.ToByte(rr.Next(255));
        //                int index_pixel_source = (dest_block_num) * size_block + ll;
        //                int index_pixel_dest = (source_block_num) * size_block + ll;
        //                //int hex = int.Parse(image[index_pixel_source].Name, System.Globalization.NumberStyles.HexNumber);
        //                //int temp = rr.Next(0, 16777215) ^ hex;
        //                int source=Convert.ToInt32(accessor.ReadByte(index_pixel_source));
        //                byte temp = Convert.ToByte(Convert.ToInt32(randbyte) ^ source);
        //                bw.Write(temp);
        //                //result[index_pixel_dest] = Color.FromArgb(temp);
        //                //accessor.Write(index_pixel_dest, temp);

        //            }
        //        }
        //    }
        //    accessor.Dispose();
        //    bw.Close();
        //    bw.Dispose();
        //}
        public int[] sq_rand_gen(int width, Random rr)
        {

            int[] sq_rand = new int[width];
            ArrayList squence = new ArrayList();
            for (int ii = 0; ii < width; ii++)
                squence.Add(ii);
            for (int ii = 0; ii < sq_rand.Length; ii++)
            {
                int count = squence.Count;
                int rand = rr.Next(count);
                int _fetch = Convert.ToInt32(squence[rand]);
                squence.Remove(_fetch);
                sq_rand[ii] = _fetch;
            }
            return sq_rand;
        }
        private double turning(double x, double y, double z)
        {
            double select;
            double temp1 = Math.Abs(x);
            double temp2 = Math.Abs(y);
            double temp3 = Math.Abs(z);
            if (temp1 > temp2 && temp1 > temp3)
                select = x;
            else if (temp2 > temp1 && temp2 > temp3)
                select = y;
            else select = z;
            return (select);
        }
        private void restrict()
        {
            domains[0] = -2.0;
            for (int i = 1; i < I; i++)
            {
                domains[i] = domains[i - 1] + domain;
            }
        }
        private void restrict(double first, double domain)
        {
            domains[0] = first;
            for (int i = 1; i < 256; i++)
            {
                domains[i] = domains[i - 1] + domain;
            }
        }
        public double key_maker(double first,double domain,int key)
        {
            domain = domain / 256;
            restrict(first, domain);
           return domains[key];
        }
    }
}
