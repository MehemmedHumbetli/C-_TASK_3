using System;
using System.Text;

class Program
{
    public static void menu()
    {
        Console.WriteLine("[1] Create new Folder");
        Console.WriteLine("[2] Show directory");
        Console.WriteLine("[3] Delete folder");
        Console.WriteLine("[4] Create new File");
        Console.WriteLine("[5] Delete file");
        Console.WriteLine("[6] Transfer file");
        Console.WriteLine("[7] Search file by name");
    }

    public static void CreateFolder(string folderName)
    {
        Directory.CreateDirectory($"C:\\Users\\Humbe_li59\\Desktop\\{folderName}");
    }
    public static void DeleteFolder(string folderName)
    {
        Directory.Delete($"C:\\Users\\Humbe_li59\\Desktop\\{folderName}");
    }
    public static void CreateFile(string fileName, string str)
    {
        using (FileStream fs = new FileStream($"{fileName}.txt", FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = Encoding.Default.GetBytes(str);
            fs.Write(buffer, 0, buffer.Length);
        }
    }
    public static void DeleteFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            File.Delete($"{fileName}.txt");
            Console.WriteLine("File deleted");
        }
        else
        {
            Console.WriteLine("File not found!!");
        }
    }
    public static void FileTransfer(string sourceFile, string destinationFolder)
    {
        string sourceFilePath = $"C:\\Users\\Humbe_li59\\Desktop\\{sourceFile}.txt";
        string destinationFilePath = $"C:\\Users\\Humbe_li59\\Desktop\\{destinationFolder}\\{sourceFile}.txt";

        if (File.Exists(sourceFilePath))
        {
            if (Directory.Exists($"C:\\Users\\Humbe_li59\\Desktop\\{destinationFolder}"))
            {
                File.Move(sourceFilePath, destinationFilePath);
                Console.WriteLine("File transferred successfully");
            }
            else
            {
                Console.WriteLine("Destination folder not found!!");
            }
        }
        else
        {
            Console.WriteLine("Source file not found!!");
        }
    }

    public static void SearchFile(string fileName)
    {
        string filePath = $"C:\\Users\\mehem\\Desktop\\{fileName}.txt";
        if (File.Exists(filePath) == true)
        {
            Console.WriteLine("Yes, file Found");
        }
        else
        {
            Console.WriteLine("No, File not found");
        }
    }
    static void Main(string[] args)
    {
        while (true)
        {
            menu();
            Console.WriteLine("Choose your option: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter the new folder name: ");
                        string fileName = Console.ReadLine();
                        CreateFolder(fileName);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(Directory.GetCurrentDirectory());
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter the delete folder name: ");
                        string fileName = Console.ReadLine();
                        DeleteFolder(fileName);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Enter the file name: ");
                        string fileName = Console.ReadLine();
                        Console.Write("Enter text: ");
                        string str = Console.ReadLine();
                        CreateFile(fileName, str);
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Enter the file name: ");
                        string fileName = Console.ReadLine();
                        DeleteFile(fileName);
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Enter folder name: ");
                        string destinationFolder = Console.ReadLine();
                        Console.WriteLine("Enter the file name: ");
                        string sourceFile = Console.ReadLine();
                        FileTransfer(sourceFile, destinationFolder);

                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Enter Search fileName: ");
                        string searchFileN = Console.ReadLine();
                        SearchFile(searchFileN);
                        break;
                    }
            }
            break;
        }
    }
}