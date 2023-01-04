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
      <h5>Thêm Danh Mục</h5>
    </div>
      <ValidationObserver v-slot="{ handleSubmit }">
      <form action="" @submit.prevent="handleSubmit(onSubmit)">
        <div class="form-group-addfood">
          <label for="">Tên Danh Mục</label>
          <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Tên Danh mục "
          >
            <input
              v-model="dataSubmit.menuname"
              type="text"
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
            name="Hình ảnh  "
          >
          <input v-model="dataSubmit.menuavata" type="text" class="form-control" />
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
        menuname: "",
        menuavata: "",  
      },

    }
  },
  async created() {
  },
  methods: {

    async onSubmit() {
      try {
      await Apidata.addMenu(this.$axios, this.dataSubmit)
      alert("Thêm Danh mục thành công.")
       this.$router.push(`/Menu/MenuList`)
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