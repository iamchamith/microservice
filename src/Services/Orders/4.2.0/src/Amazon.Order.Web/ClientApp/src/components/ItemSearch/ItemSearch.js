import React, { useState } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import _Dropdown from '../Toolbox/_Dropdown';
import ItemServices from '../../serviceRepository/ItemServices';
import Request from '../../serviceRepository/Request';
import Extensions from '../../utility/Extensions';
export default class ItemSearch extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            brands: [],
            search: '',
            isXhrCompleted: false,
        };
        this.onTextChange = this.onTextChange.bind(this);
        this._itemService = new ItemServices();
        this.parseRequest = Extensions.HandleResponse;
    }
    async componentDidMount() {
        await this.loadInfo();
    }
    async loadInfo() {
        let request = new Request("token").SetData(0);
        await  this._itemService.GetBrandsKeyValuePair(request)
            .then(response => {
                var res = this.parseRequest(response);
                this.setState({
                    brands: res,
                    isXhrCompleted: true
                });
        }).catch((e) => {
        });
    }
    onTextChange(event) {
        this.setState({ search: event.target.value });
    }

    render() {
        return (
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <_Dropdown titile='All Brands' items={this.state.brands} />
                    </ul>
                    <form className="form-inline my-2 my-lg-0">
                        <input className="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search"
                            value={this.state.search} onChange={this.onTextChange} />
                        <button className="btn btn-outline-success my-2 my-sm-0" type="submit" onClick={() => { alert('search'); }}>Search</button>
                    </form>
                </div>
            </nav>
        );
    }
}