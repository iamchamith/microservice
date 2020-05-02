class Request {
    constructor(token) {
        this.Token = token;
    }
    SetData(data) {
        this.Data = data;
        return this;
    }
    SetUrn(urn) {
        this.Urn = urn;
        return this;
    }
}
export default Request;