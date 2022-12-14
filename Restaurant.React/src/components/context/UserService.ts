import BaseService from "../../BaseService";

export default class UserService extends BaseService {
  constructor(token: string) {
    super(token);
  }

  getUser() : any {
    return this.httpGet("/api/user");
  }
}