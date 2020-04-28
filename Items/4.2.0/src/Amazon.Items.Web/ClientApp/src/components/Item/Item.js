import React from 'react';
import { connect } from 'react-redux';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
export default class Item extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (<div className="card">
            <NavLink tag={Link} className="text-dark" to="/items?id=1">
                <img className="card-img" src="https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/vans.png" alt="Vans" />
            </NavLink>
            <div className="card-body">
                <h4 className="card-title">Vans Sk8-Hi MTE Shoes</h4> 
                <p className="card-text">
                    The Vans All-Weather MTE Collection features footwear and apparel designed to withstand the elements whilst still looking cool.             </p>
                <div className="buy d-flex justify-content-between align-items-center">
                    <div className="price text-success"><h5 className="mt-4">$125</h5></div>
                    <a href="#" className="btn btn-danger mt-3"><i className="fas fa-shopping-cart"></i> Add to Cart</a>
                </div>
            </div>
        </div>);
    }

}