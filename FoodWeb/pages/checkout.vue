<template>
    <div class="container">
      <div class="py-1 text-center">
        <h2 class="Title">Giỏ hàng</h2>
        <p class="lead">Cảm ơn khách hàng đã tin tưởng.</p>
        <!-- <p class="lead">Current Date & Time: </p> -->
     </div>
   <div class="row cart">
    <div class="col-md-12 order-md-12 mb-12">
      <h4 class="d-flex justify-content-between align-items-center mb-3">
        <span class="text-muted">Giỏ hàng</span>
        <span class="badge badge-secondary badge-pill">{{countCart}}</span>
      </h4>
      <table class="table">
        <thead>
          <tr >
            <th scope="col">#</th>
            <th scope="col">Tên Món Ăn</th>
            <th scope="col">Hình ảnh</th>
            <th scope="col">Giá</th>
            <th scope="col">SỐ LƯỢNG</th>
            <th scope="col">Tổng</th>
            <th scope="col">*</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(listCart, index) in listCart" :key="index">
            <th scope="row">{{index + 1}}</th>
            <td>{{listCart.foodname}}</td>
            <td  >             
              <img height="100px" :src="listCart.foodimghp"  alt="" />             
            </td>      
            <td>{{listCart.foodprice.toLocaleString()}} VNĐ</td>
            <td>{{listCart.cartquantity}}</td>
            <td>{{listCart.allprice.toLocaleString()}} VNĐ</td>
            <td>
              <a
               v-on:click="DeletaCart(listCart.cartid)"
               type="button" class="btn btn-danger"        
            >xóa</a>
            </td>
          </tr>
        </tbody>
      </table>
      <ul class="list-group mb-3">
        <li class="list-group-item d-flex justify-content-between">
          <span>Tổng (VNĐ)</span>
          <strong>{{total.toLocaleString()}} VNĐ</strong>
        </li>
      </ul>
    </div>
  </div>
 <div class="row"  v-if="isUser">
    <div class="col-md-8 order-md-1">
      <h4 style="text-align: center;" class="mb-3" >Thông tin thanh toán</h4>
      <form class="needs-validation" @submit.prevent="AddOder">      
        <div class="mb-3">
          <label for="username">Địa chỉ:</label>
          <div class="input-group">
            <div class="input-group-prepend">
            </div>
            <input v-model="Address"
            type="text" class="form-control" 
            id="Address" placeholder="Mời nhập địa chỉ" required>
 
          </div>
        </div>       
        <hr class="mb-4">
        <button class="btn btn-primary btn-lg btn-block " type="submit">Đặt hàng</button>
      </form>
    </div>
  </div>
   <div class="row" v-else >
    <div class="col-md-8 order-md-1">
     
      <form class="needs-validation">          
        <hr class="mb-4">
        <button class="btn btn-primary btn-lg btn-block " type="submit"  onclick="alert(' Vui lòng Đăng nhập để thanh toán !')" >Đặt hàng</button>
      </form>
    </div>
  </div>
  </div>
</template>
<script>
import { mapGetters } from 'vuex'
import Apidata from '@/api/Apidata'
export default {
data() {
  return {
    Address: '',
    Quantity: '',
    listCart: [],
    listBill: [],
    Allprice: '',
    listCustomer: [],
    
  }
  },
async created() {
  await this.getCart()
  await this.getBill()
  await this.getCustomer()
},
mounted() {

},
computed: {

     ...mapGetters({
      isUser: 'user/isUser',
      isView: 'user/isView',
    }),
  total()
  {
    let total = 0;
    for( let i=0; i < this.listCart.length; i++){
    total += this.listCart[i].allprice
  }
  return total;
  },
countCart(){
  let countCart = 0;
  for( let i=0; i < this.listCart.length; i++){
    countCart += 1;


  }
  return countCart;
  },
  //  DateTime(){
  //    const today = new Date()
  //    return today;
  //  }
},
methods: {
  async getCustomer() {
    try {
      const { data } = await Apidata.getCustomer(this.$axios)
      console.log(data)
      this.listCustomer = data
    } 
    catch (err) {
      console.log(err)
    }
  },
  async getCart() {
    try {
      const { data } = await Apidata.getcart(this.$axios)
      console.log(data)
      this.listCart = data
    } catch (err) {
     console.log(err)
    }
  },

  async getBill() {
    try {
      const { data } = await Apidata.listBill(this.$axios)
      console.log(data)
      this.listBill = data
    } 
    catch (err) {
      console.log(err)
    }
  },

  DeletaCart(id){
    this.$axios.delete(`/api/Carts/` + id).then(() =>
    {
      this.getCart()

    })
    this.$router.push(`/checkout`)
  },
  async AddOder() {      
    
    if( this.countCart === 0  ) {  
        alert("Giỏ hàng trống ! Vui lòng đặt Món để thanh toán!")
    }
    else{
    try {   
      
      for( let  i=0; i< this.listCustomer.length; i++)
      {         
      await this.$axios.post('/api/Bills', {
        customer: this.listCustomer[i].customername,
        phonenumber: this.listCustomer[i].customernuber,
        address: this.Address,
   
        customerid: this.listCustomer[i].customerid,
        status: 0,
      }
      )
      }
      const { data }= await Apidata.getBill(this.$axios)
      this.listBill = data
      console.log(data)
      const tmp = this.listBill[this.listBill.length - 1].billId
      for( let  i=0; i< this.listCart.length; i++)
      {
        await this.$axios.post('/api/BillDetails', {
          foodname: this.listCart[i].foodname,
          foodprice: this.listCart[i].foodprice,
          quantity: this.listCart[i].cartquantity,
          allprice: this.listCart[i].allprice,
          billId: tmp,                               
        })
        await  this.$axios.delete(`/api/Carts/` + this.listCart[i].cartid)
      } 
      alert("Đặt hàng thành công. Cám ơn bạn đã sử dụng dịch vụ!")
      this.$router.push(`/OrderSuccess`)
    } 
    catch (e) {
      this.error = e.response.data.messages
    }  
    }     
    },
  currentDateTime() {
    const current = new Date();
    const date = current.getFullYear()+'-'+(current.getMonth()+1)+'-'+current.getDate();
    const time = current.getHours() + ":" + current.getMinutes() + ":" + current.getSeconds();
    const dateTime = date +' '+ time;
  return dateTime;
  }
  }

}
</script>
<style  scoped>
.row{
  min-width: 800px;
  
}
.mb-3{
  min-width: 150vh !important;
  
}
.mb-4{
  min-width: 150vh !important;
}
button{
  width: 280px !important;
  text-align: center;
  margin:10px 350px !important;
  background: rgb(62, 216, 108) !important;
  border: 1px solid rgb(62, 216, 108) !important;
}
.text-center{
  padding-top: 40px !important;
}
</style>