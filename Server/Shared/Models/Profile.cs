using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models {
  public class Profile : BaseModel {
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }
    public int ParentId { get; set; }

    [DataType(DataType.Currency)]
    public double Sum { get; set; }
    public string Details { get; set; }
    public string ParentName { get; set; }

    public Profile() { }
    public Profile(int id, string name, int parentId, string parentName, DateTime date, string type, string details, double sum) : base(id, name, type) {
      Date = date;
      Details = details;
      ParentId = parentId;
      ParentName = parentName;
      Sum = sum;
    }
  }
}