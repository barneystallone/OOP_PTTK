<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
      </b-nav>
      <b-card-body
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <div class="title">
      <h5>Chi tiết hóa đơn</h5>
    </div>          
      <table class="table">
        <thead>
            <tr>
            <th scope="col" >#</th>
            <th scope="col" >Tên Món ăn</th>
            <th scope="col" >Giá</th>
            <th scope="col" >Số Lượng</th>
            <th scope="col" >Tổng</th>
            <th ></th>
            </tr>
        </thead>
        <tbody >  
            <tr v-for="(BillDetail,index) in BillDetail" :key="index">
                  <th>HDC00{{(index+1)}}</th>
                  <td>{{ BillDetail.foodname}}</td>
                  <td>{{ BillDetail.foodprice.toLocaleString() }} VNĐ</td>
                  <td>{{  BillDetail.quantity }}</td>
                  <td>{{ BillDetail.allprice.toLocaleString()}} VNĐ</td>
                  <td>
                  <a                  
                      type="button" 
                      class="btn btn-danger" 
                        v-on:click="DeleteBillDetail(BillDetail.biDid)"            
                  >     
                      Xóa
                  </a>  
                    </td>
            </tr>             
        </tbody>
      </table>      
    </b-card-body >
    </b-card>
  </div>
</template>
<script>
export default {
  layout: 'LayoutsAdmin',
  methods: {
        DeleteBillDetail(id)
       {
        this.$axios.delete(`/api/BillDetails/` + id)
        alert("Xóa Chi tiết đơn hàng thành công")
        this.$router.push('/Bill/BillList')
      },
    }, 
 async asyncData({ $axios,params}) {
        const BillDetail = await $axios.$get(`/api/BillDetails/BillDetail?BillId=${params.BillDetailID}`)
        console.log(BillDetail)

        return { BillDetail }
    },
}
</script>
<style >
  label{
    min-width: 100%;
    padding: 0 20px;
  }
  input{
  margin: 0 16px;
  min-width: 800px;
  }
  select{
  margin: 0 16px;
  max-width: 830px;
  }
  textarea{
    margin: 0 16px;
    max-width: 830px;
  }
  #scroller{
    padding: 0 50px;
  }
  .title
  {
    text-align: center;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
   }
   h5
   {
     
    font-weight: 700;
   }
</style>