import { ModelBase } from '@models/base.model';

export class Profile extends ModelBase<Profile> {
  public date      : Date  ;
  public details   : string;
  public parentId  : number;
  public parentName: string;
  public sum       : number;
  public type      : string;
  // ======================================= //
  constructor() { super(); }
  // ======================================= //
}
