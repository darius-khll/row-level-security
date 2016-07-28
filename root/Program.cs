using System;
using Console1.Models;
using Console1.Repository;
using System.Collections.Generic;
using System.Linq;


namespace Console1
{
    public class Program
    {
        public static int UserId = 2; //fake userId
        static void Main()
        {
            GenericRepository<Post, Context> repo = new GenericRepository<Post, Context>();

            List<Post> posts = repo.GetAll().ToList();

            foreach (Post item in posts)
                Console.WriteLine(item.Context);

            Console.ReadKey();
        }
    }
}