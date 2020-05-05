import React from 'react';
import { connect } from 'react-redux';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './Nav.css';
import GlobalConfig from '../../GlobalConfig';
export default class LeftNav extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (<div className="sidebar">
            <div className="top-row pl-4 navbar navbar-dark">
                <a className="navbar-brand" href="">Amazon.com</a>
                <button className="navbar-toggler">
                    <span className="navbar-toggler-icon"></span>
                </button>
            </div>

            <div className="collapse">
                <h4 className="nav-header">Shop</h4>
                <ul className="nav flex-column">
                    <li className="nav-item px-3">
                        <a href="/" className="nav-link">
                            <span className="oi oi-home" aria-hidden="true"></span> Shop
                    </a>
                    </li>
                </ul>
            </div>

            <div className="collapse">
                <h4 className="nav-header">Order</h4>
                <ul className="nav flex-column">
                    <li className="nav-item px-3">
                        <a href="/identity/usersettings" className="nav-link">
                            <span className="oi oi-home" aria-hidden="true"></span> Basket
                    </a>
                    </li>
                    <li className="nav-item px-3">
                        <a href="/identity/changepassword" className="nav-link">
                            <span className="oi oi-plus" aria-hidden="true"></span> Previous Orders
                    </a>
                    </li>
                </ul>
            </div>
            <div className="collapse">
                <h4 className="nav-header">Account</h4>
                <ul className="nav flex-column">
                    <li className="nav-item px-3">
                        <a href={GlobalConfig.Identity + "/identity/usersettings"} className="nav-link">
                            <span className="oi oi-home" aria-hidden="true"></span> User Settings
                    </a>
                    </li>
                    <li className="nav-item px-3">
                        <a href={GlobalConfig.Identity + "/identity/changepassword"} className="nav-link">
                            <span className="oi oi-plus" aria-hidden="true"></span> Change Password
                    </a>
                    </li>
                    <li className="nav-item px-3">
                        <a href={GlobalConfig.Identity + "/identity/logout"} className="nav-link">
                            <span className="oi oi-account-logout" aria-hidden="true"></span> Logout
                    </a>
                    </li>
                </ul>
            </div>
        </div>);
    }

}