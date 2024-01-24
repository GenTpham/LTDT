using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi01
{
    class WeightList
    {
        LinkedList<Tuple<int, int>>[] v;
        int n;
        //Propeties
        public LinkedList<Tuple<int, int>>[] V
        {    get => v; set => v = value; }
        // Contructor
        public WeightList() { }
        public WeightList(int k)
        {
            v = new LinkedList<Tuple<int, int>>[k];
            n = k;
        }
        // Doc file ra ds ke co trong so
        public void FileToWeightList(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            n = int.Parse(sr.ReadLine());
            v = new LinkedList<Tuple<int, int>>[n];

            for (int i = 0; i < n; i++)
            {
                v[i] = new LinkedList<Tuple<int, int>>();
                string str = sr.ReadLine();
                if (str != "")
                {
                    string[] s = str.Split();
                    int j = 0;
                    while (j < s.Length)
                    {
                        int t1 = int.Parse(s[j]);
                        int t2 = int.Parse(s[j + 1]);
                        Tuple<int, int> t = new Tuple<int, int>(t1, t2);
                        v[i].AddLast(t);
                        j = j + 2;
                    }
                }
            }
            sr.Close();
        }
        //Xuat do thi ds ke
        public void Output()
        {
            Console.WriteLine("   Đồ thị danh sách kề có trọng số - số đỉnh : " + n);
            for (int i = 0; i < v.Length; i++)
            {               
                Console.Write("     Dinh " + i + " -> ");
                foreach (Tuple<int, int> x in v[i])
                    Console.Write("({0, 2}, {1, 2})  ",x.Item1, x.Item2);
                Console.WriteLine();
            }
        }
    }
}
