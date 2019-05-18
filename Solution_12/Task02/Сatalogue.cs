using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Task02
{
    class Сatalogue
    {

        protected static string MainPath;
        private static XmlDocument Document;
        private const string PathForLog = @"C:\temp.xml";
        private const string PathHistory = @"C:\history";
        private static bool Action;

        public FileSystemWatcher Watcher;
        private DirectoryInfo Info;

        private string DateTimeList;
        private string EditFile;
        private string FileName;
        private DateTime NewDateTimeList;

        public Сatalogue(string pathToCatalog)
        {
            MainPath = pathToCatalog;

            Console.WriteLine("Этот котолог теперь находится под контролем системы");
            Thread.Sleep(1500);
            OnСatalogue();

            if (Action)
            {
                try
                {
                    var xmlWriter = new XmlTextWriter(PathForLog, Encoding.UTF8)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4
                    };

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Каталог");
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var temp = new FileInfo(PathForLog);
            if (temp.IsReadOnly)
                temp.IsReadOnly = false;

            Document = new XmlDocument();
            Document.Load(PathForLog);

            Event();
        }

        public void Event()
        {
            if (Action)
            {
                Info = new DirectoryInfo(MainPath);
                Watcher = new FileSystemWatcher(Info.FullName);

                Watcher.Changed += FileWatcherOnChanged;
                Watcher.Created += FileWatcherOnCreated;
                Watcher.Deleted += FileWatcherOnDeleted;
                Watcher.Renamed += FileWatcherOnRenamed;

                Watcher.EnableRaisingEvents = true;
            }
            else
            {
                Console.Clear();
                var temp = DateTime.Now.ToString(CultureInfo.CurrentCulture);

                Console.WriteLine($"Введите необходимую дату или время для отката. Данные вида \"{temp}\" :");
                DateTimeList = Console.ReadLine();
                Console.WriteLine("Введите путь к файлу и его имя");
                EditFile = Console.ReadLine();
                FileName = Console.ReadLine();
                try
                {
                    NewDateTimeList = DateTime.Parse(DateTimeList);
                    Thread.Sleep(1500);

                    Console.Clear();
                    Console.WriteLine("Идет откат изменений...");

                    Recoil(NewDateTimeList, EditFile, FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(1500);
                    Event();
                }
            }
        }

        private void Recoil(DateTime dateTime, string filePath, string filenName)
        {


            using (StreamReader fstream = new StreamReader(PathHistory, Encoding.Default))
            {
                using (StreamWriter output = new StreamWriter(filePath, true))
                {

                    while (!fstream.EndOfStream)
                    {
                        var name = fstream.ReadLine();
                        if (name.Equals($"<{filenName}>"))///
                        {
                            var date = fstream.ReadLine();
                            if (dateTime == DateTime.Parse(date))
                            {
                                string text = "";
                                File.WriteAllText(filePath, text);
                                while (text != $"</{filenName}>")
                                {
                                    text = File.ReadLines(PathHistory).ToString();
                                    output.WriteLine(text);
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }


        private static void XmlAppendNewLog(string eventName, string oldName, string name, string changeType, string fullPath)
        {
            if (File.Exists(fullPath))
            {
                var fileInfo = new FileInfo(fullPath);
                if (fileInfo.Extension != ".txt") return;
            }


            var element = Document.CreateElement(eventName);
            Document.DocumentElement.AppendChild(element);

            var attribute = Document.CreateAttribute("Дата|Время");
            attribute.Value = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            element.Attributes.Append(attribute);

            if (oldName != "")
            {
                XmlNode element1 = Document.CreateElement("Изначальное имя");
                element1.InnerText = oldName;
                element.AppendChild(element1);
            }

            if (name != "")
            {
                XmlNode element2 = Document.CreateElement("Новое имя");
                element2.InnerText = name;
                element.AppendChild(element2);
            }

            if (fullPath != "")
            {
                var elementFullPath = Document.CreateElement(Directory.Exists(fullPath) ? "Каталог" : "Файл");
                XmlNode element3 = Document.CreateElement("Полная информация");

                element.AppendChild(element3).AppendChild(elementFullPath);


                if (Directory.Exists(fullPath))
                {
                    XmlNode element3_1 = Document.CreateElement("Фремя создания");
                    element3_1.InnerText = Directory.GetCreationTime(fullPath).ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(element3_1);

                    XmlNode element3_2 = Document.CreateElement("Время последнего доступа");
                    element3_2.InnerText = Directory.GetLastAccessTime(fullPath).ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(element3_2);

                    XmlNode element3_3 = Document.CreateElement("Последнее изменение");
                    element3_3.InnerText = Directory.GetLastWriteTime(fullPath).ToString(CultureInfo.CurrentCulture);
                    elementFullPath.AppendChild(element3_3);
                }

                if (changeType != "")
                {
                    XmlNode element4 = Document.CreateElement("Тип изменения");
                    element4.InnerText = changeType;
                    element.AppendChild(element4);
                }
            }
        }

        private static void FileWatcherOnRenamed(object sender, RenamedEventArgs renamedEventArgs)
        {
            XmlAppendNewLog("Переименование",
                            renamedEventArgs.OldName,
                            renamedEventArgs.Name,
                            renamedEventArgs.ChangeType.ToString(),
                            renamedEventArgs.FullPath);
        }


        private static void FileWatcherOnDeleted(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            XmlAppendNewLog("Удаление",
                            changeType: fileSystemEventArgs.ChangeType.ToString(),
                            fullPath: fileSystemEventArgs.FullPath,
                            name: fileSystemEventArgs.Name,
                            oldName: ""
                );
        }

        private static void FileWatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            XmlAppendNewLog("Создание",
                            changeType: fileSystemEventArgs.ChangeType.ToString(),
                            fullPath: fileSystemEventArgs.FullPath,
                            name: fileSystemEventArgs.Name,
                            oldName: "");
        }

        private static void FileWatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            XmlAppendNewLog("Изменение",
                            changeType: fileSystemEventArgs.ChangeType.ToString(),
                            fullPath: fileSystemEventArgs.FullPath,
                            name: fileSystemEventArgs.Name,
                            oldName: "");

            OnRestoration(fileSystemEventArgs.FullPath, fileSystemEventArgs.Name, DateTime.Now);
        }

        private static void OnRestoration(string path, string name, DateTime date)
        {
            FileStream fileStream = null;

            if (!File.Exists(PathHistory))
                fileStream = File.Create(PathHistory);
            else
                fileStream = File.Open(PathHistory, FileMode.Append);

            using (StreamWriter output = new StreamWriter(PathHistory, true))
            {

                output.WriteLine($"<{name}>");
                output.WriteLine(date.ToString());
                string[] strArray = File.ReadAllLines(path);
                foreach (string line in strArray)
                {
                    output.WriteLine(line);
                }
                output.WriteLine($"</{name}>");
            }
        }

        public void OnСatalogue()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tУстановить слежку / или перейти в режим отката?  y/n");
                var keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    Action = true;
                    Console.WriteLine("Включен режим отслеживания...");
                    CreateDirectory();
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }

                if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine();
                    Action = false;
                    Console.WriteLine("Включен режим отката...");
                    CreateDirectory();
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }
            }
        }

        private void CreateDirectory()
        {
            string path = @"D:\history";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
