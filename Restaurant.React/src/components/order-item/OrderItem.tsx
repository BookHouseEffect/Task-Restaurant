import React from 'react';
import { TableOrderItemData } from '../table-management/TableManagement';
import './OrderItem.css';

export interface OrderItemProps {
  item: TableOrderItemData;
}

export default class OrderItem extends React.Component<OrderItemProps> {
  constructor(props: OrderItemProps) {
    super(props);
  }

  render() {
    return (
      <div className="orderItem">
        <h4>{this.props.item.product.productName}</h4>
        <div>
          {this.props.item.productQuantity} x
          ${this.props.item.productPrice} = 
        </div>
        <h4>${this.props.item.itemSum}</h4>
      </div>
    );
  }
}