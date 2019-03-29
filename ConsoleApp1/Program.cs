using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ConsoleApp1
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }

    public class User
    {
        public string FullName { get; set; }

        public string Email { get; set; }
    }


    internal class Program
    {
        private static void Main()
        {

            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, User>()
                                        .ForMember("Name",
                                                   opt => opt.MapFrom(c => c.FirstName +
                                                                           " " + c
                                                                               .LastName))
                                        .ForMember("Email",
                                                   opt => opt.MapFrom(src => src.Email)));

            var userDto = new UserDto
                {FirstName = "Alex", LastName = "Koh", Email = "alex@gmail.com"};

            User user = Mapper.Map<UserDto, User>(userDto);

            Console.WriteLine($"{user.FullName}+: {user.Email}");
        }
    }
}