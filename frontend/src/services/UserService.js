import {request} from "../base/HTTP";
import HttpMethod from "../constants/HttpMethod";

export async function register(data) {
    return await request('/api/users', data, HttpMethod.POST);
} 