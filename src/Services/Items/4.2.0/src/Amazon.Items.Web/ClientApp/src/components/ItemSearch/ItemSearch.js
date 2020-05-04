import React, { useState } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import _Dropdown from '../Toolbox/_Dropdown';
import ItemServices from '../../serviceRepository/ItemServices';
export default class ItemSearch extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            brands: [{ key: '0', value: 'a' }, { key: '1', value: 'ab' }, { key: '2', value: 'v' }],
            search: ''
        };
        this.onTextChange = this.onTextChange.bind(this);
    }
    async componentDidMount() {

    }
    onTextChange(event) {
        this.setState({ search: event.target.value });
    }

    render() {
        return (
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <_Dropdown titile='All Brands' items={this.state.brands} />
                    </ul>
                    <form class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search"
                            value={this.state.search} onChange={this.onTextChange} />
                        <button class="btn btn-outline-success my-2 my-sm-0" type="submit" onClick={() => { alert('search'); }}>Search</button>
                    </form>
                </div>
            </nav>
        );
    }
}