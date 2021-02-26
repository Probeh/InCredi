using System.ComponentModel.DataAnnotations;

namespace Shared.Models {
  public class BaseModel {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public BaseModel() { }

    public BaseModel(int id, string name, string type) : this() {
      Name = name;
      Type = type;
    }
  }
}