import React from 'react';
import { Container } from 'reactstrap';
import { Header } from '../components/Header';
import { Footer } from '../components/Footer';
import LeftNav from '../components/LeftNav/LeftNav';
export default props => (
    <React.Fragment>
        <LeftNav />
        <div class="main" >
            <div className="top-row px-4">
                <Header />
            </div>
            <div class="content px-4">
                <Container >
                    {props.children}
                </Container>
            </div>
            <br />
            <hr />
            <Footer />
        </div>
    </React.Fragment>
);
