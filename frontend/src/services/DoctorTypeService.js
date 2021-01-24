import {request} from "../base/HTTP";
import HttpMethod from "../constants/HttpMethod";

export async function getDoctorTypes(data) {
    return await request('/api/doctor-type/all', data);
}

export async function addDoctorType(data) {
    return await request('/api/doctor-type', data, HttpMethod.POST);
}

export async function deleteDoctorType(id) {
    return await request('/api/doctor-type/' + id, {} , HttpMethod.DELETE);
}
