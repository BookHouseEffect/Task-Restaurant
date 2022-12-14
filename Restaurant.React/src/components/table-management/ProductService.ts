import BaseService from "../../BaseService";

export default class ProductService extends BaseService {
  constructor(token: string) {
    super(token);
  }

  getMenu(): any {
    return this.httpGet("/api/product");
  }
}
