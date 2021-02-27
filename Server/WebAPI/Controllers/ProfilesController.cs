using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using Shared.Models;
using Shared.Services;

namespace WebAPI.Controllers {
  [ApiController, Route("api/[controller]")]
  public class ProfilesController : ControllerBase {
    private readonly ProfileRepository repo;

    public ProfilesController(ProfileRepository repo) => this.repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetModels() {
      return Ok(await this.repo.SearchModels());
    }

    [HttpGet("deductables")]
    public async Task<IActionResult> GetDeductables() {
      return Ok(await this.repo.GetDeductables());
    }

    [HttpGet("{parentId}/totals")]
    public IActionResult GetModels([FromRoute] int parentId) {
      return Ok(this.repo.GetTotals(parentId));
    }

    [HttpGet("{parentId}/balance")]
    public IActionResult GetModels([FromRoute] int parentId, [FromQuery] int balance) {
      return Ok(this.repo.GetTotals(parentId, (BalanceType) balance));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModel([FromRoute] int id) {
      await this.repo.DeleteModel(id);
      return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateModel([FromBody] Profile model) {
      return Ok(await this.repo.UpdateModel(model));
    }
  }
}