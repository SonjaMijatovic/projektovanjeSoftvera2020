import {request} from "../base/HTTP";
import HttpMethod from "../constants/HttpMethod";

export async function getMedicines(data) {
    return await request('/api/medicines/all', data);
}

export async function addMedicine(data) {
    return await request('/api/medicines', data, HttpMethod.POST);
}

export async function deleteMedicine(id) {
    return await request('/api/medicines/' + id, {} , HttpMethod.DELETE);
}
