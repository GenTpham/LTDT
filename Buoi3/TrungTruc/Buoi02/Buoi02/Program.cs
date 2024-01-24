using Buoi02;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Xuất text theo Unicode (có dấu tiếng Việt)
            Console.OutputEncoding = Encoding.Unicode;
            // Nhập text theo Unicode (có dấu tiếng Việt)
            Console.InputEncoding = Encoding.Unicode;

            /* Tạo menu */
            Menu menu = new Menu();
            string title = "VẬN DỤNG CÁC THAO TÁC CƠ BẢN TRÊN ĐỒ THỊ";   // Tiêu đề menu
            // Danh sách các mục chọn
            string[] ms = { "1. Bài 1: Chuyển danh sách cạnh sang danh sách kề",
                "2. Bài 2: Chuyển danh sách kề sang danh sách cạnh",
                "3. Bài 3: Đỉnh Bồn chứa",
                "4. Bài 4: Đồ thị chuyển vị",
                "5. Bài 5: Độ dài trung bình của cạnh",
                "0. Thoát" };
            int chon;
            do
            {
                // Xuất menu
                menu.ShowMenu(title, ms);
                Console.Write("     Chọn : ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {   // Bài 1: Chuyển danh sách cạnh sang danh sách kề
                            // Tạo đường dẫn fileInput -> đồ thị EdgeList
                            string fileInput = "E:\\LTDT\\Buoi3\\TrungTruc\\Buoi02\\Buoi02\\TextFile\\EdgeList.txt";
                            EdgeList ge = new EdgeList();
                            ge.FileToEdgeList(fileInput); ge.Output();
                            // Tạo đồ thị AdjList ga từ EdgeList ge
                            AdjList ga = new AdjList();
                            ga = EdgeListToAdjList(ge); ga.Output();
                            // Tạo đường dẫn fileOutput
                            string fileOutput = "E:\\LTDT\\Buoi3\\TrungTruc\\Buoi02\\Buoi02\\TextFile\\AdjList.txt";
                            ga.AdjListToFile(fileOutput);
                            break;
                        }
                        case 2:
                        {
                            Console.WriteLine("bai tap ve nha");
                            break;
                        }
                    case 3:
                        {
                            // Bài 3 : Bồn chứa
                            // Khởi tạo g là đồ thị ma trận kề : AdjMatrix g
                            AdjMatrix g = new AdjMatrix();
                            // Tạo đường dẫn fileInput : DirectedMatrix.txt
                            string fileInput = "D:\\TrungTruc\\Buoi02\\Buoi02\\TextFile\\DirectedMatrix.txt";
                            // Tạo đồ thị g và xuất đồ thị g lên màn hình
                            g.FileToAdjMatrix(fileInput);
                            g.Output();
                            // Tạo đường dẫn fileOutput : Storage.txt
                            string fileOutput = "D:\\TrungTruc\\Buoi02\\Buoi02\\TextFile\\Bonchua.txt";

                            // Gọi hàm : Storage(g, fileOutput);
                            Storage(g, fileOutput);
                            break;

                        }
                    case 4:
                        {
                            // Bài 4 : Đồ thị chuyển vị
                            // Tạo đường dẫn file Input : "../../../TextFile/DirectedList.txt";
                            string fileInput = "D:\\TrungTruc\\Buoi02\\Buoi02\\TextFile\\DirectedList.txt";
                            // Khai báo đồ thị g : AdjList g = new AdjList();
                            AdjList g = new AdjList();
                            // Tạo đồ thị từ fileInput và xuất đồ thị
                            g.FileToAdjList(fileInput);
                            g.Output();
                            // Khai báo G là đồ thị chuyển vị : AdjList G = new AdjList();
                            AdjList G = new AdjList();
                            // Gọi hàm : G = TransposeG(g); G.Output();
                            G = TransposeG(g);
                            G.Output();
                            string fileOutPut = "D:\\TrungTruc\\Buoi02\\Buoi02\\TextFile\\Chuyenvi.txt";
                            G.AdjListToFile(fileOutPut);
                            // Xuất đồ thi chuyển vị G lên màn hình
                            // SV tự làm ghi kết quả vào file Transpose.txt
                            break;

                        }
                    case 5:
                        {
                            // Tạo tham số fileInput
                            string fileInput = "D:\\TrungTruc\\Buoi02\\Buoi02\\TextFile\\WeightEdgeList.txt";
                            WeightEdgeList g = new WeightEdgeList();
                            g.FileToWeightEdgeList(fileInput); g.Output();
                            Console.WriteLine("Cạnh dài nhất :"); MaxEdge(g);
                            Console.WriteLine("Chiều dài TB : {0:0.00}", AverageEdge(g));
                            break;

                        }
                }
                Console.WriteLine(" Nhấn một phím bất kỳ");
                Console.ReadKey();
                Console.Clear();
            } while (chon != 0);
        }
        // Chuyển file EdgeList sang đồ thị danh sách kề AdjList
        static AdjList EdgeListToAdjList(EdgeList ge)
        {
            AdjList ga = new AdjList();
            ga.N = ge.N;
            ga.V = new LinkedList<int>[ga.N];
            for(int i = 0; i < ga.N; i++)
            {
                ga.V[i] = new LinkedList<int>();
            }
            foreach(Tuple<int, int> edge in ge.G)
            {
                int vertex1 = edge.Item1;
                int vertex2 = edge.Item2;
                ga.V[vertex1].AddLast(vertex2);
                ga.V[vertex2].AddLast(vertex1);
            }
            return ga;
        }
        static void Storage(AdjMatrix g, string fileOut)
        {
            // Khởi tạo : StreamWriter sw
            StreamWriter sw = new StreamWriter(fileOut);
            // Khai báo biến đếm : count=0
            int count = 0;  
            // Duyệt các đỉnh i của g
            for(int i = 0; i < g.N; i++)
            {
                // Nếu (g.IsStorage(i) == true)
                if(g.IsStorage(i) == true)
                {
                    // đếm count lên 1
                    count++;
                    // Xuất lên màn hình : ("Đỉnh " + i + " là đỉnh bồn chứa");
                    Console.WriteLine("Dinh " + i + " la dinh bon chua");
                    // Ghi file sw : ("Đỉnh " + i + " là đỉnh bồn chứa");
                    sw.WriteLine("Dinh " + i + " la dinh bon chua");
                }
            }
            sw.WriteLine("So dinh la bon chua: " + count);
            // Ghi file sw : ("Số đỉnh là bồn chứa : " + count);
            // Xuất lên màn hình : ("Số đỉnh là bồn chứa : " + count);
            Console.WriteLine("So dinh la bon chua: " + count);
            sw.Close();
            // Đóng file sw
        }
        // Bài 4 : Đồ thị chuyển vị, nhận vào đồ thị g, trả về đồ thị chuyển vị G
        static AdjList TransposeG(AdjList g)
        {
            // Khai báo đồ thị G : AdjList G
            AdjList G = new AdjList();
            // Xác định số đỉnh G.N là số đỉnh g.N
            G.N = g.N;
            // Cấp phát vùng nhớ cho G.V : new LinkedList<int>[G.N];
            G.V = new LinkedList<int>[G.N];
            // Khởi tạo các dslk G.V[i] = new LinkedList<int>() , i = 0..G.N-1
            for (int i = 0; i < G.N; i++)
            {
                G.V[i] = new LinkedList<int>();
                // Duyệt từng đỉnh i của G
            }
            for (int i = 0; i < G.N; i++)
            {
                // Duyệt từng đỉnh x trong G.V[i]
                foreach (int x in g.V[i])
                {
                    G.V[x].AddLast(i);
                }
                // AddLast i vào G.V[x] : G.V[x].AddLast(i);
            }
            // Trả về G
            return G;
            
        }


        // Độ dài nhất và các cạnh có độ dài lớn nhất
        static void MaxEdge(WeightEdgeList g)
        {
            
            int max = -int.MaxValue;
            // Dùng một dslk lst dùng chứa các cạnh dài nhất
            LinkedList<Tuple<int, int, int>> lst = new LinkedList<Tuple<int, int, int>>();
            // Tìm độ dài nhất max, trong g.G
            foreach(Tuple<int, int, int> e in g.G)
            {
                if(max < e.Item3)
                {
                    max = e.Item3;
                }
            }
            // Tìm các cạnh dài nhất (item3 = max) và Add vào lst
            foreach(Tuple<int, int, int> e in g.G)
            {
                if(e.Item3 == max)
                {
                    lst.AddLast(e);
                }
            }
            // Xuất các cạnh dài nhất & số lượng
            Console.WriteLine(lst.Count);
            
            foreach(Tuple<int, int, int> e in lst)
            {
                Console.WriteLine($"({e.Item1}, {e.Item2}) = {e.Item3}");
            }
        }
        // Trung bình cạnh
        static double AverageEdge(WeightEdgeList g)
        {
            int sum = 0;
            foreach(Tuple<int, int, int> e in g.G)
            {
                sum += e.Item3;
            }
            double avg = (double)sum / g.M;
            return avg;
        }




    }
}

