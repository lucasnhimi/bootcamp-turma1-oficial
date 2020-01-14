import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:5001/api',
    responseType: 'json',
})

export default api;