using Buoi2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2
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
                            string fileInput = "E:\\LTDT\\Buoi2\\Buoi2\\Buoi2\\EdgeList.txt";
                            EdgeList ge = new EdgeList();
                            ge.FileToEdgeList(fileInput); ge.Output();
                            // Tạo đồ thị AdjList ga từ EdgeList ge
                            AdjList ga = new AdjList();
                            ga = EdgeListToAdjList(ge); ga.Output();
                            // Tạo đường dẫn fileOutput
                            string fileOutput = "E:\\LTDT\\Buoi2\\Buoi2\\Buoi2\\AdjList.txt";
                            ga.AdjListToFile(fileOutput);
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
            // Khởi tạo đồ thị AdjList
            AdjList ga = new AdjList();
            // Xác định số đỉnh n của đồ thị: ga.N = ge.N;
            ga.N = ge.N;
            // Khởi tạo array v[] của đồ thị AdjList
            ga.V = new LinkedList<int>[ga.N];

            // Khởi tạo các danh sách liên kết ga.V[i]
            for (int i = 0; i < ga.N; i++)
            {
                // Khởi tạo các danh sách liên kết: ga.V[i] = new LinkedList<int>();
                ga.V[i] = new LinkedList<int>();
            }

            // Xây dựng các phần tử cho các danh sách liên kết
            foreach (Tuple<int, int> edge in ge.G)
            {
                int vertex1 = edge.Item1;
                int vertex2 = edge.Item2;

                // Add vertex2 vào danh sách liên kết của vertex1
                ga.V[vertex1].AddLast(vertex2);
                // Add vertex1 vào danh sách liên kết của vertex2
                ga.V[vertex2].AddLast(vertex1);
            }

            return ga;    // Đồ thị trả về
        }


    }
}

