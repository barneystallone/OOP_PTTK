<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header">
        <b-nav-item-dropdown text="Quản lý Slider" right-alignment>
          <b-dropdown-item href="/Slider/SliderAdd" >Thêm Slider </b-dropdown-item>
          <b-dropdown-item href="/Slider/SliderList">Danh sách Slider </b-dropdown-item>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <h3>Thêm Slider</h3>
      <ValidationObserver v-slot="{ handleSubmit }">
      <form action="" @submit.prevent="handleSubmit(onSubmit)">
        <div class="form-group-addfood">
          <label for="">Tiêu đề Slider</label>
          <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Tên Slider "
          >
            <input
              v-model="dataSubmit.slidetitle"
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
          <input v-model="dataSubmit.slideimg" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>

    
          
        <div class="form-group">
            <label for="">Trạng Thái</label>
            <ValidationProvider
                v-slot="{ errors }"
                rules="required|max:100"
                name="Trạng Thái  "
            >    
            <select v-model="dataSubmit.slidetype"  name="" class="form-control">           
                <option value="1"> Bật</option> 
                <option value="0"> Tắt</option>
            </select>    

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
          v-model="dataSubmit.slidedescription"
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
        middleware: ['isAuthorize',
      // 'isAdmin'
      ], 
     layout: 'LayoutsAdmin',  
  data() {
    return {
      dataSubmit: {
        slidetitle: "",
        slidedescription: "",
        slideimg: "",  
        slidetype: "",
      },

    }
  },
  async created() {
  },
  methods: {


    async onSubmit() {
      try {
      await Apidata.addSlider(this.$axios, this.dataSubmit)
      alert("Thêm Slider thành công.")
       this.$router.push(`/SliderList`)
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
select,
textarea{
  margin: 0 16px;
  min-width: 810px;
}
#scroller{
  padding: 0 50px;
}
</style>