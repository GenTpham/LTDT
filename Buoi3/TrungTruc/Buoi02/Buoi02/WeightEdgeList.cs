using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi02
{
    class WeightEdgeList
    {
        LinkedList<Tuple<int, int, int>> g;     // Do thi ds canh thay cho edgeList
        int n;      // so dinh cua do thi
        int m;      // so canh cua do thi
        // Propeties
        public int N { get => n; set => n = value; }
        public int M { get => m; set => m = value; }
        public LinkedList<Tuple<int, int, int>> G { get => g; set => g = value; }
        // constructor
        public WeightEdgeList()
        {
            g = new LinkedList<Tuple<int, int, int>>();
        }
        // Đọc file DScanh.txt -> đồ thị g
        public void FileToWeightEdgeList(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string[] s = sr.ReadLine().Split();
            n = int.Parse(s[0]);
            m = int.Parse(s[1]);
            for (int i = 0; i < m; i++)
            {
                s = sr.ReadLine().Split();
                Tuple<int, int, int> e = new Tuple<int, int, int>(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
                g.AddLast(e);
            }
        }
        // Xuất danh sách lên màn hình
        public void Output()
        {
            Console.WriteLine("   Đồ thị danh sách cạnh - số đỉnh n = " + n + " gồm các cạnh :");
            foreach (Tuple<int, int, int> e in g)
                Console.WriteLine("     ({0, 2},{1, 2}) = {2, 2}",e.Item1, e.Item2, e.Item3);
        }
        
    }
}
