using System.ComponentModel.DataAnnotations;

namespace Shared.Models {
  public class UserLogin {
    [Required, DataType(DataType.Text), MinLength(4)]
    public string Username { get; set; }

    [Required, DataType(DataType.Text), MinLength(4)]
    public string Password { get; set; }
  }
}