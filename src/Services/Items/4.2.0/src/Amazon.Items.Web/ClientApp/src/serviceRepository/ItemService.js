mport BaseService from "./BaseService";

class ItemService extends BaseService {
    constructor() {
        super();
        this.ReadMajorsByProfessionalUrn = "/majors";
        this.SearchProfessionalByMajorUrn = 'majors/{0}/professionals/{1}';

        this.ReadProfessionalInfoUrn = "/professionals";
        this.UpdateProfessionalInfoUrn = "/professionals";
        this.SubmitProfessionalInfoUrn = "/professionals";
        this.GetMajorsKeyValueUrn = '/majors/keyvalues';
        this.ReadMyProfessionalInfoUrn = '/profile';
    }
    async ReadMajorsByProfessional(request) {
        request.SetUrn(`${this.ReadMajorsByProfessionalUrn}/${request.Data}`);
        return await this.xhrRequest.Get(request);
    }
    async SearchProfessionalByMajor(request) {
        request.SetUrn(`/majors/${request.Data.majorId}/professionals/${request.Data.withSchool}`);
        return await this.xhrRequest.Get(request);
    }

    async ReadProfessionalInfo(request) {
        request.SetUrn(`${this.ReadProfessionalInfoUrn}/${request.Data}`);
        return await this.xhrRequest.Get(request);
    }
    async UpdateProfessionalInfo(request) {
        request.SetUrn(`${this.UpdateProfessionalInfoUrn}`);
        return await this.xhrRequest.Put(request);
    }
    async SubmitProfessionalInfo(request) {
        request.SetUrn(`${this.SubmitProfessionalInfoUrn}`);
        return await this.xhrRequest.Post(request);
    }
    async GetMajorsKeyValue(request) {
        request.SetUrn(`${this.GetMajorsKeyValueUrn}`);
        return await this.xhrRequest.Get(request);
    }
    async ReadMyProfessionalInfo(request) {
        request.SetUrn(`${this.ReadMyProfessionalInfoUrn}`);
        return await this.xhrRequest.Get(request);
    }
}

export default ProfessionalService;