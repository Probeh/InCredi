using System.Collections.Generic;

namespace Shared.Models {
  public class Result : BaseModel {
    public int ParentId { get; set; }
    public ICollection<Summary> Totals { get; set; }
  }
}