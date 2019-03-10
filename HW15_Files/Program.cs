using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW15_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex5();
        }
        static void Ex1()
        {
            string path = @"D:\Академия шаг\C#\Homework";
            DirectoryInfo dir = new DirectoryInfo(path);
            List<int> numbers = new List<int>();
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(path, "fiba.txt")))
                {
                    string str = sr.ReadToEnd();
                    string[] arr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in arr)
                    {
                        numbers.Add(int.Parse(item));
                    }
                }
                int count = numbers.Count;

                for (int i = count; i < count * 2; i++)
                {
                    numbers.Add(numbers[i - 1] + numbers[i - 2]);
                }
                using (StreamWriter sw = new StreamWriter(Path.Combine(path, "fiba.txt")))
                {
                    foreach (int item in numbers)
                    {
                        sw.Write(item + " ");
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        static void Ex2()
        {
            string path = @"D:\Академия шаг\C#\Homework";
            DirectoryInfo dir = new DirectoryInfo(path);
            List<int> numbers = new List<int>();

            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(path, "input.txt")))
                {
                    string str = sr.ReadToEnd();
                    string[] arr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in arr)
                    {
                        numbers.Add(int.Parse(item));
                    }
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(path, "output.txt")))
                {
                    sw.Write(numbers.Sum());
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        static void Ex3()
        {
            string path = @"D:\Академия шаг\C#\Homework";
            DirectoryInfo dir = new DirectoryInfo(path);
            Dictionary<char, int> dic = new Dictionary<char, int>();

            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(path, "text.txt")))
                {
                    string str = sr.ReadToEnd();

                    for (int i = 0; i < str.Length; i++)
                    {
                        if (!dic.ContainsKey(str[i]))
                        {
                            dic.Add(str[i], 1);
                        }
                        else if (dic.ContainsKey(str[i]))
                        {
                            dic[str[i]]++;
                        }
                    }
                    dic.Remove(' ');
                    dic.Remove('\n');
                    foreach (var i in dic)
                    {
                        Console.WriteLine(i.Key + " " + i.Value);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void Ex4()
        {
            string path = @"D:\Академия шаг\C#\Homework";
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(path, "name.txt")))
                {
                    sw.WriteLine(Console.ReadLine());
                    sw.WriteLine(Console.ReadLine());
                    sw.WriteLine(Console.ReadLine());
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        static void Ex5()
        {
            string path1 = @"D:\Академия шаг\C#\Homework\K1";
            string path2 = @"D:\Академия шаг\C#\Homework\K2";
            DirectoryInfo dir1 = new DirectoryInfo(path1);
            DirectoryInfo dir2 = new DirectoryInfo(path2);
            dir1.Create();
            dir2.Create();

            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(path1, "t1.txt")))
                {
                    sw.WriteLine("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
                }
                using (StreamWriter sw = new StreamWriter(Path.Combine(path1, "t2.txt")))
                {
                    sw.WriteLine("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
                }
                using (StreamReader sr = new StreamReader(Path.Combine(path1, "t1.txt")))
                {
                    string str = sr.ReadToEnd();
                    using (StreamWriter sw = new StreamWriter(Path.Combine(path2, "t3.txt")))
                    {
                        sw.Write(str);
                    }
                }
                using (StreamReader sr = new StreamReader(Path.Combine(path1, "t2.txt")))
                {
                    string str = sr.ReadToEnd();
                    using (StreamWriter sw = new StreamWriter(Path.Combine(path2, "t3.txt"),true))
                    {
                        sw.Write(str);
                    }
                }
                FileInfo f1 = new FileInfo(Path.Combine(path1, "t1.txt"));
                FileInfo f2 = new FileInfo(Path.Combine(path1, "t2.txt"));
                FileInfo f3 = new FileInfo(Path.Combine(path2, "t3.txt"));
                FileInfo[] files = new FileInfo[] { f1, f2, f3 };

                foreach (FileInfo i in files)
                {
                    Console.WriteLine("Полный путь: {0}", i.FullName);
                    Console.WriteLine("Название: {0}", i.Name);
                    Console.WriteLine("Расширение: {0}", i.Name);
                    Console.WriteLine("Время создания: {0}", i.CreationTime);
                    Console.WriteLine("Атрибуты: {0}", i.Attributes);
                    Console.WriteLine("--------------------------------\n");
                }
                //f2.MoveTo(Path.Combine(path2, "t2.txt"));
                //f1.CopyTo(Path.Combine(path2, "t1.txt"));
                string NewPath = @"D:\Академия шаг\C#\Homework\ALL";
                //Directory.Move(path1, NewPath);

                //dir1.Delete(true);
                DirectoryInfo dir3 = new DirectoryInfo(NewPath);
                FileInfo[] fs = dir3.GetFiles();
                foreach (FileInfo i in fs)
                {
                    Console.WriteLine("Полный путь: {0}", i.FullName);
                    Console.WriteLine("Название: {0}", i.Name);
                    Console.WriteLine("Расширение: {0}", i.Name);
                    Console.WriteLine("Время создания: {0}", i.CreationTime);
                    Console.WriteLine("Атрибуты: {0}", i.Attributes);
                    Console.WriteLine("--------------------------------\n");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
