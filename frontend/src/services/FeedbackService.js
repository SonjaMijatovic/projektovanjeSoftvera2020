import {request} from "../base/HTTP";
import HttpMethod from "../constants/HttpMethod";

export async function getFeedbacks(data) {
    return await request('/api/feedbacks/all', data);
}

export async function addFeedback(data) {
    return await request('/api/feedbacks', data, HttpMethod.POST);
}

export async function publishFeedback(id) {
    return await request('/api/feedbacks/publish/' + id, {} , HttpMethod.POST);
}


export async function unpublishFeedback(id) {
    return await request('/api/feedbacks/unpublish/' + id, {} , HttpMethod.POST);
}
