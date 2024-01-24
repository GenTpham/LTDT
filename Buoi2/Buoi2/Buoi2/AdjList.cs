using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2
{
    class AdjList
    {
        LinkedList<int>[] v;
        int n;  // Số đỉnh
        //Propeties
        public int N { get => n; set => n = value; }
        public LinkedList<int>[] V
        {
            get { return v; }
            set { v = value; }
        }
        // Contructor
        public AdjList() { }
        public AdjList(int k)   // Khởi tạo v có k đỉnh
        {
            v = new LinkedList<int>[k];
        }
        // copy g --> đồ thị hiện tại v
        public AdjList(LinkedList<int>[] g)
        {
            v = g;
        }
        // Đọc file AdjList.txt --> danh sách kề v
        public void FileToAdjList(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            n = int.Parse(sr.ReadLine());
            v = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                v[i] = new LinkedList<int>();
                string st = sr.ReadLine();
                // Đặt điều kiện không phải đỉnh cô lập
                if (st != "")
                {
                    string[] s = st.Split();
                    for (int j = 0; j < s.Length; j++)
                    {
                        int x = int.Parse(s[j]);
                        v[i].AddLast(x);
                    }
                }
            }
            sr.Close();
        }
        // Xuất đồ thị
        public void Output()
        {
            Console.WriteLine("Đồ thị danh sách kề - số đỉnh : " + n);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("   Đỉnh {0} ->", i);
                foreach (int x in v[i])
                    Console.Write("{0, 3}", x);
                Console.WriteLine();
            }
        }
 
        public void AdjListToFile(string fileOutput)
        {
            // Khởi tạo : StreamWriter sw = new StreamWriter(fileOutput);
            StreamWriter sw = new StreamWriter(fileOutput);
            sw.WriteLine(n);
            v = new LinkedList<int>[n];
            // Ghi vào file số đỉnh n
            // Duyệt từng đỉnh i, i = 0..n-1
            for(int i = 0;i < n; i++)
            {
                // Gọi chuổi s : string s = "";
                string s = "";
                // Duyệt các đỉnh liên kết trong v[i]
                foreach (int x in v[i])
                    s = s + x + " ";
                // Cắt khoảng trắng 2 đầu chuổi s
                s = s.Trim();
                // Ghi s vào file
                sw.WriteLine(s);
                
            }
            sw.Close();
        }

    }
}
