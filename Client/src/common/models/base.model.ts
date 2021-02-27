export interface IModelBase {
  // ======================================= //
  description ?: string ;
  id          ?: number ;
  isActive    ?: boolean;
  isDefault   ?: boolean;
  name        ?: string ;
  // ======================================= //
}
export class ModelBase<T extends ModelBase<T>> {
  // ======================================= //
  public created     : number ;
  public description : string ;
  public id          : number ;
  public isActive    : boolean;
  public isDefault   : boolean;
  public name        : string ;
  // ======================================= //
  constructor(args?: IModelBase) {
    args ?? Object.keys(this)
      .forEach(key => this[key] = this[key] ?? args[key]);
  }
  // ======================================= //
}