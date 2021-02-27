export class Results {
  // ======================================= //
  public parentId: number        ;
  public totals  : Array<Summary>;
  // ======================================= //
}
export class Summary {
  // ======================================= //
  public id   : number;
  public total: number;
  public year : number;
  // ======================================= //
}
