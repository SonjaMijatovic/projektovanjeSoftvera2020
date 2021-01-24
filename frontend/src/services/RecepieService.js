import {request} from "../base/HTTP";
import HttpMethod from "../constants/HttpMethod";

export async function getRecepies(data) {
    return await request('/api/recepies/all', data);
}

export async function getRecepiesUser(id) {
    return await request('/api/recepies/' + id);
}

export async function addRecepies(data) {
    return await request('/api/recepies', data, HttpMethod.POST);
}