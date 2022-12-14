import React from 'react';
import OrderItem from '../order-item/OrderItem';
import OrderService from '../table-management/OrderService';
import { TableItemData, TableOrderData } from '../table-management/TableManagement';
import { UserContext, UserContextModel, UserModel } from './../context/UserContext';
import './OrderList.css'; 

export interface OrderListProps {
  table: TableItemData | undefined,
  order: TableOrderData | undefined;

  orderListUpdateFn: Function;
}

export default class OrderList extends React.Component<OrderListProps> {
  static contextType = UserContext;

  constructor(props: OrderListProps) {
    super(props);
  }

  closeOrder() {
    var { user } = this.context as UserContextModel;
    if (user && user.token && this.props.table && this.props.order) {
      new OrderService(user.token).closeOrder(this.props.table.tableNumber)
        .then((result: any) => {
          console.log(result);
        }).catch((er: any) => {
          console.log(er);
        });
      this.props.orderListUpdateFn && this.props.orderListUpdateFn();
    }
  }

  render() {
    return (
      <div className="orderContainer">
        <div>
          <h3>Table # {this.props.table && this.props.table.tableNumber > 0 ? this.props.table.tableNumber : ''}</h3>
          <span>Owner: { this.props.order ? this.props.order.order.user.displayName : 'none' }</span>
        </div>
        <div className="content">
          {this.props.order ?
            this.props.order?.orderItem.map((element, index) => 
              <OrderItem key={index} item={element} />
            ) : (this.props.table && this.props.table.hasActiveOrder ? 'Loading data...' :
              (this.props.table && !this.props.table.hasActiveOrder ? 'No order available. Add items from the menu' : 'Click on a table for details' ))
          }
        </div>
        <div className="total">
          <h2>
            Total: ${
          this.props.order?.orderItem
            .map(x => x.itemSum)
            .reduce((total, current) => {
              return total + current;
            }, 0)
            }</h2>
          <a onClick={() => this.closeOrder() }>Close Order</a>
        </div>
      </div>
    );
  }
}