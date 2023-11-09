using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AttendanceContext())
            {
                var stud = new User() { UserName= "Anton" , Password="Anton123"};
                var stud2 = new User() { UserName = "Andi", Password = "Andi123" };
                db.Users.Add(stud);
                db.Users.Add(stud2);
                db.SaveChanges();

                var q = from b in db.Users
                        orderby b.UserId
                        select b;

                var u = db.Users.Where(x => x.UserName =="Andi").First();

                Console.WriteLine("Nama :" + u.UserName);

            }
        }
    }
}
