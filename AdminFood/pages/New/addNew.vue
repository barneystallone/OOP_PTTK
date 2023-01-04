<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header">
        <b-nav-item-dropdown text="Quản lý tin tức" right-alignment>
          <b-dropdown-item href="/New/addNew" >Thêm tin tức</b-dropdown-item>
          <b-dropdown-item href="/New/NewList">Danh sách tin tức</b-dropdown-item>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
   <div class="title">
      <h5>Thêm Tin Tức</h5>
   </div>
      <ValidationObserver v-slot="{ handleSubmit }">
      <form action="" @submit.prevent="handleSubmit(onSubmit)">
        <div class="form-group-addfood">
          <label for="">Tên Tin tức</label>
          <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Tên Danh mục "
          >
            <input
              v-model="dataSubmit.newsname"
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
          <input v-model="dataSubmit.newsavata" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
        <div class="form-group">
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:100"
            name="Mô tả   "
          >         
          <label for="">Mô tả</label>
          <textarea 
          v-model="dataSubmit.descriptions"
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
        newsname: "",
        newsavata: "",
        descriptions: "",  
      },

    }
  },
  async created() {
  },
  methods: {
    async onSubmit() {
      try {
      await Apidata.addNews(this.$axios, this.dataSubmit)
      alert("Thêm Danh mục thành công.")
       this.$router.push(`/New/Newslist`)
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