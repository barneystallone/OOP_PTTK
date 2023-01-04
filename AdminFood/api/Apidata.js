export default {
    getfood(axios){
      return axios.get('/api/foods')
    },
    getmenu(axios){
      return axios.get(`/api/menus`)
    },
    getnews(axios){
      return axios.get(`/api/news`)
    },
    getcustomer(axios){
      return axios.get('/api/Customers/Admin')
    },
    getSlider(axios){
      return axios.get('/api/Sliders')
    },
    getfoodbymenuyid(axios, menuyID){
      return axios.get('/api/foods/viaCateId?MenuyId='+ menuyID)
    },
    GetOutstandingFood(axios, typefood){
      return axios.get('api/foods/OutstandingFood?typefood='+ typefood)
    },
    getfoodByID(axios, foodid){
      return axios.get('/api/foods/'+ foodid)
    },   
    getBill(axios){
      return axios.get('/api/Bills/Admin')
    },
    getComment(axios){
      return axios.get('/api/Comments')
    },
    getBillDetail(axios){
      return axios.get('/api/BillDetails')
    },

    getAbout(axios){
      return axios.get('/api/Abouts')
    },

    getCustomerSP(axios){
      return axios.get('/api/CustomerSPs')
    },    
    getUserAdmin(axios){
      return axios.get('/api/adminLogins')
    },
    addfood(axios, data){

      const url = `/api/foods`
      return axios.$post(url, data)
    },  
    addMenu(axios, data){

      const url = `/api/menus`
      return axios.$post(url, data)
    },  

    addNews(axios, data){

      const url = `/api/News`
      return axios.$post(url, data)
    },  
   
    addSlider(axios, data){

      const url = `/api/Sliders`
      return axios.$post(url, data)
    },
    addAbout(axios, data){

      const url = `/api/Abouts`
      return axios.$post(url, data)
    },

    addCustomerSP(axios, data){

      const url = `/api/CustomerSPs`
      return axios.$post(url, data)
    }, 

    register(axios, data){

      const url = `/api/Customers`
      return axios.$post(url, data)
    }
    
  }