using ADO.NET.Data.Model;
using ADO.NET.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class ManageTowns
    {
        IRepo<Towns> townRepo;
        public ManageTowns()
        {
            townRepo = new TownsRepo();
        }
        void DeleteDepartment()
        {
            Console.Write("Enter Id => ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (townRepo.Delete(id) > 0)
                Console.WriteLine("Town deleted successfully");
            else
                Console.WriteLine("Some error has occured");
        }

        void UpdateDepartment()
        {
            Towns d = new Towns();
            Console.Write("Enter Id => ");
            d.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name => ");
            d.Name = Console.ReadLine();

            Console.Write("Enter Country Id => ");
            d.CountryId = Convert.ToInt32(Console.ReadLine());

            if (townRepo.Update(d) > 0)
                Console.WriteLine("Town Updated");
            else
            {
                Console.WriteLine("Some error has occurred");
            }
        }
        void AddTown()
        {

            Towns d = new Towns();
            Console.Write("Enter Name => ");
            d.Name = Console.ReadLine();

            if (townRepo.Insert(d) > 0)
                Console.WriteLine("Town added");
            else
            {
                Console.WriteLine("Some error has occurred");
            }
        }

        void PrintAll()
        {
            IEnumerable<Towns> collection = townRepo.GetAll();
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.Id} \t {item.Name} \t {item.CountryId}");
                }
            }
        }
        public void Run()
        {
            AddTown();
        }
    }
}
