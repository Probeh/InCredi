import { Account } from '@models/account.model'
export interface IIdentity {
  // ======================================= //
  email   ?: string;
  password?: string;
  token   ?: string;
  username?: string;
  // ======================================= //
}
export class Identity extends Account {
  public token: string;
  // ======================================= //
  constructor(model?: IIdentity) {
    super(model?.username, model?.password, model?.email);
    this.token = model.token;
  }
}