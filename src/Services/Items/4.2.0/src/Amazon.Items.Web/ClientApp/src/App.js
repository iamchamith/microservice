import React from 'react';
import { Route } from 'react-router';
import Layout from './screens/Layout';
import Home from './screens/Home';
import ItemInfo from './screens/ItemInfo';
import Cart from './screens/Cart';
export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/items' component={ItemInfo} />
        <Route exact path='/cart' component={Cart} />
    </Layout>
);
