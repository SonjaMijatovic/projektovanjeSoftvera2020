import {request} from "../base/HTTP";
import HttpMethod from "../constants/HttpMethod";

export async function getAppointments(data) {
    return await request('/api/appointments/all', data);
}

export async function addAppointment(data) {
    return await request('/api/appointments', data, HttpMethod.POST);
}

export async function deleteAppointments(id) {
    return await request('/api/appointments/' + id, {} , HttpMethod.DELETE);
}

export async function cancelAppointment(id) {
    return await request('/api/appointments/cancel/' + id, {} , HttpMethod.POST);
}


export async function reserveAppointment(id) {
    return await request('/api/appointments/reserve/' + id, {} , HttpMethod.POST);
}