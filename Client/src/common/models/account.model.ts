import { ModelBase } from '@models/base.model'

export class Account extends ModelBase<Account> {
  public username: string;
  public password: string;
  public email   : string;
  // ======================================= //
  constructor(username?: string, password?: string, email?: string) {
    super();
    this.username = username ?? username;
    this.password = password ?? password;
    this.email    = email    ?? email   ;
  }
  // ======================================= //
}