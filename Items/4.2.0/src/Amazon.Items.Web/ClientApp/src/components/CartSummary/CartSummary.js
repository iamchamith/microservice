import React from 'react'; 
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
export default CartSummary => (
    <NavItem>
        <NavLink tag={Link} className="text-dark" to="/Cart">Cart (1)</NavLink>
    </NavItem>
);
