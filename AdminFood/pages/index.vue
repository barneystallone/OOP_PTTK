<template>
<div class="container">
<div>
  <h1>Thống Kê</h1>
</div>
    <div class="row">
          
        <div class="col-md-4 col-xl-3">
            <div class="card bg-c-blue order-card">
                <div class="card-block">
                    <h6 class="m-b-20">Đơn Hàng</h6>
                    <h2 class="text-right"><i class="fa fa-cart-plus f-left"></i><span>{{CountBill}}</span></h2>
                    <p class="m-b-0"><a href="/Bill/BillList">Chi tiết</a><span  class="f-right"></span></p>
                </div>
            </div>
        </div>
        
        <div class="col-md-4 col-xl-3">
            <div class="card bg-c-green order-card">
                <div class="card-block">
                    <h6 class="m-b-20">Khách Hàng</h6>
                    <h2 class="text-right"><i class="fa fa-rocket f-left"></i><span>{{CountCustomer}}</span></h2>
                    <p class="m-b-0"><a href="/Customer/CustomerList">Chi tiết</a><span class="f-right"></span></p>
                </div>
            </div>
        </div>
        
        <div class="col-md-4 col-xl-3">
            <div class="card bg-c-yellow order-card">
                <div class="card-block">
                    <h6 class="m-b-20">Món Ăn</h6>
                    <h2 class="text-right"><i class="fa fa-refresh f-left"></i><span>{{CountFood}}</span></h2>
                    <p class="m-b-0"><a href="/Foods/ListFood">Chi tiết</a><span class="f-right"></span></p>
                </div>
            </div>
        </div>
        
        <div class="col-md-4 col-xl-3">
            <div class="card bg-c-pink order-card">
                <div class="card-block">
                    <h6 class="m-b-20">Doanh thu</h6>
                    <h2 class="text-right"><i class="fa fa-credit-card f-left"></i><span>{{CountAllPrice.toLocaleString()}}</span></h2>
                    <p class="m-b-0"><a href="">Chi tiết</a><span class="f-right"></span></p>
                </div>
            </div>
        </div>
	</div>
</div>
</template>
<script>
import Apidata from '@/api/Apidata'
export default {
middleware: [
    'isAuthorize',
    // 'isAdmin'
  ],
     layout: 'LayoutsAdmin',
     data() {
   return{
      listBill: [],
      listCustomer: [],
      listFood: [],
      listAllPrice: [],
   }
 }, 

  computed: {
    CountBill(){
            let CountBill = 0;
      for( let i=0; i < this.listBill.length; i++){
        CountBill += 1;
      }
      return CountBill;
    },
        CountCustomer(){
            let CountCustomer = 0;
      for( let i=0; i < this.listCustomer.length; i++){
        CountCustomer += 1;
      }
      return CountCustomer;
    },
        CountFood(){
            let CountFood = 0;
      for( let i=0; i < this.listFood.length; i++){
        CountFood += 1;
      }
      return CountFood;
    },
        CountAllPrice(){
            let CountAllPrice = 0;
      for( let i=0; i < this.listAllPrice.length; i++){
        CountAllPrice += this.listAllPrice[i].allprice;
      }
      return CountAllPrice;
    }
  },

  async created() {
    await this.getBill()
    await this.getCustomer()
    await this.getFood()
    await this.getBillDetail()
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

        async getCustomer() {
      try {
        const { data } = await Apidata.getcustomer(this.$axios)
        console.log(data)

        this.listCustomer = data
      } catch (err) {
        console.log(err)
      }
    },

        async getFood() {
      try {
        const { data } = await Apidata.getfood(this.$axios)
        console.log(data)

        this.listFood = data
      } catch (err) {
        console.log(err)
      }
    },

            async getBillDetail() {
      try {
        const { data } = await Apidata.getBillDetail(this.$axios)
        console.log(data)

        this.listAllPrice = data
      } catch (err) {
        console.log(err)
      }
    },

  }
}
</script>
<style>
h1{
  margin: 20px;
  text-align: center;
  padding-top: 30px;
}
body{
   
    background:#fff;
}
.order-card {
    color: #fff;
}

.bg-c-blue {
    background: linear-gradient(45deg,#0fe72f,#abe017);
}

.bg-c-green {
    background: linear-gradient(45deg,#f58f0b,#dbb407);
}

.bg-c-yellow {
    background: linear-gradient(45deg,#08cc08,#0ef13fa1);
}

.bg-c-pink {
    background: linear-gradient(45deg,#e2f106,#07cad8);
}


.card {
    border-radius: 5px;
    -webkit-box-shadow: 0 1px 2.94px 0.06px rgba(4,26,55,0.16);
    box-shadow: 0 1px 2.94px 0.06px rgba(4,26,55,0.16);
    border: none;
    margin-bottom: 30px;
    -webkit-transition: all 0.3s ease-in-out;
    transition: all 0.3s ease-in-out;
    margin-top: 50px;
}

.card .card-block {
    margin-top: 30px;
    padding: 25px;
}

.order-card i {
    font-size: 26px;
}

.f-left {
    float: left;
}

.f-right {
    float: right;
}
</style>