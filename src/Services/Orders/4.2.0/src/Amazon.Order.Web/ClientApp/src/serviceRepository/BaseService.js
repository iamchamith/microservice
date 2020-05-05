import HttpRepository from './HttpRepository'
class BaseService {

    constructor() {
        this.xhrRequest = new HttpRepository();
    }
}
export default BaseService;