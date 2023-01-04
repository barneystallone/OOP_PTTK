    
<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header">
        <b-nav-item-dropdown text="News" right-alignment>
          <b-dropdown-item href="/About/AddAbout" >About Add</b-dropdown-item>
          <b-dropdown-item href="/About/ListAbout">About List</b-dropdown-item>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
  <div class="title" >
        <h3>Thêm Tin Tức</h3>
  </div>
      <ValidationObserver v-slot="{ handleSubmit }">
      <form action="" @submit.prevent="handleSubmit(onSubmit)">
        <div class="form-group-addfood">
          <label for="">Tên Tiêu đề</label>
          <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Tên Tiêu đề "
          >
            <input
              v-model="dataSubmit.abouttitle"
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
          <input v-model="dataSubmit.aboutimg" type="text" class="form-control" />
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
          v-model="dataSubmit.aboutDescriptions"
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
     layout: 'LayoutsAdmin',
  data() {
    return {
      dataSubmit: {
        abouttitle: "",
        aboutimg: "",
        aboutDescriptions: "",  
      },

    }
  },
  async created() {
  },
  methods: {


    async onSubmit() {
      try {
      await Apidata.addAbout(this.$axios, this.dataSubmit)
      alert("Thêm Danh mục thành công.")
       this.$router.push(`/About/ListAbout`)
      } catch (err) {
        alert('Có lỗi xảy ra, vui lòng thử lại.' + JSON.stringify(err))
      }
    },
  },
}
</script>
<style scoped>
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
    text-align: center;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
}
</style>