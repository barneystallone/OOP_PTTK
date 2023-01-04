<template>
    <div class="container">
      <div class="py-1 text-center">
        <h2 class="Title">Invoice details</h2>
        <p class="lead">Thank you for your order.</p>
     </div>
   <div class="row cart">
    <div class="col-md-12 order-md-12 mb-12">
      <h4 class="d-flex justify-content-between align-items-center mb-3">
        <span class="text-muted">bill</span>
        <span class="badge badge-secondary badge-pill">{{countCart}}</span>
      </h4>
      <table class="table">
        <thead>
          <tr >
            <th scope="col">Mã Hóa Đơn</th>
            <th scope="col">Tên Món Ăn</th>
            <th scope="col">Giá</th>
            <th scope="col">Số Lượng</th>
            <th scope="col">Tổng</th>
          </tr>
        </thead>
        <tbody>
         <tr v-for="(BillDetail,index) in BillDetail" :key="index">
               <th> MHD00{{index + 1}}</th>
               <td>{{ BillDetail.foodname}}</td>
               <td>{{ BillDetail.foodprice.toLocaleString()  }} VNĐ</td>
               <td>{{  BillDetail.quantity }}</td>
               <td><a >{{ BillDetail.allprice.toLocaleString() }} VNĐ</a></td>
        </tr> 
        </tbody>
      </table>
      <ul class="list-group mb-3">
        <li class="list-group-item d-flex justify-content-between">
          <span>Total (VNĐ)</span>
          <strong>{{total.toLocaleString()}} VNĐ</strong>
        </li>
      </ul>
    </div>
  </div>
 
  </div>
</template>
<script>
export default {
    layout: 'LayoutsAdmin',
      computed: {
    total()
    {
      let total = 0;
      for( let i=0; i < this.BillDetail.length; i++){
        total += this.BillDetail[i].allprice;


      }
      return total;
    },
  },

    methods: {
    },

async asyncData({ $axios,params}) {
        const BillDetail = await $axios.$get(`/api/BillDetails/BillDetail?BillId=${params.BillDetailID}`)
        console.log(BillDetail)

        return { BillDetail }
    },
}

</script>
<style scoped >
*{
  font-family: Verdana, Geneva, Tahoma, sans-serif;
}
.cart{
  height: 500px;
}
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
</style>