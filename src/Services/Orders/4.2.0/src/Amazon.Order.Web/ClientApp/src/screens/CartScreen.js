import React from 'react';
import { connect } from 'react-redux';
import { CartItem } from '../components/CartItem';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import BaseScreen from './BaseScreen';
export default class CartScreen extends BaseScreen {
    constructor(props) {
        super(props);
        this.state = {
            items: [{
                id: 1,
                image: 'https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/vans.png',
                name: 'Vans Sk8-Hi MTE Shoes',
                price: '125'
            }, {
                id: 2,
                image: 'https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/vans.png',
                name: 'Vans Sk8-Hi MTE Shoes',
                price: '125'
            }, {
                id: 3,
                image: 'https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/vans.png',
                name: 'Vans Sk8-Hi MTE Shoes',
                price: '125'
            }]
        };
    }

    render() {
        const items = this.state.items.map(item => (
            <CartItem data={item} key={item.id}/>
        ));
        return (<div className="container">
            <div className="card shopping-cart">
                <div className="card-header bg-dark text-light">
                    <i className="fa fa-shopping-cart" aria-hidden="true"></i>
                    Shipping cart
                       <NavLink tag={Link} className="btn btn-outline-info btn-sm pull-right" to="/">Continue shopping</NavLink>
                    <div className="clearfix"></div>
                </div>
                <div className="card-body">
                    <div className="row">
                        {items}
                    </div>
                </div>
            </div></div>);
    }
}

