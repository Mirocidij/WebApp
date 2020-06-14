import { Action, Reducer } from "redux";
import { AppThunkAction } from "./index";

// State

export interface OrdersState {
  isLoading: boolean,
  orders: Order[]
}

export interface Order {
  userId: number,
  user: User
}

export interface User {
  name: string,
  lastName: string,
  phone: string,
  creatingDateTime: Date,
  email: string,
  orders: Order[]
}

// Actions

interface RequestOrdersAction {
  type: "REQUEST_ORDERS_ACTION"
}

interface ReceiveOrdersAction {
  type: "RECEIVE_ORDERS_ACTION",
  orders: Order[]
}

// discriminated union

type KnowAction = RequestOrdersAction | ReceiveOrdersAction;

// Action creators


export const actionCreators = {
  requestOrders: (): AppThunkAction<KnowAction> => (dispatch, getState) => {
    const appState = getState();

    fetch(`orders`)
      .then(response => response.json() as Promise<Order[]>)
      .then(data => {
        dispatch({ type: "RECEIVE_ORDERS_ACTION", orders: data })
      });

    dispatch({ type: "REQUEST_ORDERS_ACTION" });
  }
}

// Reducer

const unloadState: OrdersState = { orders: [], isLoading: false };

export const reducer: Reducer<OrdersState> = (state: OrdersState | undefined, incomingAction: Action): OrdersState => {
  if (state == undefined) {
    return unloadState;
  }

  const action = incomingAction as KnowAction;
  switch (action.type) {
    case "REQUEST_ORDERS_ACTION":
      return {
        orders: state.orders,
        isLoading: true
      }
    case "RECEIVE_ORDERS_ACTION":
      return {
        orders: action.orders,
        isLoading: false
      }
  }
  
  return state;
}