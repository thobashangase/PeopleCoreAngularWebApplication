using System;
using System.Collections.Generic;
using System.Text;
using PeopleCoreAngularWebApplication.Repositories;
using PeopleCoreAngularWebApplication.Models;
using System.Threading.Tasks;
using System.Linq;

namespace PeopleCoreAngularWebApplication.Test
{
    public class PeopleRepositoryFake : IPeopleRepository
    {
        private readonly IList<Person> _people;

        public PeopleRepositoryFake()
        {
            _people = new List<Person>()
            {
                new Person()
                {
                    Id = new Guid("81A41F54-EF16-41EA-BF38-1868D523BFDC"),
                    Name = "Thoba",
                    Phone = "1234567890",
                    Email = "unit@test.com"
                }
            };
        }

        public async Task<int> DeletePerson(Guid id)
        {
            await Task.Run(() => _people.Remove(_people.Where(x => x.Id == id).FirstOrDefault()));
            return 1;
        }

        public async Task<IList<Person>> GetPeopleAsync()
        {
            return await Task.Run(() => _people);
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            return await Task.Run(() => _people.Where(x => x.Id == id).FirstOrDefault());
        }

        public async Task<int> InsertPerson(Person person)
        {
            await Task.Run(() => _people.Add(person));
            return 1;
        }

        public Task<int> UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
