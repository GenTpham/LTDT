using Buoi4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
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
            string title = "TÌM KIẾM TRÊN ĐỒ THỊ BẰNG THUẬT TOÁN BFS (Breadth First Search)"; string[] ms = { "1. Bài 1 : Đỉnh khớp",
                "2. Bài 2 : Tìm đường đi từ đỉnh x -> y",
                "3. Bài 3 : Xét tính liên thông. Số TPLT, xuất các TPLT",
                "0. Thoát" };
            int chon;
            do
            {
                Console.Clear();
                menu.ShowMenu(title, ms);
                Console.Write("Chon:");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {  
                            string filePath = "../../TextFile/CutBridge.txt";
                            AdjList g = new AdjList();
                            g.FileToAdjList(filePath);
                            g.Output();
                            g.Connected();
                            int gInconnect1 = g.Inconnect;
                            Console.Write("  Nhập đỉnh x : ");
                            int x = int.Parse(Console.ReadLine());
                            g.RemoveEdgeX(x);
                            g.Connected();
                            int gInconnect2 = g.Inconnect;
                            if(gInconnect2 > gInconnect1 + 1)
                            {
                                Console.WriteLine($"Đỉnh {x} là đỉnh khớp");
                            }
                            else
                            {
                                Console.WriteLine($"Đỉnh {x} không là đỉnh khớp");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            string filePath = "../../TextFile/CutBridge.txt";
                            AdjList g = new AdjList();
                            g.FileToAdjList(filePath);
                            g.Output();
                            g.Connected();
                            int gInconnect1 = g.Inconnect;
                            Console.Write("  Nhập đỉnh x : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("  Nhập đỉnh y : ");
                            int y = int.Parse(Console.ReadLine());
                            g.RemoveEdgeXY(x, y);
                            g.Connected();
                            int gInconnect2 = g.Inconnect;
                            if (gInconnect2 > gInconnect1 + 1)
                            {
                                Console.WriteLine($"Cạnh {x}, {y} là cạnh cầu");
                            }
                            else
                            {
                                Console.WriteLine($"Cạnh {x}, {y} không là cạnh cầu");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {   // Bài 3 : Xét tính liên thông. Số TPLT, xuất các TPLT
                            string filePath = "../../TextFile/AdjList2.txt";
                            // Khởi tạo đồ thị g :
                            AdjList g = new AdjList();
                            // Đọc file ra đồ thị g; Xuất đồ thị lên màn hình
                            g.FileToAdjList(filePath);
                            g.Output();
                            g.Connected();
                            if (g.Inconnect == 1)
                                Console.WriteLine("  Đồ thị liên thông");
                            else
                            {
                                Console.WriteLine("  Đồ thị có {0} thành phần liên thông", g.Inconnect);
                                g.OutConnected();    // Xuất các TPLT
                            }
                            //g.BFS_Connected();
                            Console.ReadKey();
                            break;
                        }
                        Console.ReadKey();
                }
            } while (chon != 0);
        }
    }
}


