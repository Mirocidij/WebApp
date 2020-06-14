import * as WeatherForecasts from './WeatherForecasts';
import * as Counter from './Counter';
import * as Orders from './Orders';

export interface ApplicationState {
    counter: Counter.CounterState | undefined;
    weatherForecasts: WeatherForecasts.WeatherForecastsState | undefined;
    orders: Orders.OrdersState | undefined;
}

export const reducers = {
    counter: Counter.reducer,
    weatherForecasts: WeatherForecasts.reducer,
    orders: Orders.reducer
};

export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}
