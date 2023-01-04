export default{
    login(axios, data){
        return axios.$post('/api/Accounts/login', data)
    }
}