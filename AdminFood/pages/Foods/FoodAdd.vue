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
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <div class="title">
      <h5>Thêm Món Ăn</h5>
    </div>
      <ValidationObserver v-slot="{ handleSubmit }">
      <form action="" @submit.prevent="handleSubmit(onSubmit)">
        <div class="form-group-addfood">
          <label for="">Tên sản phẩm</label>
          <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Tên sản phẩm "    >
            <input
              v-model="dataSubmit.foodname"
              type="text"
              class="form-control" 
            />
            <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
        
        <div class="form-group">
          <label for="">Danh mục</label>
          <select v-model="dataSubmit.menuid"  name="" class="form-control">

            <option
                v-for="(menu, index) in listmenu"
                :key="index"
                :value="menu.menuid"
                >
                {{menu.menuname}}
            </option> 
          </select>     
        </div>

        <div class="form-group">
          <label for="">Giá tiền</label>
           <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:9"
            name="Giá tiền  "
          >
          <input
             v-model="dataSubmit.foodprice"
            type="number"
            class="form-control"
          />
           <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>


        <div class="form-group">
          <label for="">Hình ảnh</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh "
          >
          <input v-model="dataSubmit.foodimghp" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
        
        <div class="form-group">
          <label for="">Hình ảnh 1</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh 1 "
          >
          <input v-model="dataSubmit.foodimg1" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
                <div class="form-group">
          <label for="">Hình ảnh 2</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh 2"
          >
          <input v-model="dataSubmit.foodimg2" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
                <div class="form-group">
          <label for="">Hình ảnh 3</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh 3"
          >
          <input v-model="dataSubmit.foodimg3" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
                <div class="form-group">
          <label for="">Hình ảnh 4</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh  "
          >
          <input v-model="dataSubmit.foodimg4" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
        <div class="form-group">
          <label for="">Loại</label>
          <select v-model="dataSubmit.foodInStock"  name="" class="form-control">
            <option value="1"> Còn hàng</option> 
             <option value="0"> Hết hàng</option>
          </select>     
        </div>

        <div class="form-group">
          <label for="">Loại</label>
          <select v-model="dataSubmit.typefood"  name="" class="form-control">

            <option value="1"> Nổi Bật</option> 
             <option value="0"> Không Nổi Bật</option>
          </select>     
        </div>

        <div class="form-group">
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:100"
            name="Mô tả   "
          >         
          <label for="">Mô tả</label>
          <textarea 
          v-model="dataSubmit.foodDescriptions"
          type="text" class="form-control"></textarea>
            <p class="muted text-danger">
            {{ errors[0] }}
            </p>
             </ValidationProvider>    
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
import Apidata from '@/api/Apidata'
export default {
  middleware: [
    'isAuthorize',
    // 'isAdmin'
  ],
     layout: 'LayoutsAdmin',
  data() {
    return {
      dataSubmit: {
        foodname: "",
        menuid: 1,
        foodprice: 1000,
        foodimghp: "",
        foodimg1: "",
        foodimg2: "",
        foodimg3: "",
        foodimg4: "",
        foodDescriptions: "",
        foodInStock: 0,
        typefood: 0
      },
    listmenu: [],
    }
  },
  async created() {
    await this.getmenu()
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



    async onSubmit() {
      try {
      await Apidata.addfood(this.$axios, this.dataSubmit)
      alert("Thêm thành công")
       this.$router.push(`/Foods/Foodlist`)
      } catch (err) {
        alert('Có lỗi xảy ra, vui lòng thử lại.' + JSON.stringify(err))
      }
    },
  },
}
</script>
<style>
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
  min-width: 810px;
}
#scroller{
  padding: 0 50px;
}
.title{
 
    font-family: Verdana, Geneva, Tahoma, sans-serif;
}
h5{
  font-weight: 700;

}
</style>