import React from 'react';
import { connect } from 'react-redux';
import BaseScreen from './BaseScreen';
import './css/ItemInfoScreen.css';
import ItemServices from '../serviceRepository/ItemServices';
export default class ItemInfoScreen extends BaseScreen {
    constructor(props) {
        super(props);
        this._itemService = new ItemServices();
        this.state = {
            item: {},
            isXhrCompleted: false
        };
    }
    async componentDidMount() {
        await this.loadItems();
    }
    async loadItems() {
        await this._itemService.GetItemById(this._request(this.queryString.id))
            .then(response => {
                var res = this.parseRequest.HandleResponse(response);
                this.setState({
                    item: res,
                    isXhrCompleted: true
                });
            }).catch((e) => {
            });
    }

    render() {
        return (<div class="container-fluid">
            <div class="content-wrapper">
                <div class="item-container">
                    <div class="container">
                        <div class="col-md-12">
                            <div class="product col-md-3 service-image-left">

                                <center>
                                    <img id="item-display" src={this.state.item.image} alt={this.state.item.name} />
                                </center>
                            </div>
                        </div>

                        <div class="col-md-7">
                            <div class="product-title">{this.state.item.name}</div>
                            <div class="product-desc">{this.state.item.description}</div>
                            <div class="product-rating"><i class="fa fa-star gold"></i> <i class="fa fa-star gold"></i> <i class="fa fa-star gold"></i> <i class="fa fa-star gold"></i> <i class="fa fa-star-o"></i> </div>
                            <hr />
                            <div class="product-price">$ {this.state.item.price}/=</div>
                            <div class="product-stock">In Stock</div>
                            <hr />
                            <div class="btn-group cart">
                                <button type="button" class="btn btn-success">
                                    Add to cart
						</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>);
    }

}         
