import React from 'react';
import OrderService from '../table-management/OrderService';
import { ProductItemData } from '../table-management/TableManagement';
import { UserContext, UserContextModel, UserModel } from './../context/UserContext';
import "./MenuItem.css";

export interface MenuItemProps {
  menuItem: ProductItemData;
  selectedTable: number;
  updateOrderListFn: Function;
}

export interface MenuItemState {
  itemsToAddToOrder: number;
}

export default class MenuItem extends React.Component<MenuItemProps, MenuItemState> {
  static contextType = UserContext;

  constructor(props: MenuItemProps) {
    super(props);
    this.state = {
      itemsToAddToOrder: 1
    };
  }

  changeValue(changeStep: number) {
    this.setState({
      itemsToAddToOrder: Math.max(this.state.itemsToAddToOrder + changeStep, 1)
    })
  }

  addToOrder() {
    var quantity = this.state.itemsToAddToOrder;
    this.setState({ itemsToAddToOrder: 1 })

    var { user } = this.context as UserContextModel;
    if (user && user.token) {
      new OrderService(user.token).addItemToOrder(
        this.props.selectedTable,
        this.props.menuItem.id,
        quantity
      ).then((result: any) => {
        this.props.updateOrderListFn && this.props.updateOrderListFn();
      }).catch((er: any) => {
        console.log(er);
      });
    }
  }

  render() {
    return (
      <div className="menuItem">
        <div className="menuTitle">
          <h4>{this.props.menuItem.productName}</h4>
          <h4>${this.props.menuItem.price}</h4>
        </div>
        {this.props.selectedTable ?
          <div className="menuButtons">
            <a onClick={() => this.changeValue(-1)}> - </a>
            <span>Qt: {this.state?.itemsToAddToOrder}</span>
            <a onClick={() => this.changeValue(1)}> + </a>
            <a onClick={() => this.addToOrder()}>Add Item</a>
          </div> : <></>}
      </div>
    );
  }
}