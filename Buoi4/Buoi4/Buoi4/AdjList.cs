using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
{
    internal class AdjList
    {
        LinkedList<int>[] v;
        int n;
        bool[] visited;     // Dùng đánh dấu đỉnh đã đi qua
        int[] index;        // Dùng đánh dấu các TPLT
        int inconnect;      // Dùng đếm số TPLT, và thêm propeties
        public int Inconnect { get => inconnect; set => inconnect = value; }


        // Số đỉnh
        //Propeties
        public int N { get => n; set => n = value; }
        public bool[] Visited { get => visited; set => visited = value; }
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
        public void BFS(int s)
        {
            // Khởi tạo visited[]
            visited = new bool[v.Length];
            // Khởi gáng
            //visited[i] = false (i=0.. <visited.Lenght)
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            // Khai báo Queue :
            Queue<int> q = new Queue<int>();
            // Đánh dấu duyệt s (visited[s]= true)
            visited[s] = true;
            // Đưa s vào queue :s -> q
            q.Enqueue(s);
            // Lặp khi q còn chưa rỗng
            while (q.Count > 0)
            {
                // Lấy trong q ra phần tử s : s <- q
                s = q.Dequeue();
                // Duyệt s, xuất s lên màn hình (Console.Write(s + " - ");)
                Console.Write(s + " - ");
                // Xét các đỉnh kề u của s : (foreach (int u in v[s]))
                foreach (int u in v[s])
                {
                    // Nếu đã duyệt u (visited[u]=true) -> bỏ qua : continue;
                    if (visited[u] == true) continue;
                    visited[u] = true;
                    // Đánh dấu duyệt u (visited[u]=true)
                    // Đưa u vào q : u -> q
                    q.Enqueue(u);
                }
            }
        }
        public void BFS_XtoY(int x, int y)
        {
            int[] pre = new int[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                pre[i] = -1;
            }
            bool[] visited = new bool[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                visited[i] = false;
            }
            Queue<int> q = new Queue<int>();
            visited[x] = true;
            q.Enqueue(x);
            while (q.Count > 0)
            {
                int s = q.Dequeue();
                foreach (int u in v[s])
                {
                    if (visited[u]) continue;
                    visited[u] = true;
                    q.Enqueue(u);
                    pre[u] = s;
                }
            }
            Console.WriteLine();
            int k = y;
            Stack<int> stk = new Stack<int>();
            while (pre[k] != -1)
            {
                stk.Push(k);
                k = pre[k];
            }
            Console.WriteLine();
            Console.Write(" Đường đi từ " + x + " -> " + y + " :   " + x);
            while (stk.Count > 0)
            {
                k = stk.Pop();
                Console.Write(" -> " + k);
            }
            Console.WriteLine();
        }
        public void Connected()
        {
            visited = new bool[v.Length];
            // inconnect : số TPLT  giá trị ban đầu = 0
            inconnect = 0;
            // index : lưu các đỉnh cùng một TPLT, khởi tạo index[] n phần tử
            index = new int[n];
            // Khởi gán index[i] = -1, i = 0 .. < n 
            for (int i = 0; i < n; i++)
            {
                index[i] = -1;
            }
            // Khởi tạo và giá trị ban đầu cho visited[i] = false, Vi = 0 .. < n
            for (int i = 0; i < n; i++)
            {
                visited[i] = false;
            }
            // Duyệt từng đỉnh i
            for (int i = 0; i < visited.Length; i++)
            {
                // Nếu chưa duyệt đỉnh i (visited[i] == false)
                if (visited[i] == false)
                {
                    // Khởi đầu cho một TPLT mới -> tăng inconnect++
                    inconnect++;
                    // Tìm và đánh dấu các đỉnh cùng TPLT, gọi hàm
                    BFS_Connected(i);
                }
            }
            Console.WriteLine();
        }
        // Lượt duyệt mới vớt đỉnh bắt đầu: s
        public void BFS_Connected(int s)
        {
            // Sử dụng một queue cho giải thuật
            Queue<int> q = new Queue<int>();
            // Duyệt đỉnh s (visited[s] = true)
            // Đưa s vào q
            visited[s] = true;
            q.Enqueue(s);
            // Lặp khi queue q còn phần tử
            while (q.Count > 0)
            {
                // Lấy từ queue q ra một phần tử -> s
                s = q.Dequeue();
                // gán giá trị TPLT : index[s] = inconnect;
                index[s] = inconnect;
                // Duyệt các đỉnh kề u của s (int u in v[s])
                foreach (int u in v[s])
                {
                    // Nếu u chưa duyệt (visited[u] == false)
                    if (visited[u] == false)
                    {
                        // Duyệt u : visited[u] = true;
                        // Đưa u vào Queue q
                        visited[u] = true;
                        q.Enqueue(u);
                    }
                }
            }
        }
        // Xuất các thành phần liên thông
        public void OutConnected()
        {
            for (int i = 1; i <= inconnect; i++)
            {
                Console.Write("  TPLT {0} : ", i);
                for (int j = 0; j < index.Length; j++)
                    if (index[j] == i)
                        Console.Write(j + " ");
                Console.WriteLine();
            }
        }

        public void RemoveEdgeX(int x)
        {
            for(int i = 0; i< V.Length; i++)
            {
                if(i == x)
                {
                    V[x].Clear();
                }
                else
                {
                    V[i].Remove(x);
                }
            }
        }

        public void RemoveEdgeXY(int x, int y)
        {
            // Xóa y trong v[x]
            // Xóa x trong v[y]
            for (int i = 0; i < V.Length; i++)
            {
                if (i == x)
                {
                    V[x].Clear();
                }
                else
                {
                    V[i].Remove(x);
                }
            }
            for (int i = 0; i < V.Length; i++)
            {
                if (i == y) 
                {
                    V[y].Clear();
                }
                else
                {
                    V[i].Remove(y);
                }
            }
        }



    }
}