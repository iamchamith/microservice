import React from 'react';
import { connect } from 'react-redux';
import { Item } from '../components/Item';
import { ItemSearch } from '../components/ItemSearch';
import BaseScreen from './BaseScreen';
import ItemServices from '../serviceRepository/ItemServices';
export default class HomeScreen extends BaseScreen {
    constructor(props) {
        super(props);
        this._itemService = new ItemServices();
        this.state = {
            items: [],
            isXhrCompleted: false
        };
    }
    async componentDidMount() {
        await this.loadItems();
    }
    async loadItems() {
        await this._itemService.GetItems(this._request())
            .then(response => {
                var res = this.parseRequest.HandleResponse2(response);
                this.setState({
                    items: res.item1,
                    isXhrCompleted: true
                });
            }).catch((e) => {
            });
    }

    render() {
        const items = this.state.items.map(item => (
            <div className="row">
                <Item data={item} key={item.id} />
            </div>
        ));
        return (
            <div className='row'>
                <ItemSearch />
                {items}
            </div>);
    }
}

