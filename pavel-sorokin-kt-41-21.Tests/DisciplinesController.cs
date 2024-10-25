using Xunit;
using Microsoft.EntityFrameworkCore;
using pavel_sorokin_kt_41_21.Database;
using pavel_sorokin_kt_41_21.Models;
using pavel_sorokin_kt_41_21.Filters.DisciplineFilters;
using pavel_sorokin_kt_41_21.Interfaces.DisciplinesInterfaces;

namespace pavel_sorokin_kt_41_21.Tests
{
    public class DisciplineIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public DisciplineIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase(databaseName: "discipline_db")
                .Options;
        }

        [Fact]
        public async Task GetDisciplinesByDirectionAsync_Science_TwoObjects()
        {
            // Arrange
            using var ctx = new StudentDbContext(_dbContextOptions);
            var disciplineService = new DisciplineService(ctx);

            var disciplines = new List<Discipline>
            {
                new Discipline
                {
                    DisciplineName = "Mathematics",
                    Direction = "Science",
                    IsDeleted = false
                },
                new Discipline
                {
                    DisciplineName = "Physics",
                    Direction = "Science",
                    IsDeleted = false
                },
                new Discipline
                {
                    DisciplineName = "History",
                    Direction = "Arts",
                    IsDeleted = false
                }
            };
            await ctx.Set<Discipline>().AddRangeAsync(disciplines);
            await ctx.SaveChangesAsync();

            // Act
            var filter = new DisciplineDirectionFilter
            {
                Direction = "Science"
            };
            var disciplinesResult = await disciplineService.GetDisciplinesByDirectionAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, disciplinesResult.Length);
            Assert.All(disciplinesResult, d => Assert.Equal("Science", d.Direction));
        }
    }
}
