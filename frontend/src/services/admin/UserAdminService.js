import {request} from "../../base/HTTP";
import HttpMethod from "../../constants/HttpMethod";

export async function getUsers(data) {
    return await request('/api/users/all', data);
}

export async function getUser(id) {
    return await request('/api/users/' + id);
}

export async function addUser(data) {
    return await request('/api/users', data, HttpMethod.POST);
}

export async function deleteUser(id) {
    return await request('/api/users/' + id, {} , HttpMethod.DELETE);
}

export async function blockUser(id) {
    return await request('/api/users/block/' + id, {} , HttpMethod.POST);
}


export async function unblockUser(id) {
    return await request('/api/users/unblock/' + id, {} , HttpMethod.POST);
}
