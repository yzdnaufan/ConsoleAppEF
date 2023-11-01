using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEF2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AttendanceModelContainer())
            {
                Console.WriteLine("Masukkan username untuk dimasukkan kedalam database :");
                var name = Console.ReadLine();

                Console.WriteLine("Masukkan password untuk dimasukkan kedalam database :");
                var pass = Console.ReadLine();


                var user = new Users() { username = name, password = pass };
                db.Users.Add(user);
                db.SaveChanges();

                var q = from b in db.Users
                        orderby b.UserId
                        select b;
                Console.WriteLine("Berikut adalah list user yang ada :\nUserId\t\tUsername\tPassword");
                foreach (var item in q)
                {
                    Console.WriteLine(item.UserId + "\t\t" + item.username + "\t\t" + item.password);
                }

                Console.WriteLine("Silahkan pilih userid yang ingin dihapus :");
                var i = Int32.Parse( Console.ReadLine());

                user = db.Users.Where(b => b.UserId == i).Single();

                db.Users.Remove(user);
                db.SaveChanges();

                Console.WriteLine("Berikut adalah list user yang ada :\nUserId\t\tUsername\tPassword");
                foreach (var item in q)
                {
                    Console.WriteLine(item.UserId + "\t\t" + item.username + "\t\t" + item.password);
                }

                Console.WriteLine("Press any key to end...");
                Console.ReadKey();
            }
        }
    }
}
