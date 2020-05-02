import React from 'react';
import { connect } from 'react-redux';
import { Item } from '../components/Item';
import { ItemSearch } from '../components/ItemSearch';
import BaseScreen from './BaseScreen';
export default class Home extends BaseScreen {
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

