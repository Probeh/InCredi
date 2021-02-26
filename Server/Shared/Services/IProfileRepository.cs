using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Context;
using Shared.Enums;
using Shared.Models;

namespace Shared.Services {
  public class ProfileRepository {
    private readonly ApplicationContext context;

    public ProfileRepository(ApplicationContext context) => this.context = context;

    public async Task<Profile> SearchModel(int id) =>
      await this.context.Profiles.FirstAsync(x => x.Id == id);
    public async Task<ICollection<Profile>> SearchModels() =>
      await this.context.Profiles.ToListAsync();
    public Result SearchModels(int id, BalanceType balance) =>
      this.GetTotals(id, balance);
    public async Task<List<Summary>> GetDeductables(int parentId = 0) {
      return await this.context.Profiles
        .Where(x => parentId > 0 ? x.ParentId == parentId : x != null)
        .Select(x => x.ParentId)
        .Select(x => new Summary() {
          Id = x,
            Total = this.context.Profiles.Where(item => item.ParentId == x).Sum(x => x.Sum)
        }).ToListAsync();
    }

    private Result GetTotals(int parentId, BalanceType balance) {
      var entries = this.context.Profiles
        .Where(x => x.ParentId == parentId)
        .Where(x => balance == BalanceType.Positive ? x.Sum > 0 : x.Sum < 0);

      return new Result() {
        ParentId = parentId,
          Name = entries.First().ParentName,
          Totals = entries
          .Select(x => x.Date.Year)
          .Distinct()
          .Select(year => new Summary() { Year = year, Total = entries.Where(x => x.Date.Year == year).Sum(x => x.Sum) })
          .OrderByDescending(x => x.Total)
          .OrderBy(x => x.Year).ToList()
      };
    }

    public async Task<Profile> CreateModel(Profile model) {
      var result = await this.context.Profiles.AddAsync(model);
      await this.context.SaveChangesAsync();
      return result.Entity;
    }
    public async Task DeleteModel(int id) {
      this.context.Remove(await this.SearchModel(id));
      await this.context.SaveChangesAsync();
    }
    public async Task<Profile> UpdateModel(Profile source) {
      var result = this.context.Profiles.Update(source);
      await this.context.SaveChangesAsync();
      return result.Entity;
    }
  }
}