<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text="Quản lý tin tức" right-alignment>
          <b-dropdown-item href="/New/addNew" >Thêm tin tức</b-dropdown-item>
          <b-dropdown-item href="/New/NewList">Danh sách tin tức</b-dropdown-item>
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
        <th scope="col">Tên Danh mục</th>
        <th scope="col">Hình ảnh</th>
        <th scope="col"></th>
        </tr>
    </thead>
    <tbody >  
         <tr v-for="(listnews,index) in listnews" :key="index">
               <th  scope="row">TT00{{ (index + 1) }}</th>
               <td>{{ listnews.newsname }}</td>
                <td> <img :src="listnews.newsavata" class="bd-placeholder-img card-img-top" alt="" width="300px" height="300" /></td>
                <td>{{ listnews.descriptions}}</td>
               <td>
              <a                   
                  type="button" 
                  class="btn btn-danger"
                         v-on:click="  DeletaNew(listnews.newsid)">                  
                  Xóa
              </a> 
              <a type="button" class="btn btn-success" :href="geturlUpdataNews(listnews.newsid)">Edit</a>     
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
  ],
    layout: 'LayoutsAdmin',
     data() {
    return {
      listnews: [],
    }
  },
  async created() {
    await this.getnews()
  },
  mounted() {

  },
  methods: {
  async getnews() {
      try {
        const { data } = await Apidata.getnews(this.$axios)
        console.log(data)
       this.listnews = data
       
      } catch (err) {
        console.log(err)
      }
    },
  DeletaNew(id)
  {
      this.$axios.delete(`/api/News/` + id).then(() =>
      {
          this.getnews()
      })
  }, 
    geturlUpdataNews(NewEditID)
    {
      const url ='/NewEdit/' + NewEditID;
      return url;
    }


  },
 
  }
</script>

<style>
td{
    max-width: 250px;
}
.title{
    text-align: center;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
}
h5{
  font-weight: 700;
}
</style>