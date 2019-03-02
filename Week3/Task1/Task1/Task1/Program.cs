using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex18
{
    enum FSIMode
    {
        Directory = 1,
        File = 2
    }
    class Layer
    {
        public DirectoryInfo[] DirContent
        {
            get;
            set;
        }
        public FileInfo[] FileContent
        {
            get;
            set;
        }
        public int curIndex
        {
            get;
            set;
        }
        void SelectedColor(int i)
        {
            if (i == curIndex)
                Console.BackgroundColor = ConsoleColor.Red;
            else
                Console.BackgroundColor = ConsoleColor.Black;
        }
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < DirContent.Length; i++)
            {
                SelectedColor(i);
                Console.WriteLine((i + 1) + "." + DirContent[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < FileContent.Length; i++)
            {
                SelectedColor(i + DirContent.Length);
                Console.WriteLine((i + DirContent.Length + 1) + "." + FileContent[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    class Program
    {
            static bool exist(string path, int modeNum)
            {
                if ((modeNum == 1 && new DirectoryInfo(path).Exists) || (modeNum == 2 && new FileInfo(path).Exists))
                    return true;
                else
                    return false;
            }
        static void Main(string[] args)
        {
            DirectoryInfo dirI = new DirectoryInfo(@"C:\Users\User\easy.cpp");
            if (!dirI.Exists)
            {
                Console.WriteLine("Directory does not exist");
                return;
            }
            Layer l = new Layer
            {
                DirContent = dirI.GetDirectories(),
                FileContent = dirI.GetFiles(),
                curIndex = 0
            };
            Stack<Layer> st = new Stack<Layer>();
            st.Push(l);
            bool esc = false;
            FSIMode curMode = FSIMode.Directory;
            while (!esc)
            {
                if (curMode == FSIMode.Directory)
                {
                    st.Peek().Draw();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Delete: Del | Rename: F4 | Back: Backspace | Exit: Esc");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ConsoleKeyInfo consolekeyInfo = Console.ReadKey();
                switch (consolekeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (st.Peek().curIndex > 0)
                            st.Peek().curIndex--;
                        else
                            st.Peek().curIndex = st.Peek().DirContent.Length + st.Peek().FileContent.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (st.Peek().DirContent.Length + st.Peek().FileContent.Length - 1 > st.Peek().curIndex)
                            st.Peek().curIndex++;
                        else
                            st.Peek().curIndex = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (st.Peek().DirContent.Length + st.Peek().FileContent.Length == 0)
                            break;
                        int index = st.Peek().curIndex;
                        if (index < st.Peek().DirContent.Length)
                        {
                            DirectoryInfo d = st.Peek().DirContent[index];
                            st.Push(new Layer
                            {
                                DirContent = d.GetDirectories(),
                                FileContent = d.GetFiles(),
                                curIndex = 0
                            });
                        }
                        else
                        {
                            curMode = FSIMode.File;
                            using (FileStream fs = new FileStream(st.Peek().FileContent[index - st.Peek().DirContent.Length].FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());

                                }
                            }

                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (curMode == FSIMode.Directory)
                        {
                            if (st.Count > 1)
                                st.Pop();
                        }
                        else
                        {
                            curMode = FSIMode.Directory;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Escape:
                        esc = true;
                        break;
                    case ConsoleKey.Delete:
                        if (curMode != FSIMode.Directory || (st.Peek().DirContent.Length + st.Peek().FileContent.Length) == 0)
                            break;
                        index = st.Peek().curIndex;
                        int ind = index;
                        if (index < st.Peek().DirContent.Length)
                            st.Peek().DirContent[index].Delete(true);
                        else
                            st.Peek().FileContent[index - st.Peek().DirContent.Length].Delete();
                        int numofcontent = st.Peek().DirContent.Length + st.Peek().FileContent.Length - 2;
                        st.Pop();
                        if (st.Count == 0)
                        {
                            Layer nl = new Layer
                            {
                                DirContent = dirI.GetDirectories(),
                                FileContent = dirI.GetFiles(),
                                curIndex = Math.Min(Math.Max(numofcontent, 0), ind)
                            };
                            st.Push(nl);
                        }
                        else
                        {
                            index = st.Peek().curIndex;
                            DirectoryInfo di = st.Peek().DirContent[index];
                            Layer nl = new Layer
                            {
                                DirContent = di.GetDirectories(),
                                FileContent = di.GetFiles(),
                                curIndex = Math.Min(Math.Max(numofcontent, 0), ind)
                            };
                            st.Push(nl);
                        }
                        break;
                    case ConsoleKey.F4:
                        if (st.Peek().DirContent.Length + st.Peek().FileContent.Length == 0)
                            break;
                        index = st.Peek().curIndex;
                        string name, fullname;
                        int selectedMode;
                        if (index < st.Peek().DirContent.Length)
                        {
                            name = st.Peek().DirContent[index].Name;
                            fullname = st.Peek().DirContent[index].FullName;
                            selectedMode = 1;
                        }
                        else
                        {
                            name = st.Peek().FileContent[index - st.Peek().DirContent.Length].Name;
                            fullname = st.Peek().FileContent[index - st.Peek().DirContent.Length].FullName;
                            selectedMode = 2;
                        }
                        fullname = fullname.Remove(fullname.Length - name.Length);
                        Console.WriteLine("Please enter the new name, to rename {0}:", name);
                        Console.WriteLine(fullname);
                        string newname = Console.ReadLine();
                        while (newname.Length == 0 || exist(fullname + newname, selectedMode))
                        {
                            Console.WriteLine("This directory was created, Enter the new one");
                            newname = Console.ReadLine();
                        }
                        Console.WriteLine(selectedMode);
                        if (selectedMode == 1)
                        {
                            new DirectoryInfo(st.Peek().DirContent[index].FullName).MoveTo(fullname + newname);
                        }
                        else
                            new FileInfo(st.Peek().FileContent[index - st.Peek().DirContent.Length].FullName).MoveTo(fullname + newname);
                        index = st.Peek().curIndex;
                        ind = index;
                        numofcontent = st.Peek().DirContent.Length + st.Peek().FileContent.Length - 1;
                        st.Pop();
                        if (st.Count == 0)
                        {
                            Layer nl = new Layer
                            {
                                DirContent = dirI.GetDirectories(),
                                FileContent = dirI.GetFiles(),
                                curIndex = Math.Min(Math.Max(numofcontent, 0), ind)
                            };
                            st.Push(nl);
                        }
                        else
                        {
                            index = st.Peek().curIndex;
                            DirectoryInfo di = st.Peek().DirContent[index];
                            Layer nl = new Layer
                            {
                                DirContent = di.GetDirectories(),
                                FileContent = di.GetFiles(),
                                curIndex = Math.Min(Math.Max(numofcontent, 0), ind)
                            };
                            st.Push(nl);
                        }
                        break;
                    default:
                        break;
                }

            }
        }
    }
}


