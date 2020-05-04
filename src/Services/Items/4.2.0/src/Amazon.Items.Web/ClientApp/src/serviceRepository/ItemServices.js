import BaseService from "../BaseService";

class ItemServices extends BaseService {
    constructor() {
        super();
        this.GetBrandsUrn = "/brands";
        this.GetBrandsKeyValuePairUrn = '/brands/keyvalues';

        this.GetItemByIdUrn = "items/{id:int}";
        this.GetItemsUrn = "/items"; 
    }
    async GetBrands(request) {
        request.SetUrn(`${this.ReadMajorsByProfessionalUrn}/${request.Data}`);
        return await this.xhrRequest.Get(request);
    }
    async GetBrandsKeyValuePair(request) {
        request.SetUrn(`/majors/${request.Data.majorId}/professionals/${request.Data.withSchool}`);
        return await this.xhrRequest.Get(request);
    }

    async GetItemById(request) {
        request.SetUrn(`${this.ReadProfessionalInfoUrn}/${request.Data}`);
        return await this.xhrRequest.Get(request);
    }
    async GetItems(request) {
        request.SetUrn(`${this.UpdateProfessionalInfoUrn}`);
        return await this.xhrRequest.Put(request);
    }
}

export default ItemServices;