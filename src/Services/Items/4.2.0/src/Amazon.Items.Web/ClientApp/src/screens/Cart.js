import React from 'react';
import { connect } from 'react-redux';
import { CartItem } from '../components/CartItem';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import BaseScreen from './BaseScreen';
export default class Cart extends BaseScreen {
    constructor(props) {
        super(props);
    }

    render() {
        return (<div class="container">
            <div class="card shopping-cart">
                <div class="card-header bg-dark text-light">
                    <i class="fa fa-shopping-cart" aria-hidden="true"></i>
                    Shipping cart
                       <NavLink tag={Link} className="btn btn-outline-info btn-sm pull-right" to="/">Continue shopping</NavLink>
                    <div class="clearfix"></div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <CartItem />
                    </div>

                </div>
            </div></div>);
    }
}

