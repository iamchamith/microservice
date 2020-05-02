import React, { Component } from "react";
import { Loading, NoResultFound } from "../components/Utility";
import Request from "../serviceRepository/Request";
import Extensions from "./../utility/Extensions";
import queryString from "query-string";
class BaseScreen extends Component {
    constructor(props) {
        super(props);
        this.parseRequest = Extensions;
        this.queryString = queryString.parse(this.props.location.search);
        this.Loading = Loading;
    }
    Bind(state, data) {
        if (state.isXhrCompleted) {
            return data.length === 0 ? <NoResultFound /> : data;
        } else {
            return <Loading />;
        }
    }
    _request(data) {
        return new Request("token").SetData(data);
    }
}
export default BaseScreen;