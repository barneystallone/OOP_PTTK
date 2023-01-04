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
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <div class="title">
      <h5>Update Tin Tức</h5>
    </div>
      <ValidationObserver v-slot="{ handleSubmit }">
      <form action="" @submit.prevent="handleSubmit(UpdateFood(menu))">  
              <div class="form-group-addfood">
          <label for="">Tên Tin Tức</label>
          <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Tên Tin Tức "
          >
            <input
              v-model="news.newsname"
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
          <input v-model="news.newsavata" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>

       <div class="form-group">
          <label for="">Mô tả</label>
           <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:1000"
            name="Mô Tả  "
          >
           <textarea 
           v-model="news.descriptions"
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
export default {
    layout: 'LayoutsAdmin',

  methods: {
        async UpdateFood(menu) {
            try {
            await this.$axios.put('/api/menus/' + news.newsid, {
               menuid: news.menuid,
               newsname: news.newsname,
               newsavata: news.newsavata,
               descriptions: news.descriptions,
            })
            alert("thanh cong")
            this.$router.push('/Menu/MenuList')
            } 
            catch (err) {
            console.log(err)
            }
        },

  },
async asyncData({ $axios,params}) {
        const news = await $axios.$get(`/api/News/${params.NewEditID}`)
        console.log(news)
        return { news }
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
    min-width: 830px;
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