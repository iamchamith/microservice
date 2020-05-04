import React, { useState } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

class _Dropdown extends React.Component {
    constructor(props) {
        super(props);
        this.toggle = this.toggle.bind(this);
        this.changeTitile = this.changeTitile.bind(this);
        this.state = {
            dropdownOpen: false,
            titile:'All Brands'
        };
    }
    toggle() {
        this.setState(prevState => ({
            dropdownOpen: !prevState.dropdownOpen
        }));
    }
    async componentDidMount() {

    }
    changeTitile(e) {
        this.setState({ titile: e.target.innerText });
    }
    render() {
        const brands = this.props.items.map(item => (
            <DropdownItem key={item.key} onClick={this.changeTitile}>{item.value}</DropdownItem>
        ));
        return (
            <Dropdown isOpen={this.state.dropdownOpen} toggle={this.toggle}>
                <DropdownToggle caret>
                    {this.state.titile}
                </DropdownToggle>
                <DropdownMenu>
                    {brands}
                </DropdownMenu>
            </Dropdown>
        );
    }
}
export default _Dropdown;