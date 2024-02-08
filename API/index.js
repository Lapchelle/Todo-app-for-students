import axios from 'axios'

export const BASE_URL = 'https://localhost:7248/';

export const ENDPOINTS = {
    user: 'user',
    targtet:'target',
    task:'task',
    contact:'contact',
    status:'status'
}

export const createAPIEndpoint = endpoint => {

    let url = BASE_URL + 'api/' + endpoint + '/';
    return {
        fetch: () => axios.get(url),
        fetchById: id => axios.get(url + id),
        post: newRecord => axios.post(url, newRecord),
        put: (id, updatedRecord) => axios.put(url + id, updatedRecord),
        delete: id => axios.delete(url + id),
    }
}