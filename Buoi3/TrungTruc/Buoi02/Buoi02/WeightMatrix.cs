using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi02
{
    class WeightMatrix
    {
        public int n;
        public int[,] a;
        // propeties
        public int N { get => n; set => n = value; }
        public int[,] A { get => a; set => a = value; }
        // constructor không đối số
        public WeightMatrix() { }
        // constructor có đối số
        public WeightMatrix(int k)
        {
            n = k;
            a = new int[n, n];
        }
        public void FileToWeightMatrix(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            n = int.Parse(sr.ReadLine());
            a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] s = sr.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    a[i, j] = int.Parse(s[j]) > 0? int.Parse(s[j]) : int.MaxValue;
            }
            sr.Close();
        }
        public void Output()
        {
            Console.WriteLine("Đồ thị ma trận kề - số đỉnh : " + n);
            Console.WriteLine();
            Console.Write(" Đỉnh |");
            for (int i = 0; i < n; i++) Console.Write("    {0}", i);
            Console.WriteLine(); Console.WriteLine("  " + new string('-', 6 * n));
            for (int i = 0; i < n; i++)
            {
                Console.Write("    {0} |", i);
                for (int j = 0; j < n; j++)
                    if(a[i, j] < int.MaxValue) Console.Write("  {0, 3}", a[i, j]);
                    else Console.Write("  {0, 3}", 0);
                Console.WriteLine();
            }
        }
    }
}
