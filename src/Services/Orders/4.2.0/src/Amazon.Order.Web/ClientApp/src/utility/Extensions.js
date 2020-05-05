class Extensions {

    static HandleResponse(response) {
        if (response.status === 200) {
            return response.data.result.item;
        }
        else if (response.status === 400) {

            throw new Error();
        }
        else {
            throw new Error();
        }
    }
    static HandleResponse2(response) {
        if (response.status === 200) {
            return { item1: response.data.result.item1, item2: response.data.result.item2 };
        }
        else if (response.status === 400) {

            throw new Error();
        }
        else {
            throw new Error();
        }
    }
    static IsEqual(one, two) {
        return one === two;
    }
}
export default Extensions;