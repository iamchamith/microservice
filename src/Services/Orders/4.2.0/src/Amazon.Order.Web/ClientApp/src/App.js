import React from 'react';
import { Route } from 'react-router';
import Layout from './screens/Layout';
import HomeScreen from './screens/HomeScreen';
import ItemInfoScreen from './screens/ItemInfoScreen';
import CartScreen from './screens/CartScreen';
export default () => (
    <Layout>
        <Route exact path='/' component={HomeScreen} />
        <Route exact path='/items' component={ItemInfoScreen} />
        <Route exact path='/cart' component={CartScreen} />
    </Layout>
);
