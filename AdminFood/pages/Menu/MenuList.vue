<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text="Quản lý Danh Mục  " right-alignment>
          <b-dropdown-item href="/Menu/addMenu" >Thêm Danh Mục</b-dropdown-item>
          <b-dropdown-item href="/Menu/MenuList">Danh sách Danh Mục</b-dropdown-item>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-scroller"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <div class="title">
      <h5>Danh sách Danh Mục</h5>
    </div>
    <table class="table">
    <thead>
        <tr>
        <th scope="col">#</th>
        <th scope="col">Tên Danh mục</th>
        <th scope="col">Hình ảnh</th>
        <th scope="col"></th>
        </tr>
    </thead>
    <tbody >  
         <tr v-for="(listmenu,index) in listmenu" :key="index">
               <th  scope="row">MN00{{ (index + 1) }}</th>
               <td>{{ listmenu.menuname }}</td>
                <td> <img :src="listmenu.menuavata" class="bd-placeholder-img card-img-top" alt="" width="100" height="200" /></td>
               <td>
              <a                  
                  type="button" 
                  class="btn btn-danger"             
                         v-on:click="DeletaMenu(listmenu.menuid)">     
                  Xóa
              </a>  
              <a type="button" class="btn btn-success" :href="geturlUpdataMenu(listmenu.menuid)">Edit</a>     
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
    middleware: [
    'isAuthorize',
    // 'isAdmin'
  ],
      layout: 'LayoutsAdmin',
     data() {
    return {
      listmenu: [],
    }
  },
  async created() {
    await this.getmenu()
  },
  mounted() {

  },
  methods: {
     async getmenu() {
      try {
        const { data } = await Apidata.getmenu(this.$axios)
        console.log(data)
        this.listmenu = data

      } catch (err) {
        console.log(err)
      }
    },
   
  DeletaMenu(id)
  {
      this.$axios.delete(`/api/menus/` + id).then(() =>
      {
          this.getmenu()
      })
  },
      geturlUpdataMenu(Menueditid)
    {
      const url ='/MenuEdit/' + Menueditid;
      return url;
    }


  },


   
  }
</script>
<style>
.title{
    text-align: center;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
}
h5{
  font-weight: 700;
}
</style>

