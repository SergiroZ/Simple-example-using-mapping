using System;
using AutoMapper;

namespace ConsoleApp2
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }

    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }

    internal class Program
    {
        private static void Main()
        {
            var config = new
                MapperConfiguration(cfg =>
                                    {
                                        cfg
                                            .CreateMap<AuthorModel, AuthorDTO>();
                                    });
            var iMapper = config.CreateMapper();

            var source = new AuthorModel
            {
                Id = 1,
                FirstName = "Joy",
                LastName = "Kan",
                Address = "USA, NY 30541"
            };

            var destination = iMapper.Map<AuthorModel, AuthorDTO>(source);
            Console.WriteLine($"Author Name: {destination.FirstName} " +
                              $"{destination.LastName}; {destination.Address}");
        }
    }
}