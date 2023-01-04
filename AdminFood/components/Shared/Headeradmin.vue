

<template>

<div>
  <header>
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet">
</header>
  <b-navbar toggleable="lg" type="dark" variant="info" style="background: linear-gradient(to right, #0bc539, #eef110) !important" >
    <b-navbar-brand href="/">Trang chủ</b-navbar-brand>
    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
    <b-collapse id="nav-collapse" is-nav>
         <b-navbar-brand href="/Foods/ListFood">Món Ăn  </b-navbar-brand>
         <b-navbar-brand href="/Menu/MenuList">Danh Mục  </b-navbar-brand>
         <b-navbar-brand href="/New/NewList">Tin Tức  </b-navbar-brand>
         <b-navbar-brand href="/Customer/Customerlist">Khách hàng  </b-navbar-brand>
         <b-navbar-brand href="/CustomerSP/CustomerSPlist">Yêu cầu hỗ trợ </b-navbar-brand>
         <b-navbar-brand href="/Slider/SliderList">Quảng cáo  </b-navbar-brand>
      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">
        <b-nav-item-dropdown text="ADMIN" v-for="(listAdmin,index) in listAdmin" :key="index" right>
          <b-dropdown-item href="#">Xin chào: {{listAdmin.userName}}</b-dropdown-item>
          <b-dropdown-item href="#">***</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</div>
</template>
<script>
import Apidata from '@/api/Apidata'
  export default {
     data() {
    return {
      listAdmin: [],
    }
  },
  async created() {
    await this.getUserAdmin()
  },
  mounted() {

  },
  methods: {
    async getUserAdmin() {
      try {
        const { data } = await Apidata.getUserAdmin(this.$axios)
        console.log(data)

        this.listAdmin = data
      } catch (err) {
        console.log(err)
      }
    },


  },

  }
</script>

    <style>

    </style>