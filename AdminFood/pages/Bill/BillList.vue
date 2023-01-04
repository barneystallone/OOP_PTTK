<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>

      </b-nav>
      <b-card-body
        id="nav-scroller"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <div class="title">
         <h5>Danh sách hóa đơn</h5>
    </div>
    <table class="table">
    <thead>
        <tr>
        <th scope="col">#</th>
        <th scope="col">Tên khách Hàng</th>
        <th scope="col">Số điện thoại</th> 
        <th scope="col">Địa chỉ</th> 
        <th scope="col">Ngày đặt</th>
        <th scope="col">Trạng thái</th>
        <th scope="col"></th>
        </tr>
    </thead>
    <tbody >  
         <tr v-for="(listBill,index) in listBill" :key="index">
               <th  scope="row">HD00{{ (index + 1) }}</th>
               <td>{{ listBill.customer }}</td>
               <td>{{ listBill.phonenumber }}</td>
               <td>{{ listBill.address }}</td>
               <td>{{listBill.dayOrder.toLocaleString('en-GB', { timeZone: 'UTC' })}}</td>
               <td v-if="listBill.status === 0"><button class="btn btn-secondary"><a :href="geturlDetailBill(listBill.billId)">Chờ xác nhận</a></button></td>
               <td v-if="listBill.status === 1"><button class="btn btn-danger"><a :href="geturlDetailBill(listBill.billId)">Đang giao hàng</a></button></td>
               <td v-if="listBill.status === 2"><button class="btn btn-success"> <a :href="geturlDetailBill(listBill.billId)">Thành công</a></button></td>         
               <td>
                    <a                  
                      type="button" 
                      class="btn btn-danger"             
                      v-on:click="DeleteBill(listBill.billId)"
                    >     
                      Xóa
                    </a>  
                    <a type="button" class="btn btn-success" 
                    :href="geturlUpdataBill(listBill.billId)"
                    >Edit
                    </a>  
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
  DeleteBill(id)
  {
      this.$axios.delete(`/api/Bills/` + id).then(() =>
      {
          this.getBill()
      })
  },
    geturlDetailBill(BillDetailID)
    {
      const url ='/BillDetail/' + BillDetailID;
      return url;
    },

     geturlUpdataBill(BillEditId)
    {
      const url ='/BillEdit/' + BillEditId;
      return url;
    }
  },
  }
</script>
<style scoped>
  .btn{
      margin-bottom: 10px;
  }
  .title{
      text-align: center;
      font-family: Verdana, Geneva, Tahoma, sans-serif;
      font-size: 15px;
  }
  h5{
    font-weight: 700;
  }
</style>
