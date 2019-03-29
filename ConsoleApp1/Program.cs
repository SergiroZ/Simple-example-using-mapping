using System;
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
            var userDto = new UserDto
                {FirstName = "Alex", LastName = "Koh", Email = "alex@gmail.com"};


            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, User>()
                                        .ForMember("FullName",
                                                   opt => opt.MapFrom(c => c.FirstName +
                                                                           " " + c
                                                                               .LastName))
                                        .ForMember("Email",
                                                   opt => opt.MapFrom(src => src.Email)));

            var user = Mapper.Map<UserDto, User>(userDto);
            Console.WriteLine($"{user.FullName} : {user.Email}");

            Mapper.Reset();

            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>()
                                        .ForMember("FirstName",
                                                   opt =>
                                                       opt.MapFrom(c =>
                                                                       c.FullName
                                                                        .Split(' ')[0]))
                                        .ForMember("LastName",
                                                   opt =>
                                                       opt.MapFrom(c =>
                                                                       c.FullName
                                                                        .Split(' ')[1]))
                                        .ForMember("Email",
                                                   opt => opt.MapFrom(src => src.Email)));

            var customer = Mapper.Map<User, UserDto>(user);
            Console.WriteLine($"{customer.FirstName} {customer.LastName} : {customer.Email}");
        }
    }
}