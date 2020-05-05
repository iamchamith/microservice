import React from 'react';
import { connect } from 'react-redux';
import './CartItem.css';
export default class CartItem extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <React.Fragment>
                <div class="col-12 col-sm-12 col-md-2 text-center">
                    <img class="img-responsive" src={this.props.data.image} alt="prewiew" width="120" height="80" />
                </div>
                <div class="col-12 text-sm-center col-sm-12 text-md-left col-md-6">
                    <h4 class="product-name"><strong>{this.props.data.name}</strong></h4>
                </div>
                <div class="col-12 col-sm-12 text-sm-center col-md-4 text-md-right row">
                    <div class="col-3 col-sm-3 col-md-6 text-md-right" style={{ paddingTop: '5px' }}>
                        <h6><strong>${this.props.data.price}<span class="text-muted">x</span></strong></h6>
                    </div>
                    <div class="col-4 col-sm-4 col-md-4">
                        <div class="quantity">
                            <input type="button" value="+" class="plus" />
                            <input type="number" step="1" max="99" min="1" value="1" title="Qty" class="qty"
                                size="4" />
                            <input type="button" value="-" class="minus" />
                        </div>
                    </div>
                    <div class="col-2 col-sm-2 col-md-2 text-right">
                        <button type="button" class="btn btn-outline-danger btn-xs">
                           X
                        </button>
                    </div>
                </div>
                </React.Fragment>);
    }

}