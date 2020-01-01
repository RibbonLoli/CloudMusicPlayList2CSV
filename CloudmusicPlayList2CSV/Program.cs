using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CloudmusicPlayList2CSV
{
    class Program
    {
        static public List<Song> lst;
        static void Main(string[] args)
        {
            Console.WriteLine("NeteaseMusic PlayList to CSV\nBy RibbonLoli\n");
            Console.WriteLine("请输入JSON文件路径:");
            string jsonPath = Console.ReadLine();
            if (!File.Exists(jsonPath))
            {
                Console.WriteLine("未找到JSON文件，请检查输入路径是否正确");
                return;
            }
            string jsonstr = File.ReadAllText(jsonPath);
            JsonFile jsFile = JsonConvert.DeserializeObject<JsonFile>(jsonstr);
            lst = jsFile.playlist.tracks;
            Console.WriteLine("共解析到{0}首歌曲\n", lst.Count);
            string csvPath = Path.Combine(Directory.GetParent(jsonPath).FullName, Path.GetFileNameWithoutExtension(jsonPath) + ".csv");
            DatabaseToCSV(csvPath);

            Console.ReadKey();
        }

        static void OutputSpace(int spc)
        {
            for (int i = 0; i < spc; i++)
            {
                Console.Write(" ");
            }
        }

        static void PrintDataBase()
        {
            Console.Write("序号");
            Console.SetCursorPosition(9, Console.CursorTop);
            Console.Write("标题");
            Console.SetCursorPosition(9 + 60, Console.CursorTop);
            Console.Write("歌手");
            Console.SetCursorPosition(9 + 140, Console.CursorTop);
            Console.Write("专辑\n");
            for (int i = 0; i < lst.Count; i++)
            {
                Console.Write(i + 1);
                Console.SetCursorPosition(9, Console.CursorTop);
                Console.Write(lst[i].name);
                Console.SetCursorPosition(9 + 60, Console.CursorTop);
                Console.Write(lst[i].GetArtists());
                Console.SetCursorPosition(9 + 140, Console.CursorTop);
                Console.Write(lst[i].al.name);
                Console.Write("\n");
            }
        }

        static void DatabaseToCSV(string csvPath)
        {
            FileStream fs = File.Open(csvPath, FileMode.OpenOrCreate);
            string record = "";
            byte[] buffer;
            buffer = System.Text.Encoding.Default.GetBytes("#由程序输出\n标题,歌手,专辑\n");
            fs.Write(buffer, 0, buffer.Length);

            string name, artist, album;
            for (int i = 0; i < lst.Count; i++)
            {
                name = lst[i].name;
                album = lst[i].al.name;
                artist = lst[i].GetArtists();
                if (name.IndexOf(",") != -1)
                    name = string.Format("\"{0}\"", name);
                if (album.IndexOf(",") != -1)
                    album = string.Format("\"{0}\"", album);
                if (artist.IndexOf(",") != -1)
                    artist = string.Format("\"{0}\"", artist);
                record = string.Format("{0},{1},{2}\r\n", name, artist, album);
                buffer = System.Text.Encoding.Default.GetBytes(record);
                fs.Write(buffer, 0, buffer.Length);
            }
            fs.Flush(false);
            fs.Close();
            Console.WriteLine("成功输出到CSV文件\n文件保存在:{0}", csvPath);
        }
    }
}
