import BaseService from "./BaseService";

class ItemServices extends BaseService {
    constructor() {
        super();
        this.GetBrandsUrn = "/brands";
        this.GetBrandsKeyValuePairUrn = '/brands/keyvalues';
        this.GetItemsUrn = "/items"; 
    }
    async GetBrands(request) {
        request.SetUrn(`${this.GetBrandsUrn}`);
        return await this.xhrRequest.Get(request);
    }
    async GetBrandsKeyValuePair(request) {
        request.SetUrn(`${this.GetBrandsKeyValuePairUrn}`);
        return await this.xhrRequest.Get(request);
    }

    async GetItemById(request) {
        request.SetUrn(`${this.GetItemsUrn}/${request.Data}`);
        return await this.xhrRequest.Get(request);
    }
    async GetItems(request) {
        request.SetUrn(`${this.GetItemsUrn}`);
        return await this.xhrRequest.Get(request);
    }
}

export default ItemServices;