using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi02
{
    internal class AdjList1
    {
        LinkedList<int>[] v;
        int n;  // Số đỉnh
        // Để đơn giản : thêm các thành phần chỉ tham gia vào giải thuật
        bool[] visited;     // Dùng đánh dấu đỉnh đã đi qua
        int[] index;        // Dùng đánh dấu các TPLT
        int inconnect;      // Dùng đếm số TPLT
        //Propeties
        public int N { get => n; set => n = value; }
        public LinkedList<int>[] V { get => v; set => v = value; }
        public int Inconnect { get => inconnect; set => inconnect = value; }
        // Contructor
        public AdjList1() { }
        public AdjList1(int k)   // Khởi tạo v có k đỉnh
        {
            v = new LinkedList<int>[k];
        }
        // copy g --> đồ thị hiện tại v
        public AdjList1(LinkedList<int>[] g)
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

        // Bài 1 : Duyệt đồ thị theo BFS với đỉnh xuất phát s
        public void BFS(int s)
        {
            // Khởi tạo visited[]
            visited = new bool[v.Length];
            // Khởi gáng visited[i] = false (i=0.. <visited.Lenght)
            Queue<int> q = new Queue<int>();
            // Khai báo Queue : Queue<int> q = new Queue<int>();

            // Đánh dấu duyệt s (visited[s]= true)
            visited[s] = true;
            // Đưa s vào queue :s -> q
            q.Enqueue(s);
            // Lặp khi q còn chưa rỗng
            while(q.Count < 0)
            {
                // Lấy trong q ra phần tử s : s <- q
                s = q.Dequeue();
                // Duyệt s, xuất s lên màn hình (Console.Write(s + " - ");)
                Console.WriteLine(s + "-");
                foreach (int u in v[s])
                // Xét các đỉnh kề u của s : (foreach (int u in v[s]))
                {
                    if (visited[u] == true) continue;
                    visited[u] = true;
                    q.Enqueue(u);

                    // Nếu đã duyệt u (visited[u]=true) -> bỏ qua : continue;
                    // Đánh dấu duyệt u (visited[u]=true)
                    // Đưa u vào q : u -> q
                }
            }
        }
        // Bài 2 : Tìm đường đi từ đỉnh x đến y theo BFS
        public void BFS_XtoY(int x, int y)
        {
            // pre[] : lưu đỉnh nằm trước trên đường đi
            // Khởi tạo pre[] với v.Lenght phần tử
            // Gán các giá trị pre[i] = -1 với i = 0 ... <v.Lenght
            // khởi tạo và gán các giá trị ban đầu cho visited[]
            // Khai báo một queue<int> q
            // Đánh dấu đã duyệt x
            // Đưa x vào q
            // Lặp khi q chưa rỗng
            {
                // Lấy trong q ra đỉnh s : int s = q.Dequeue();
                // Duyệt các đỉnh kề u của s : (foreach (int u in v[s]))
                {
                    // Nếu đã duyệt u (visited[u]=true) thì bỏ qua (continue)
                    // Đánh dấu đã duyệt u
                    // Đưa u vào q
                    // Đặt s là đỉnh trước u : pre[u] = s;
                }
            }
            // Xuất đường đi từ x đến y
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
        // Xét tính liên thông và xác định giá trị cho visite[], index[]
        // Xác định inconnect : số thành phần liên thông (TPLT)
        public void Connected()
        {
            // inconnect : số TPLT  giá trị ban đầu = 0
            // index : lưu các đỉnh cùng một TPLT, khởi tạo index[] n phần tử
            // Khởi gán index[i] = -1, i = 0 .. < n 
            // Khởi tạo và giá trị ban đầu cho visited[i] = false, Vi = 0 .. < n          
            // Duyệt từng đỉnh i
            for (int i = 0; i < visited.Length; i++)
            // Nếu chưa duyệt đỉnh i (visited[i] == false)        
            {
                // Khởi đầu cho một TPLT mới -> tăng inconnect++
                // Tìm và đánh dấu các đỉnh cùng TPLT, gọi hàm
                BFS_Connected(i);
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
            // Lặp khi queue q còn phần tử
            {
                // Lấy từ queue q ra một phần tử -> s
                // gán giá trị TPLT : index[s] = inconnect;
                // Duyệt các đỉnh kề u của s (int u in v[s])
                {
                    // Nếu u chưa duyệt (visited[u] == false)
                    {
                        // Duyệt u : visited[u] = true;
                        // Đưa u vào Queue q
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
    }

}

