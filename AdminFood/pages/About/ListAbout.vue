<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text="Giới thiệu" right-alignment>
           <b-dropdown-item href="/About/AddAbout" >Thêm giới thiệu</b-dropdown-item>
          <b-dropdown-item href="/About/ListAbout">Danh sach giới thiệu</b-dropdown-item>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-scroller"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <div class="title">
        <h5>Danh sách</h5>
    </div>
  
    <table class="table">
    <thead>
        <tr>
        <th scope="col">#</th>
        <th scope="col">Tiêu Đề</th>
        <th scope="col">Hình ảnh</th>
        <th scope="col">Mô tả</th>
        <th scope="col"></th>
        </tr>
    </thead>
    <tbody >  
         <tr v-for="(listAbout ,index) in listAbout" :key="index">
               <th  scope="row">GT00{{ (index + 1) }}</th>
               <td>{{ listAbout.abouttitle }}</td>
              <td 
               style="  width: 270px;"
               > <img :src="listAbout.aboutimg" class="bd-placeholder-img card-img-top" alt="" height="200"/></td>  
               <td>{{ listAbout.aboutDescriptions }}</td>
               <td>
              <a                  
                  type="button" 
                  class="btn btn-danger"             
                 v-on:click="DeleteAbout(listAbout.abouttid)" >     
                  Xóa
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
      listAbout: [],
    }
  },
  async created() {
    await this.getAbout()
  },
  mounted() {

  },
  methods: {
     async getAbout() {
      try {
        const { data } = await Apidata.getAbout(this.$axios)
        console.log(data)
        this.listAbout = data

      } catch (err) {
        console.log(err)
      }
    },
   
  DeleteAbout(id)
  {
      this.$axios.delete(`/api/Abouts/` + id).then(() =>
      {
          this.getAbout()
      })
  },
      geturlAbout(BillDetailID)
    {
      const url ='/BillDetail/' + BillDetailID;
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
}
h5{
  font-weight: 700;
}
</style>