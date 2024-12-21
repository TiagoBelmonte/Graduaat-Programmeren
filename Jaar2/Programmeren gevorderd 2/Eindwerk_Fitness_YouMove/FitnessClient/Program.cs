using FitnesDataEF.Repositories;
using FitnessBL.Interfaces;
using FitnessBL.Model;

namespace FitnessClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=GymTest;Integrated Security=True;Trust Server Certificate=True";

            Console.WriteLine("Hello, World!");

            IMemberRepo memberRepo = new MemberRepo(connectionString);

            Member member = memberRepo.GetMember(6);

            Console.WriteLine(member);
        }
    }
}
