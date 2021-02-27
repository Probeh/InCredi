using System;
using System.Threading.Tasks;
using Core.WebAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shared.Models;

namespace WebAPI.Controllers {
  [ApiController, Route("api/auth"), Authorize]
  public class AccountController : ControllerBase {
    private readonly IConfiguration configuration;
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;

    public AccountController(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager) {
      this.configuration = configuration;
      this.signInManager = signInManager;
      this.userManager = userManager;
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> UserLogin([FromBody] UserLogin model) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }
      var action = await this.signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
      if (!action.Succeeded) {
        return Unauthorized();
      }
      Response.CreateToken(this.configuration);
      return Ok();
    }

    [HttpPost("logout"), AllowAnonymous]
    public IActionResult UserLogout() {
      return Accepted();
    }
  }
}