import React from 'react';
import { Container } from 'reactstrap';
import { Header } from '../components/Header'; 
import { Footer } from '../components/Footer'; 
export default props => (
    <div>
        <Header />
        <Container>
            {props.children}
        </Container>
        <br />
        <hr/>
        <Footer/>
    </div>
);
