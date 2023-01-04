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
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <div class="title">
      <h5>Update Danh Mục </h5>
    </div>
      <ValidationObserver v-slot="{ handleSubmit }">
      <form action="" @submit.prevent="handleSubmit(UpdateMenu(menu))">    

        <div class="form-group">
          <label for="">Danh mục</label>
          <select v-model="menu.menuid"  name="" class="form-control">
           <option v-for="(menu, index) in listmenu" :key="index"
             :value="menu.menuid">
             {{menu.menuname}}
           </option>
          </select>     
        </div>     
        <div class="form-group">
          <label for="">Hình ảnh</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh  "
          >
          <input v-model="menu.menuavata" type="text" class="form-control" />
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
    layout: 'LayoutsAdmin',
  data() {
    return {
      food: {
        foodname: "",
        menuyid: 0,
        foodprice: 1000,
        foodavata: "",
        foodDescriptions: "",
        foodInStock: 0
      },
    listmenu: [],
    }
  },
  async created() {
    await this.getmenu()
  },
  methods: {
        async UpdateMenu(menu) {
            try {
            await this.$axios.put('/api/menus/' + menu.menuid, {
               menuid: menu.menuid,
               menuname: menu.menuname,
               menuavata: menu.menuavata,
            })
            alert("thanh cong")
            this.$router.push('/Menu/MenuList')
            } 
            catch (err) {
            console.log(err)
            }
        },
   async getmenu() {
      try {
        const { data } = await Apidata.getmenu(this.$axios)
        console.log(data)
        this.listmenu = data

      } catch (err) {
        console.log(err)
      }
    },
  },



async asyncData({ $axios,params}) {
        const menu = await $axios.$get(`/api/menus/${params.Menueditid}`)
        console.log(menu)
        return { menu }
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
.title{
 
    font-family: Verdana, Geneva, Tahoma, sans-serif;
}
h5{
  font-weight: 700;

}
</style>