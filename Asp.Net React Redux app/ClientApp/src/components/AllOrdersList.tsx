import * as React from "react";
import * as OrderStore from '../store/Orders'
import { RouteComponentProps } from "react-router";
import { connect } from "react-redux";
import { ApplicationState } from "../store";

type OrderProps =
  OrderStore.OrdersState
  & typeof OrderStore.actionCreators
  & RouteComponentProps<{}>


class AllOrdersList extends React.PureComponent<OrderProps> {
  public componentDidMount() {
    this.props.requestOrders();
  }

  public componentDidUpdate() {
    this.props.requestOrders();
  }

  public render() {
    return (
      <React.Fragment>
        <h1 id="tableLabel">Orders</h1>
        <p>My orders list</p>
        {this.renderOrdersTable()}
      </React.Fragment>
    )
  }

  private renderOrdersTable() {
    return (
      <table className='table table-striped' aria-labelledby='tabelLabel'>
        <thead>
        <tr>
          <th>Name</th>
          <th>Last name</th>
          <th>Phone</th>
        </tr>
        </thead>
        <tbody>
        {
          this.props.orders.map((orders: OrderStore.Order) => (
            <tr key={orders.userId}>
              <td>{orders.user.name}</td>
              <td>{orders.user.lastName}</td>
              <td>{orders.user.phone}</td>
            </tr>
          ))
        }
        </tbody>
      </table>
    )
  }
}

export default connect(
  (state: ApplicationState) => state.orders,
  OrderStore.actionCreators
)(AllOrdersList as any)