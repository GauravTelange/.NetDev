namespace Simple_File_Search_Project
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a Directory");
            string stdir = Console.ReadLine();

            FileSearch.File fileobj = new FileSearch.File();
            fileobj.sendFileName += DisplayFileName;
            Thread thread = new Thread(() => fileobj.Search(stdir));
            thread.Start();

            Console.Read();

        }

        public static void DisplayFileName(string file)
        {
            Console.WriteLine(file);
        }
    }
}