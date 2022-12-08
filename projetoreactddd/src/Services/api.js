import axios from 'axios';

const api = axios.create(
    {
        baseURL:"https://localhost:7145/api/"
    }
)
export default api;