<template>
  <div class="container">
      <div class="container">
      <div class="py-1 text-center">
        <h2 class="Title">Đơn Hàng</h2>
        <p class="lead">Cảm ơn bạn đã đặt hàng.</p>
     </div>

   <div class="row cart "  >
    <div class="col-md-12 order-md-12 mb-12">
      <h4 class="d-flex justify-content-between align-items-center mb-3">
        <span class="text-muted">Đơn Hàng</span>
      </h4>
      <table class="table" >
        <thead>
          <tr >
            <th scope="col">Mã Đơn hàng</th>
            <th scope="col">Tên Khách Hàng</th>
            <th scope="col">Số Điện thoại</th>
            <th scope="col">Địa chỉ</th>
            <th scope="col">Ngày đặt</th>
            <th scope="col">Tình trạng</th>
          </tr>
        </thead>
        <tbody >
          <tr v-for="(listBill, index) in listBill" :key="index" >
            <th scope="row">{{index + 1}}</th>
            <td>{{listBill.customer}}</td>    
            <td>{{listBill.phonenumber}}</td>
            <td>{{listBill.address}}</td>
            <td>{{listBill.dayOrder.toLocaleString('en-GB', { timeZone: 'UTC' })}}</td>
            <td v-if="listBill.status === 0"><button class="btn btn-secondary"><a :href="geturlDetailBill(listBill.billId)">Chờ xác nhận</a></button></td>
            <td v-if="listBill.status === 1"><button class="btn btn-warning"><a :href="geturlDetailBill(listBill.billId)">Đang giao hàng</a></button></td>
            <td v-if="listBill.status === 2"><button class="btn btn-success"><a :href="geturlDetailBill(listBill.billId)">Thành công</a></button></td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
    </div>  
  </div>
</template>
<script>
import Apidata from '@/api/Apidata'
  export default {
     data() {
    return {
      listBill: [],
    }
  },
  async created() {
    await this.getBill()
  },
  mounted() {

  },
  methods: {
   async getBill() {
      try {
        const { data } = await Apidata.getBill(this.$axios)
        console.log(data)
        this.listBill = data
      } catch (err) {
        console.log(err)
      }
    },

           geturlDetailBill(BillDetailID)
    {
      const url ='/OderDetail/' + BillDetailID;
      return url;
    }


  },

  }
</script>
<style scoped>

*{
  font-family: Verdana, Geneva, Tahoma, sans-serif;
}

.container{
  background: #fff;
  height: 700px;
}
.cart{
  height: 500px;

  position:relative
}
.Title{
  padding: 15px;
}
</style>