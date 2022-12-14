import { element } from 'prop-types';
import React from 'react';
import MenuItem from '../menu-item/MenuItem';
import { ProductItemData } from '../table-management/TableManagement';
import './MenuList.css';

export interface MenuProps {
  productList: ProductItemData[];
  selectedTable: number;
  updateOrderListFn: Function;
}

export default class MenuList extends React.Component<MenuProps> {
  constructor(props: MenuProps) {
    super(props);
  }

  render() {
    return (
      <div className="menuContainer">
        <div><h3>Menu</h3></div>
        <div className="menuContent">
          {this.props.productList ?
            this.props.productList.map((element, index) =>
          <MenuItem
            key={index}
            menuItem={element}
            selectedTable={this.props.selectedTable}
            updateOrderListFn={this.props.updateOrderListFn}
          />
          ) : "Loading data ..."}
        </div>
      </div>
    );
  }
}