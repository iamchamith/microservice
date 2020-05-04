import React, { useState } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

class _Dropdown extends React.Component {
    constructor(props) {
        super(props);
        this.toggle = this.toggle.bind(this);
        this.state = {
            dropdownOpen: false
        };
    }
    toggle() {
        this.setState(prevState => ({
            dropdownOpen: !prevState.dropdownOpen
        }));
    }
    async componentDidMount() {

    }
    render() {
        const brands = this.props.items.map(item => (
            <DropdownItem key={item.key}>{item.value}</DropdownItem>
        ));
        return (
            <Dropdown isOpen={this.state.dropdownOpen} toggle={this.toggle}>
                <DropdownToggle caret>
                    {this.props.titile}
                </DropdownToggle>
                <DropdownMenu>
                    {brands}
                </DropdownMenu>
            </Dropdown>
        );
    }
}
export default _Dropdown;