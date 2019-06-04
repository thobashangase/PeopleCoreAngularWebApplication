using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleCoreAngularWebApplication.Models;

namespace PeopleCoreAngularWebApplication.Repositories
{
    public interface IPeopleRepository
    {
        Task<IList<Person>> GetPeopleAsync();
        Task<Person> GetPersonById(Guid id);
        Task<int> InsertPerson(Person person);
        Task<int> UpdatePerson(Person person);
        Task<int> DeletePerson(Guid id);
    }
}