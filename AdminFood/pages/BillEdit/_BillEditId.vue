<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text="Quản lý đơn hàng" right-alignment>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
     <div class="title">
       <h5>Update đơn hàng</h5>
     </div>
      <ValidationObserver v-slot="{ handleSubmit }">
      <form action="" @submit.prevent="handleSubmit(UpdateBill(Bill))">
        
    
        <div class="form-group">
          <label for="">Tên Khách hàng</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh  "
          >
          <input v-model="Bill.customer" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
          
           <div class="form-group">
          <label for="">Địa chỉ</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh  "
          >
          <input v-model="Bill.phonenumber" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>

          <div class="form-group">
           <label for="">Địa chỉ</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh  "
          >
          <input v-model="Bill.address" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>

        <div class="form-group">
          <label for="">Tình trạng</label>
          <select v-model="Bill.status"  name="" class="form-control">
           <option  value="0"> Đang xác nhận </option>
           <option  value="1"> Đang giao hàng</option>
           <option  value="2"> Thành công </option>
          </select>     
        </div> 

        <button type="submit" class="btn btn-primary">Lưu</button>
        <button type="reset" class="btn btn-outline-primary">Nhập lại</button>
      </form>
    </ValidationObserver>
      </b-card-body >
    </b-card>
  </div>
</template>
<script>
export default {
    layout: 'LayoutsAdmin',
  data() {
    return {
        Bill: {
          billId: "",
          customer: "",
          phonenumber: "",
          address: "",
          status: 0,
        }

    }
  },
  async created() {
  
  },
  methods: {
        async UpdateBill(Bill) {
            try {
            await this.$axios.put('/api/Bills/' + Bill.billId, {
               billId: Bill.billId,
               customer: Bill.customer,
               phonenumber: Bill.phonenumber,
               address: Bill.address,
               customerid: Bill.customerid,
               status: Bill.status,

            })
            alert("Cập nhật thành công")
            this.$router.push('/Bill/BillList')
            } 
            catch (err) {
            console.log(err)
            }
        },

  },
async asyncData({ $axios,params}) {
        const Bill = await $axios.$get(`/api/Bills/${params.BillEditId}`)
        console.log(Bill)
        return { Bill }
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

  h5{
    font-weight: 700;
  }

</style>