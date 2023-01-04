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
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <div class="title">
      <h5>Updata Slider</h5>
    </div>
      <ValidationObserver v-slot="{ handleSubmit }">
      <form action="" @submit.prevent="handleSubmit(UpdateSlider(Slider))">
        <div class="form-group">
          <label for="">Tiểu đề Slider</label>
             <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh  "
          >
          <input v-model="Slider.slidetitle" type="text" class="form-control" />
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
          <input v-model="Slider.slideimg" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>

         <div class="form-group">
          <label for="">Trạng Thái</label>
          <select v-model="Slider.slidetype"  class="form-control">

           <option value="1">
                Bật 
           </option>
                      <option value="0">
                Tắt 
           </option>
          </select>     
         </div>
          <div class="form-group">
          <label for="">Mô tả</label>
           <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:1000"
            name="Mô Tả  "
          >
           <textarea 
           v-model="Slider.slidedescription"
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
        async UpdateSlider(Slider) {
            try {
            await this.$axios.put('/api/Sliders/' + Slider.slideid, {
               slideid: Slider.slideid,
               slidetitle: Slider.slidetitle,
               slidetype: Slider.slidetype,
               slideimg: Slider.slideimg,
               slidedescription: Slider.slidedescription,


            })
            alert("thanh cong")
            this.$router.push('/Slider/SliderList')
            } 
            catch (err) {
            console.log(err)
            }
        },
  },
async asyncData({ $axios,params}) {
        const Slider = await $axios.$get(`/api/Sliders/${params.SliderEditID}`)
        console.log(Slider)
        return { Slider }
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