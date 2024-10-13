using VisStatsBL.Interfaces;
using VisStatsBL.Managers;
using VisStatsDL_File;
using VisStatsDL_SQL;

namespace TestRepo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string filePath = @"C:\Users\runeh\Documents\School\Semester 2\Programmeren gevorderd\cursus\project 1\vissoorten1.txt"; 
            string connectionString = @"Data Source=RUNE\\SQLEXPRESS;Initial Catalog=VisStats;Integrated Security=True;Trust Server Certificate=True";
            IVisStatsRepository visStatsRepository = new VisStatsRepository(connectionString);
            IFileProcessor processor = new FileProcessor();
            VisStatsManager vm = new VisStatsManager(processor, visStatsRepository);
            vm.UploadVissoorten(filePath);
        }
    }
}
