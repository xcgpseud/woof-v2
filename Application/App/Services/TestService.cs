using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.App.Database.Repositories;
using Application.App.DataModels;
using Mapster;

namespace Application.App.Services
{
    public class TestService
    {
        private readonly TestRepository _repository;

        public TestService() => _repository = new TestRepository();

        public string GetTestMessage()
        {
            return "I work.";
        }

        public async Task<TestModel> CreateTest(string title, string desc)
        {
            var entity = await _repository.Create(title, desc);

            return entity.Adapt<TestModel>();
        }

        public async Task<IEnumerable<TestModel>> GetTestsWhereTitleContains(string contains)
        {
            var entities = await _repository.GetWhereTitleContains(contains);

            return entities.Select(x => x.Adapt<TestModel>());
        }
    }
}