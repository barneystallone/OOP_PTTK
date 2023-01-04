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
      return axios.get('/api/Customers')
    },
    getfoodbymenuyid(axios, menuyID){
      return axios.get('/api/foods/viaCateId?MenuyId='+ menuyID)
    },
    GetOutstandingFood(axios, typefood){
      return axios.get('api/foods/OutstandingFood?typefood='+ typefood)
    },

    GetComment(axios, foodid){
      return axios.get('/api/Comments/comments?foodid='+ foodid)
    },



    GetSliderHot(axios, slidetype){
      return axios.get('/api/Sliders/SliderHot?slidetype='+ slidetype)
    },

    
    GetBillDetailID(axios, billId){
      return axios.get('/api/BillDetails/'+ billId)
    },

    getfoodByID(axios, foodid){
      return axios.get('/api/foods/'+ foodid)
    },
    
    getCustomerSP(axios){
      return axios.get('/api/CustomerSPs')
    },
    
    getCustomer(axios){
      return axios.get('/api/Customers')
    },
    getSlider(axios){
      return axios.get('/api/Sliders')
    },

    getAbout(axios){
      return axios.get('/api/Abouts')
    },

    getcart(axios){
      return axios.get('/api/Carts')
    },

    getBill(axios){
      return axios.get('/api/Bills')
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
   
    addCustomerSP(axios, data){

      const url = `/api/CustomerSPs`
      return axios.$post(url, data)
    }, 

    addComment(axios, data){

      const url = `/api/Comments`
      return axios.$post(url, data)
    },

    addBill(axios, data){

      const url = `/api/Bills`
      return axios.$post(url, data)
    }, 

    addBillDetail(axios, data){

      const url = `/api/BillDetails`
      return axios.$post(url, data)
    }, 

    register(axios, data){

      const url = `/api/Customers`
      return axios.$post(url, data, Response)
    
    },
    
    searchData(axios,nameData){
      return axios.get(`/api/foods/search/${nameData}`)
  },
  }