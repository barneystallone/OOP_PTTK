<template>
    <div class="container">
          <div class="tile">
               <h4>THÔNG TIN TÀI KHOẢN</h4>
          </div>
        
           <table class="table">
        <tbody v-for="(listCustomer, index) in listCustomer" :key="index">
          <tr>
            <th scope="row">Tên tài khoản :</th>
            <td>{{listCustomer.customername}}</td>
          </tr>
          <tr>
            <th scope="row">Email :</th>
            <td>{{listCustomer.customeremail}}</td>
          </tr>
          <tr>
            <th scope="row">Số điện thoại :</th>
            <td>{{listCustomer.customernuber}}</td>
          </tr>
          <tr>
            <th scope="row">Mật khẩu :</th>
            <td  >(****)  <a  onclick="alert('Chức năng đang được cập nhật vui long thủ lại sau!')" href="">Đổi mật khẩu</a> </td>
          </tr>
        </tbody>
      </table>

    </div>
</template>
<script>
import Apidata from '@/api/Apidata'
  export default {
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
        const { data } = await Apidata.getCustomer(this.$axios)
        console.log(data)
        this.listCustomer = data
      } catch (err) {
        console.log(err)
      }
    },
  },

  }
</script>
<style scoped>

*{
  font-family: Verdana, Geneva, Tahoma, sans-serif;
}

.container{
  background: #fff;
  height: 550px;
}
.cart{
  height: 500px;
}
.tile{
  padding-top: 55px;
   padding-bottom: 15px;
}
.table{
    border: 1px solid rgb(226, 213, 213);
    height: 250px;
}
tr:hover {
  background: rgb(195, 218, 228);
}
</style>