import BaseService from "../../BaseService";

export default class OrderService extends BaseService {
  constructor(token: string) {
    super(token);
  }

  getTables(): any {
    return this.httpGet("/api/order/table");
  }

  getOrders(tableNumber: number): any {
    return this.httpGet(`/api/order/table/${tableNumber}/order`);
  }

  addItemToOrder(tableNumber: number, productId: number, quantity: number): any {
    return this.httpPost(`/api/order/table/${tableNumber}/order`, {
      productId: productId,
      quantity: quantity
    });
  }

  closeOrder(tableNumber: number) {
    return this.httpDelete(`/api/order/table/${tableNumber}/order/close`);
  }
}