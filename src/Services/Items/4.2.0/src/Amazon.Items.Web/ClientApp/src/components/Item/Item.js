import React from 'react';
import { connect } from 'react-redux';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './Item.css';
export default class Item extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        let url = "/items/items?id=" + this.props.data.id;
        return (<div className="card">
            <NavLink tag={Link} className="text-dark" to={url}>
                <img className="card-img item-image" src={this.props.data.image} alt={this.props.data.name} />
            </NavLink>
            <div className="card-body">
                <NavLink tag={Link} className="text-dark" to={url}>
                    <h4 className="card-title">{this.props.data.name}</h4>
                </NavLink>
                <p className="card-text">
                    {this.props.data.description}</p>
                <div className="buy d-flex justify-content-between align-items-center">
                    <div className="price text-success"><h5 className="mt-4">$ {this.props.data.price} /= </h5></div>
                    <a href="#" className="btn btn-danger mt-3"><i className="fas fa-shopping-cart"></i> Add to Cart</a>
                </div>
            </div>
        </div>);
    }

}