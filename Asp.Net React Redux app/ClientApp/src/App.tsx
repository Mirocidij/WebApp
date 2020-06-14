import * as React from 'react';

import './custom.sass'
import Layout from "./components/Layout";
import { Route } from "react-router";
import Home from "./components/Home";
import Counter from "./components/Counter";
import FetchData from "./components/FetchData";
import AllOrdersList from "./components/AllOrdersList";

export class App extends React.PureComponent {
    render(): React.ReactNode {
        return (
            <Layout>
                <Route exact path='/' component={Home}/>
                <Route path='/counter' component={Counter}/>
                <Route path='/fetch-data/:startDateIndex?' component={FetchData}/>
                <Route path='/orders-list/' component={AllOrdersList}/>
            </Layout>
        )
    }
}
