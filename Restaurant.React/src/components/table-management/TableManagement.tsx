import React from 'react';
import OrderList from '../order-list/OrderList';
import TableItem, { TableItemProps } from '../table-item/TableItem';
import TableList from '../table-list/TableList';
import './TableManagement.css';
import { UserContext, UserContextModel, UserModel } from './../context/UserContext';
import OrderService from './OrderService';
import MenuList from '../menu-list/MenuList';
import ProductService from './ProductService';


export interface TableManagementState {
  data: { [key: string]: TableItemData };
  selectedTableOrder: TableOrderData | undefined;
  selectedTable: number;
  menu: ProductItemData[];
}

export interface TableItemData {
  restaurantId: number;
  tableNumber: number;
  hasActiveOrder: boolean;
}

export interface TableOrderData {
  order: {
    id: number;
    restaurantId: number;
    tableNumber: number;
    tableOwner: string;
    closedOrder: boolean;
    user: {
      id: string;
      displayName: string;
    }
  };
  orderItem: TableOrderItemData[];
}

export interface TableOrderItemData {
  id: number;
  tableOrderId: number;
  productId: number;
  productPrice: number;
  productQuantity: number;
  itemSum: number;
  product: ProductItemData;
}

export interface ProductItemData {
  id: number;
  productName: string;
  price: number;
}

export default class TableManagement extends React.Component<any, TableManagementState> {
  static contextType = UserContext;

  constructor(props: any) {
    super(props);
    this.state = {
      data: {},
      selectedTableOrder: undefined,
      selectedTable: 0,
      menu: []
    };
  }

  componentDidMount() {
    var id = setInterval(function (parent) {
      var { user } = parent.context as UserContextModel;
      if (user.token && user.token.length) {
        new OrderService(user.token).getTables()
          .then((result: any) => {
            parent.setState({ data: parent.formatTablesRestult(user, result) })
            clearInterval(id);
          }).catch((er: any) => {
            parent.setState({ data: {} })
          });
      }
    }, 1000, this);

    var id2 = setInterval(function (parent) {
      var { user } = parent.context as UserContextModel;
      if (user.token && user.token.length) {
        new ProductService(user.token).getMenu()
          .then((result: any) => {
            parent.setState({ menu: [...result] })
            clearInterval(id2);
          }).catch((er: any) => {
            console.log(er);
            parent.setState({ menu: [] })
          });
      }
    }, 1000, this);
  }

  formatTablesRestult(user: UserModel, result: any) {
    var data: { [key: string]: TableItemData } = {};
    Object.keys(result).forEach(x => {
      if (!result[x]) {
        data[x] = {
          hasActiveOrder: false,
          restaurantId: user.restaurant?.id,
          tableNumber: +x
        } as TableItemData
      } else {
        data[x] = result[x];
      }
    });
    return data;
  }

  onDataItemSelected(tableNumber: number) {
    this.setState({
      selectedTable: tableNumber,
      selectedTableOrder: undefined
    });

    this.updateOrderList();
  }

  updateOrderList() {
    var id = setInterval(function (parent) {
      var { user } = parent.context as UserContextModel;
      if (user.token && user.token.length) {
        new OrderService(user.token).getOrders(parent.state.selectedTable)
          .then((result: any) => {
            parent.setState({ selectedTableOrder: result || undefined })
            clearInterval(id);
          }).catch((er: any) => {
            parent.setState({ selectedTableOrder: undefined })
          })
      }
    }, 1000, this);
  }

  render() {
    return (
      <div className="mainPanel">
        <div className="tablesPanel">
          <TableList tableList={Object.values(this.state.data)}
            selectedTable={this.state.selectedTable}
            onTableItemSelected={(x: number) => this.onDataItemSelected(x)} />
        </div>
        <div className="ordersPanel">
          <OrderList
            table={this.state.selectedTable ? this.state.data["" + this.state.selectedTable] : undefined}
            order={this.state.selectedTableOrder || undefined}
            orderListUpdateFn={() => this.updateOrderList() }
            />
        </div>
        <div className="menuPanel">
          <MenuList
            productList={this.state.menu}
            selectedTable={this.state.selectedTable}
            updateOrderListFn={() => this.updateOrderList() } />
        </div>
      </div>
    );
  }
}
