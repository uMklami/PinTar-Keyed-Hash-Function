using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewKeyScheduling
{
    class PinTar
    {
        byte[] key = new byte[128];

        byte[] T1 = new byte[16];
        byte[] T2 = new byte[16];
        byte[] T3 = new byte[16];
        byte[] T4 = new byte[16];
        byte[] T5 = new byte[16];
        byte[] T6 = new byte[16];
        byte[] T7 = new byte[16];
        byte[] T8 = new byte[16];

        byte[] R1 = { 106, 9, 230, 103, 243, 188, 201, 8, 187, 103, 174, 133, 132, 202, 167, 59 };
        byte[] R2 = { 60, 103, 243, 114, 254, 148, 248, 38, 165, 79, 245, 58, 95, 29, 54, 241 };
        byte[] R3 = { 81, 14, 82, 127, 173, 230, 130, 209, 155, 5, 104, 140, 43, 62, 108, 31 };
        byte[] R4 = { 31, 131, 217, 171, 251, 65, 189, 107, 91, 224, 205, 25, 19, 126, 33, 121 };

        List<byte[]> R_list = new List<byte[]>();
        List<byte[]> IV_list = new List<byte[]>();
        List<byte[]> key_list = new List<byte[]>();

        public PinTar()
        {
            R_list.Add(R1); R_list.Add(R2); R_list.Add(R3); R_list.Add(R4);
            IV_list.Add(R1); IV_list.Add(R2); IV_list.Add(R3); IV_list.Add(R4);

        }

        /**     Main Scheduling Function    **/
        public byte[] KeyedHashFunction(int outputKeySize)
        {
            byte[] result = new byte[outputKeySize];
            for (int i = 1; i < 8; i++)
            {
                R_list[0] = compression(key_list[i], R_list[0]);

                for (int j = 1; j < 4; j++)
                {
                    R_list[j] = compression(R_list[j - 1], R_list[j]);
                }
                R_list[0] = xor(R_list[0], (xor(R_list[1], xor(R_list[2], R_list[3]))));
            }

            /** xoring the resultant vectors with IV    **/
            for(int k = 0; k < 4; k++)
            {
                R_list[k] = xor(IV_list[k], R_list[k]);
            }

            // reduction of the returning array
            if (outputKeySize == 512)
            {
                return R_list[0].Concat(R_list[1]).Concat(R_list[2]).Concat(R_list[3]).ToArray();
            }
            else if (outputKeySize == 256)
            {
                return xor(R_list[0].Concat(R_list[1]).ToArray(), R_list[2].Concat(R_list[3]).ToArray());
            }
            else if (outputKeySize == 128)
            {
                return xor(R_list[0], (xor(R_list[1], xor(R_list[2], R_list[3]))));
            }
            else
            {
                Console.WriteLine("Invalid Key size");
                return result;
            }
            //  return result;
        }


        /**     Function for input key to a key stream    **/
        public void init(byte[] input)
        {
            int sum = 0;
            for (int i = 0; i < 128; i++)
            {
                if (i < 120)
                {
                    if (i < input.Length)
                    {
                        key[i] = input[i];
                        sum += input[i];
                    }
                    else
                    {
                        key[i] = 0;
                    }
                }
                else
                {
                    key[i] = (byte)((sum * i) % 255); // the last eight bytes
                }
            }

            /**  Transforming the input message   **/
            key = Transformation(key);

            /**  Creating 4 streams of 16, 16 bytes from the keystream   **/
            for (int i = 0; i < 128; i++)
            {
                if (i < 16)
                {
                    T1[i] = key[i];
                }
                else if (i >= 16 && i < 32)
                {
                    int j = 0;
                    T2[j] = key[i];
                    j++;
                }
                else if (i >= 32 && i < 48)
                {
                    int j = 0;
                    T3[j] = key[i];
                    j++;
                }
                else if (i >= 48 && i < 64)
                {
                    int j = 0;
                    T4[j] = key[i];
                    j++;
                }
                else if (i >= 64 && i < 80)
                {
                    int j = 0;
                    T5[j] = key[i];
                    j++;
                }
                else if (i >= 80 && i < 96)
                {
                    int j = 0;
                    T6[j] = key[i];
                    j++;
                }
                else if (i >= 96 && i < 112)
                {
                    int j = 0;
                    T7[j] = key[i];
                    j++;
                }
                else if (i >= 112 && i < 128)
                {
                    int j = 0;
                    T8[j] = key[i];
                    j++;
                }
                key_list.Add(T1);
                key_list.Add(T2);
                key_list.Add(T3);
                key_list.Add(T4);
                key_list.Add(T5);
                key_list.Add(T6);
                key_list.Add(T7);
                key_list.Add(T8);
            }
        }
        /** Xoring function **/
        public byte[] xor(byte[] param1, byte[] param2)
        {
            int size = param1.Length;
            byte[] result = new byte[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = (byte)(param1[i] ^ param2[i]);
            }
            return result;
        }


        public byte[] Transformation(byte[] input)
        {
            int size = input.Length;
            byte[] forward = new byte[size];
            byte[] reverse = new byte[size];
            byte[] total = new byte[size];

            /**     Forward Transformation**/
            int leader1 = getLeader(input);
            forward[0] = (byte)quasigroup(leader1, permutation(input[0]));
            for (int i = 1; i < size; i++)
            {
                forward[i] = (byte)quasigroup(forward[i - 1], permutation(input[i]));
            }

            /***    Reverse Transformation  ***/
            int leader2 = getLeader(forward);
            reverse[size - 1] = (byte)quasigroup(permutation(forward[size - 1]), leader2);
            for (int i = size - 2; i >= 0; i--)
            {
                reverse[i] = (byte)quasigroup(permutation(forward[i]), reverse[i + 1]);
            }

            /***    the final xoring    ***/
            for (int i = 0; i < size; i++)
            {
                total[i] = (byte)(forward[i] ^ reverse[i]);
            }
            return total;
        }

        /** 2n-to-n bit Compression function**/
        public byte[] compression(byte[] array1, byte[] array2)
        {
            /** pre-compression module*/
            byte[] arr1 = Transformation(preprocessor(array1, array2));
            byte[] arr2 = Transformation(array2);

            /** End**/

             int SIZE = array1.Length;
             int[] F_1  = new int[SIZE];
             int[] a = new int[SIZE];
             int[] F_2 = new int[SIZE];
             byte[] F_3 = new byte[SIZE];

            for(int i=0; i<SIZE; i++)
                {
                    a[i] = quasigroup(quasigroup(arr1[i], arr2[i]), permutation(arr2[i]));
                    F_1[i] = permutation(a[i]);
                    F_2[i] = quasigroup(quasigroup(permutation(arr2[i]), F_1[i]), a[i]);
                    F_3[i] = (byte)quasigroup(F_1[i], F_2[i]);
                }
            return F_3;
        }

        /** pre-processing first array**/
        public byte[] preprocessor(byte[] array1, byte[] arrary2)
        {
            byte[] result = new byte[array1.Length];
            for (int i = 0; i < array1.Length; i++ )
            {
                result[i] = (byte)(array1[i] ^ (permutation(arrary2[i])));
            }
            return result;
        }

        /** Finding Leader of a vector  **/
        public int getLeader(byte[] input)
        {
            int leader = 0;
            for (int i = 0; i < input.Length; i++)
            {
                leader = quasigroup(leader, input[i]);
            }
            return leader;
        }

        public int quasigroup(int x, int y)
        {
            return (x ^ permutation(permutation(y)));
        }

        public int permutation(int x)
        {
             int[] p = {222, 84 ,187, 195 ,174, 14, 78, 45, 197 ,181,
                121, 242, 129, 142, 186, 90, 214, 184, 21, 172,
                109, 83, 63 ,92, 244, 252, 95, 238, 51, 0, 249,
                70, 185, 246, 18, 183, 29, 196, 6, 81, 162 ,223,
                73, 221, 23, 55, 126 ,149, 10, 44, 139, 103, 19,
                67, 31, 164, 251, 225, 71, 76, 178, 148, 191, 87,
                218, 247, 156, 151, 36, 153, 117, 143, 171, 110,
                88, 182, 146 ,165 ,39, 27 ,220, 144 ,175 ,204 , 37,
                239, 115, 235, 79, 202, 245, 135, 208, 42, 253, 22,
                75 ,161 ,188, 52, 100, 17, 123, 96, 133, 65, 233,
                82, 40, 212 , 48, 113, 179, 134 ,206, 125, 35 ,25 ,
                50 ,207 ,190 ,46 ,89, 154, 38, 118, 102 ,111, 152 ,
                157, 227, 180, 2, 114, 193, 147, 250, 54, 119, 105,
                145, 9, 32, 192, 199, 226, 229, 16, 200, 49, 41, 243,
                13 ,173, 176, 4 ,255 ,234 ,205, 159, 232, 213, 241, 108,
                254, 47, 136, 91, 15, 216, 28, 7 , 120, 69, 94, 80, 60,
                177, 248, 168, 201, 170, 198, 141, 194, 20, 26, 85, 56,
                12, 231 ,30, 230, 124, 3, 59 ,132, 203, 1, 215, 66, 43,
                33, 127, 57, 106, 237, 86, 53, 101, 62, 140, 236, 99,
                58, 128, 240, 112, 68, 189, 211, 150, 77, 158, 116,
                155, 166, 104, 228, 130, 5, 217, 167 ,137, 163, 72,
                131, 97, 98, 107, 219, 138, 209, 93, 64, 24, 61, 160,
                11, 169, 210, 8, 74, 122, 224, 34};

        return p [x];
        }

        // byte array to hexadecimal numbers
        public string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
    }
}
