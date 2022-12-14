import React from 'react';
import TableItem, { TableItemProps } from '../table-item/TableItem';
import { TableItemData } from '../table-management/TableManagement';
import './TableList.css';

export interface TableListProps {
  tableList: TableItemData[];
  selectedTable: number;

  onTableItemSelected: Function;
}

export default class TableList extends React.Component<TableListProps> {
  constructor(props: TableListProps) {
    super(props);
  }

  render() {
    return (
      <div className="tableContainer">
        <h3>Tables</h3>
        <div className="tableList">
          {this.props.tableList ?
            this.props.tableList.map((element, index) =>
            <TableItem
              key={index}
              tableItem={{ ...element }}
              selected={element.tableNumber === this.props.selectedTable}
              onTableItemSelected={(x: number) => this.props.onTableItemSelected(x) }
            />
          ) : 'Loading data ...'}
        </div>
      </div>
    );
  }
}