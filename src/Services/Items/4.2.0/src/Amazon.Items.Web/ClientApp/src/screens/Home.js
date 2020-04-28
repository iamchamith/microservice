import React from 'react';
import { connect } from 'react-redux';
import Item from '../components/Item/Item';
import { ItemSearch } from '../components/ItemSearch';
export default class Home extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (<div class="container">
            <ItemSearch />
            <div class="row">
                <div class="col-4">
                    <Item />
                </div>
                <div class="col">
                    <Item />
                </div>
                <div class="col">
                    <Item />
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <Item />
                </div>
                <div class="col">
                    <Item />
                </div>
                <div class="col">
                    <Item />
                </div>
            </div>
        </div>);
    }
}

