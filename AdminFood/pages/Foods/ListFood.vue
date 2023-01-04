<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text="Quản lý Món Ăn  " right-alignment>
          <b-dropdown-item href="/Foods/FoodAdd" >Thêm Món Ăn</b-dropdown-item>
          <b-dropdown-item href="/Foods/ListFood">Danh sách Món Ăn</b-dropdown-item>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-scroller"
        ref="content"
        style="position:relative; overflow-y:scroll; height: 450px;"
      >
      <div class="title">
          <h5>Danh Sách Món Ăn</h5>
      </div>
    <!-- <h1>Danh sách</h1> -->
    <table class="table">
    <thead>
        <tr>
        <th scope="col">#</th>
        <th scope="col">Tên Món Ăn</th>
        <th scope="col">Menu</th>
        <th scope="col">Giá </th>
        <th scope="col">Hình ảnh </th>
        <th scope="col">Mô Tả </th>
        <th scope="col">Tình trạng</th>
        <th scope="col">loại</th>
        <th scope="col"></th>
        </tr>
    </thead>
    <tbody >  
         <tr v-for="(listFood,index) in listFood" :key="index">
               <th  scope="row">MA00{{ (index + 1) }}</th>
               <td>{{ listFood.foodname }}</td>
               <td >{{ listFood.menuyid }}</td>  
               <td >{{ listFood.foodprice.toLocaleString()}} VNĐ</td> 
               <td 
               style="  width: 270px;"
               > <img :src="listFood.foodimghp" class="bd-placeholder-img card-img-top" alt="" height="200"/></td>          
               <td>{{ listFood.foodDescriptions }}</td>
               <td  v-if="listFood.foodInStock > 0">Còn hàng</td>
               <td  v-else >Hết!</td>
               <td  v-if="listFood.typefood > 0">Nổi bật</td>
               <td  v-else >Không nổi bật!</td>
               <td>
              <a                        
                     type="button" class="btn btn-danger"
                     v-on:click="DeletaFood(listFood.foodid)">                
                  Xóa
              </a>
                <a type="button" class="btn btn-success" :href="geturlUpdataFood(listFood.foodid)">Edit</a>    
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
      listFood: [],
    }
  },
  async created() {
    await this.getfood()
  },
  mounted() {

  },
  methods: {
    async getfood() {
      try {
        const { data } = await Apidata.getfood(this.$axios)
        console.log(data)

        this.listFood = data
      } catch (err) {
        console.log(err)
      }
    },
 
     DeletaFood(id)
  {
      this.$axios.delete(`/api/foods/` + id).then(() =>
      {
          this.getfood()
      })
  },
 
    geturlUpdataFood(Foodeditid)
    {
      const url ='/FoodEdit/' + Foodeditid;
      return url;
    }

  },


   
  }
</script>

<style>
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