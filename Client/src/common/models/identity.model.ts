import { Account } from '@models/account.model'
export interface IIdentity {
  token?: string;
  userName?: string;
  password?: string;
  email?: string;
}

export class Identity extends Account {
  public token: string;
  // ======================================= //
  constructor(model?: IIdentity) {
    super(model?.userName, model?.password, model?.email);
    this.token = model.token;
  }
}