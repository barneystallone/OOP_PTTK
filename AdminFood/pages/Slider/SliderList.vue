<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text="Quản lý Slider" right-alignment>
          <b-dropdown-item href="/Slider/SliderAdd" >Thêm Slider </b-dropdown-item>
          <b-dropdown-item href="/Slider/SliderList">Danh sách Slider </b-dropdown-item>
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
        <th scope="col">Tên Tin Tức</th>
        <th scope="col">Hình ảnh</th>
        <th scope="col">Mô Tả</th>
        <th scope="col">Trạng Thái</th>
        <th scope="col"></th>
        </tr>
    </thead>
    <tbody >  
         <tr v-for="(listSlider,index) in listSlider" :key="index">
               <th  scope="row">SL00{{ (index + 1) }}</th>
               <td>{{ listSlider.slidetitle }}</td>
                <td> <img :src="listSlider.slideimg" class="bd-placeholder-img card-img-top" alt="" width="300px" height="300" /></td>
                <td>{{ listSlider.slidedescription}}</td>
                 <td v-if="listSlider.slidetype === 1"><a type="button" class="btn btn-success" > Bật </a>   </td>
                 <td v-else><a type="button" class="btn btn-danger" > Tắt </a>   </td>
               <td>
              <a type="button" class="btn btn-danger" v-on:click="  DeletaSlider(listSlider.slideid)"> Xóa </a> 
              <a type="button" class="btn btn-success"  :href="geturlUpdataSlider(listSlider.slideid)"> Edit </a>     
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
      listSlider: [],
    }
  },
  async created() {
    await this.getSlider()
  },
  mounted() {

  },
  methods: {
  async getSlider() {
      try {
        const { data } = await Apidata.getSlider(this.$axios)
        console.log(data)
       this.listSlider = data
       
      } catch (err) {
        console.log(err)
      }
    },
   
  DeletaSlider(id)
  {
      this.$axios.delete(`/api/Sliders/` + id).then(() =>
      {
          this.getSlider()
      })
  },

   
    geturlUpdataSlider(SliderEditID)
    {
      const url ='/SliderEdit/' + SliderEditID;
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