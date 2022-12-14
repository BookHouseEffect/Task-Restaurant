import React, { MouseEventHandler } from 'react';
import { TableItemData } from '../table-management/TableManagement';
import './TableItem.css'

export interface TableItemProps {
  tableItem: TableItemData;
  selected: boolean;

  onTableItemSelected?: Function;
}

export default class TableItem extends React.Component<TableItemProps> {
  constructor(props: TableItemProps) {
    super(props);
    this.state = {};
  }

  render() {
    return (
      <button className={ "tableItem " + (this.props.selected ? " selected" : "") }
        onClick={() => this.props.onTableItemSelected
          && this.props.onTableItemSelected(this.props.tableItem.tableNumber)}>
        <div className="smallerText">Table #</div>
        <div>
          {this.props.tableItem.tableNumber}
        </div>
      </button>
    );
  }
}