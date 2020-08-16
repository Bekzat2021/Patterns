using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User bob = new UserBuilder().SetName("Bob").SetAge(22).SetCompany("IBM").SetMarried(true).Build();
            bob.About();
            Console.WriteLine();

            User sam = User.CreateBuilder().SetAge(23).SetName("Sam").SetCompany("Google").SetMarried(false).Build();
            sam.About();
            Console.WriteLine();

            User alice = new UserBuilder().SetCompany("Microsoft").SetName("Alice").SetAge(21).SetMarried(false);
            alice.About();
            Console.WriteLine();
        }
    }

    class User
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public bool IsMarried { get; set; }

        public void About()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Company: {Company}");
            Console.WriteLine($"Married: {IsMarried}");
        }

        public static UserBuilder CreateBuilder()
        {
            return new UserBuilder();
        }
    }

    class UserBuilder
    {
        private User user;
        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetName(string name)
        {
            user.Name = name;
            return this;
        }

        public UserBuilder SetAge(int age)
        {
            user.Age = age > 0 ? age : 0;
            return this;
        }

        public UserBuilder SetCompany(string company)
        {
            user.Company = company;
            return this;
        }

        public UserBuilder SetMarried(bool isMarried)
        {
            user.IsMarried = isMarried;
            return this;
        }

        public User Build()
        {
            return user;
        }

        public static implicit operator User(UserBuilder userBuilder)
        {
            return userBuilder.user;
        }
    }
}
