import BaseService from "./BaseService";
import GlobalConfig from '../GlobalConfig';
class ItemServices extends BaseService {
    constructor() {
        super();
        this.GetBrandsUrn = "/brands";
        this.GetBrandsKeyValuePairUrn = '/brands/keyvalues';
        this.GetItemsUrn = "/items"; 
        this.IsAuthenticatedUrn = "/identity-api/users/authorized"; 
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
    async IsAuthenticated(request) {
        request.SetUrn(`${GlobalConfig.IdentityApi}${this.IsAuthenticatedUrn}`);
        return await this.xhrRequest.GetAbsalute(request);
    }
}

export default ItemServices;