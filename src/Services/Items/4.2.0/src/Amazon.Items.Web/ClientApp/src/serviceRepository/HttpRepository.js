import GlobalConfig from "../GlobalConfig";
const axios = require("axios").default;

class HttpRepository {
    constructor() {
        this.ApiEndpoint = GlobalConfig.Api;
        axios.defaults.headers.post["Content-Type"] =
            "application/x-www-form-urlencoded";
    }
    async Get(request) {
        axios.defaults.headers.common["Authorization"] = request.Token;
        return await axios.get(`${this.ApiEndpoint}${request.Urn}`);
    }
    async Post(request) {
        axios.defaults.headers.common["Authorization"] = request.Token;
        return await axios.post(`${this.ApiEndpoint}${request.Urn}`, request.Data);
    }
    async Put(request) {
        axios.defaults.headers.common["Authorization"] = request.Token;
        return await axios.put(`${this.ApiEndpoint}${request.Urn}`, request.Data);
    }
    async Delete(request) {
        axios.defaults.headers.common["Authorization"] = request.Token;
        return await axios.delete(`${this.ApiEndpoint}${request.Urn}`);
    }
}
export default HttpRepository;