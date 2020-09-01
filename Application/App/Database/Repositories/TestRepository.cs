using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.App.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.App.Database.Repositories
{
    public class TestRepository
    {
        public async Task<TestEntity> Create(string title, string desc)
        {
            using (var db = new SqliteContext())
            {
                var entity = new TestEntity
                {
                    Title = title,
                    Description = desc,
                };

                await db.Tests.AddAsync(entity);
                await db.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<IEnumerable<TestEntity>> GetWhereTitleContains(string contains)
        {
            using (var db = new SqliteContext())
            {
                return await db.Tests
                    .Where(x => x.Title.ToLower().Contains(contains.ToLower()))
                    .ToListAsync();
            }
        }
    }
}