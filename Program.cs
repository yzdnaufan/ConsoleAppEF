using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEF1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AttendanceDBEntities())
            {
                Console.WriteLine("Choose mode :");
                Console.WriteLine("1. Write Data");
                Console.WriteLine("2. Delete Data\n");
                int i =  Int32.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        // Create and save a new User
                        Console.Write("Enter a name for a new user: ");
                        var name = Console.ReadLine();


                        // Create and save a new User
                        Console.Write("Enter a password for user " + name + ":");
                        var pass = Console.ReadLine();
                        Random rnd = new Random();

                        var acc = new User { UserName = name, passWord = pass };

                        db.Users.Add(acc);
                        db.SaveChanges();

                        // Display all Users from the database
                        var query = from b in db.Users
                                    orderby b.UserName
                                    select b;

                        Console.WriteLine("All user in the database:");
                        foreach (var item in query)
                        {
                            Console.WriteLine(item.UserName+ "\t" + item.UserID);
                        }

                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        break;
                    case 2:
                        // Display all Users from the database
                        var q = from b in db.Users
                                orderby b.UserID
                                select b;
                        Console.WriteLine("All user in the database:");
                        Console.WriteLine("\n\nUserID\tUserName\n\n\n\n");
                        foreach (var item in q)
                        {
                            Console.WriteLine(item.UserID + "\t" + item.UserName);
                        }

                        Console.WriteLine("Type the uid to delete");
                        var uid = Int32.Parse(Console.ReadLine());

                        var u = (from d in db.Users where d.UserID == uid select d).Single();
                        db.Users.Remove(u);
                        db.SaveChanges();


                        Console.WriteLine("Success, Press any key to exit...");

                        // Display all Users from the database
                        q = from b in db.Users
                                orderby b.UserID
                                select b;
                        Console.WriteLine("All user in the database:");
                        Console.WriteLine("\n\nUserID\tUserName\n\n\n\n");
                        foreach (var item in q)
                        {
                            Console.WriteLine(item.UserID + "\t" + item.UserName);
                        }
                        Console.ReadKey();
                        break;

                    default:
                        break;
                }


                
            }


        }
    }
}
