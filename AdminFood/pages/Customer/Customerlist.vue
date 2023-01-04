<template>
  <div >
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text="Khách Hàng  " right-alignment>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-scroller"
        ref="content"
        style="position:relative; overflow-y:scroll; height: 450px;"
      >
     <div class="title">
       <h5>Danh sách khách hàng</h5>
    </div>
    <table class="table">
    <thead>
        <tr>
        <th scope="col">#</th>
        <th scope="col">Tên Khách Hàng</th>
        <th scope="col">Email</th>
        <th scope="col">Số điện thoại </th>
        <th scope="col">Mật khẩu </th>
        <th scope="col"></th>
        </tr>
    </thead>
    <tbody >  
         <tr v-for="(listCustomer,index) in listCustomer" :key="index">
               <th  scope="row">KH00{{ (index + 1) }}</th>
               <td>{{ listCustomer.customername }}</td>
               <td>{{ listCustomer.customeremail }}</td>
               <td>{{ listCustomer.customernuber }}</td>
               <td >{{ listCustomer.customerpassword }}</td>
               <td>
              <button                   
                  type="button" 
                  class="btn btn-danger"
                  style=" 
                      border: none;
                      color: white;
                      padding: 15px 20px;
                      text-align: center;
                      text-decoration: none;
                      display: inline-block;
                      font-size: 15px;
                      margin: 4px 2px;
                      cursor: pointer;;"
                         v-on:click="DeletaCustomer(listCustomer.customerid)">
                   
                  Xóa
              </button>    
                </td>
        </tr>             
    </tbody>
    </table>
      </b-card-body>
    </b-card>
  </div>
</template>
<script>
import Apidata from '@/api/Apidata'
  export default {
     layout: 'LayoutsAdmin',
     middleware: [
    'isAuthorize',
  ],
     data() {
    return {
      listCustomer: [],
    }
  },
  async created() {
    await this.getCustomer()
  },
  mounted() {

  },
  methods: {
    async getCustomer() {
      try {
        const { data } = await Apidata.getcustomer(this.$axios)
        console.log(data)

        this.listCustomer = data
      } catch (err) {
        console.log(err)
      }
    },

 DeletaCustomer(id)
  {
        const choice = confirm("Bạn muốn xóa không?");
    if (choice === true) {
      this.$axios.delete(`/api/Customers/` + id).then(() =>
      {
          this.getCustomer()
      })
    }else{
        this.$router.push(`/Customer/Customerlist`)
    }
  }
  }, 
  }
</script>
<style>
 .title{
    text-align: center;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
}
h5{
  font-weight: 700;
}
</style>
