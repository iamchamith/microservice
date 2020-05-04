import React from 'react';
import { connect } from 'react-redux';
import { Item } from '../components/Item';
import { ItemSearch } from '../components/ItemSearch';
import BaseScreen from './BaseScreen';
export default class HomeScreen extends BaseScreen {
    constructor(props) {
        super(props);
        this.state = {
            items: [{
                id: 1,
                image: 'https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/vans.png',
                name: 'Vans Sk8-Hi MTE Shoes',
                description: '   The Vans All-Weather MTE Collection features footwear and apparel designed to withstand the elements whilst still looking cool.',
                price:'$125'
            }, {
                    id: 1,
                    image: 'https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/vans.png',
                    name: 'Vans Sk8-Hi MTE Shoes',
                    description: '   The Vans All-Weather MTE Collection features footwear and apparel designed to withstand the elements whilst still looking cool.',
                    price: '$125'
                },{
                    id: 1,
                    image: 'https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/vans.png',
                    name: 'Vans Sk8-Hi MTE Shoes',
                    description: '   The Vans All-Weather MTE Collection features footwear and apparel designed to withstand the elements whilst still looking cool.',
                    price: '$125'
                }]
        };
    }
    componentDidMount() {

    }
    render() {
        return (<div className="container">
            <ItemSearch />
            <div className="row">
                <div className="col-4">
                    <Item data={this.state.items[0]} key={this.state.items[0].id} />
                </div>
             </div>
            <div className="row">
                <div className="col-4">
                    <Item data={this.state.items[0]} key={this.state.items[0].id} />
                </div>
            </div>
            <div className="row">
                <div className="col-4">
                    <Item data={this.state.items[0]} key={this.state.items[0].id} />
                </div>
            </div>
             <div className="row">
                <div className="col-4">
                    <Item data={this.state.items[0]} key={this.state.items[0].id} />
                </div>
             </div>
            </div>);
    }
}

