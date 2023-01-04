<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text="Khách hàng hỗ trợ " right-alignment>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-scroller"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
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
        <th scope="col">Message </th>
        <th scope="col"></th>
        </tr>
    </thead>
    <tbody >  
         <tr v-for="(listCustomerSP,index) in listCustomerSP" :key="index">
               <th  scope="row">KHS00{{ (index + 1) }}</th>
               <td>{{ listCustomerSP.customerSPname }}</td>
               <td>{{ listCustomerSP.customerSPemail }}</td>
               <td>{{ listCustomerSP.customerSPDescriptions }}</td>
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
                         v-on:click="DeleteCustomerSP(listCustomerSP.customerSPid)">
                   
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
     data() {
    return {
      listCustomerSP: [],
    }
  },
  async created() {
    await this.CustomerSP()
  },
  mounted() {

  },
  methods: {
    async CustomerSP() {
      try {
        const { data } = await Apidata.getCustomerSP(this.$axios)
        console.log(data)

        this.listCustomerSP = data
      } catch (err) {
        console.log(err)
      }
    },

  DeleteCustomerSP(id)
  {
      this.$axios.delete(`/api/CustomerSPs/` + id).then(() =>
      {
          this.CustomerSP()
      })
  }
  },

  }
</script>
<style >
  .title{
    text-align: center;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
  }
  h5{
  font-weight: 700;
  }
</style>
