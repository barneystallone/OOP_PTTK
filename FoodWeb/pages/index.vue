<template>
  <main>
    <div class="containers">
    <div id="template-mo-jassa-hero-carousel" class="carousel slide" data-bs-ride="carousel">
  <ol class="carousel-indicators">
      <li data-bs-target="#template-mo-jassa-hero-carousel" data-bs-slide-to="0" class="active"></li>
      <li data-bs-target="#template-mo-jassa-hero-carousel" data-bs-slide-to="1"></li>
      <li data-bs-target="#template-mo-jassa-hero-carousel" data-bs-slide-to="2"></li>
      <li data-bs-target="#template-mo-jassa-hero-carousel" data-bs-slide-to="3"></li>
  </ol>
  <div class="carousel-inner">
      <div class="carousel-item active">
          <div class="container">
              <div class="row p-5 slide">
                  <div class="mx-auto col-md-8 col-lg-6 order-lg-last">
                      <img class="img-fluid" src="https://thumbs.dreamstime.com/z/christmas-food-flat-lay-text-welcome-sign-english-walnut-hazelnut-cinnamon-sticks-orange-peel-brown-wooden-background-102712430.jpg" max-height="400px" alt="">
                  </div>
                  <div class="col-lg-6 mb-0 d-flex align-items-center">
                      <div class="text-align-left align-self-center">
                          <h1 class="h1" style="font-size:44px !important"> <b>Tiệm bánh Chewy Junior</b></h1>
                          <h3 class="h2"></h3>
                          <p>
                            Chào mừng quý khách đã đến với chúng tôi.
                            Sự có mặt của quý khách là niềm vui của chúng tôi.
                            
                          </p>
                      </div>
                  </div>
              </div>
          </div>
   </div>
   <div class="carousel-item " v-for="(Slider ,index) in listSlider" :key="index" >
            <div class="container" >
                <div class="row p-5 slide">
                    <div class="mx-auto col-md-8 col-lg-6 order-lg-last">
                        <img class="img-fluid" :src="Slider.slideimg"  alt="">
                    </div>
                    <div class="col-lg-6 mb-0 d-flex align-items-center">
                        <div class="text-align-left">
                            <h1 class="h1"><b>{{Slider.slidetitle}}</b></h1>
                            <h3 class="h2"></h3>
                            <p>
                            {{Slider.slidedescription}}
                            </p>
                        </div>
                    </div>
                </div>
            </div>
     </div>
   </div>
      <a class="carousel-control-prev text-decoration-none w-auto ps-3" href="#template-mo-jassa-hero-carousel" role="button" data-bs-slide="prev">
          <i class="fas fa-chevron-left"></i>
      </a>
      <a class="carousel-control-next text-decoration-none w-auto pe-3" href="#template-mo-jassa-hero-carousel" role="button" data-bs-slide="next">
          <i class="fas fa-chevron-right"></i>
      </a>
   </div>
  </div>
  <section>
        <div class="container">
            <div class="text-center mb-4">
                <h2 class="display-20 display-md-18 display-lg-16">Menu</h2>
            </div>
              <div class="row" style="">
                      <div  v-for="(listmenu, index) in listmenu"
                      :key="index"
                      class="col-sm-6 col-lg-4 mb-1-9 mb-lg-0">
                        <CategoryMenu 
                        :listmenu="listmenu"/>
                </div>
              </div>
        </div>
  </section>
  <div class="container bootdey">
        <div class="d-lg-none flex-sm-fill mt-3 mb-4 col-7 col-sm-auto pr-3">
                  
        </div>
        <!-- san pham noi bat -->
            <div class="">
              <h2>NỔI BẬT</h2>
            </div>          
        <div class="row">
         <div  v-for="(listFoodnew,index) in listFoodnew" :key="index"
            class="product-grid col-xs-12 col-sm-6 col-md-4">    
            <OutstandingFood 
            :listFoodnew="listFoodnew"/>
          </div>
         </div>
  </div>
  <div>
        
       <!-- menu -->
       <div class="container">
      <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
        <h1 class="display-4">Thực đơn</h1>
      </div>
<div>
  <b-tabs content-class="mt-3 ListFood" fill >
    <!-- search -->
    <div class="div col-md-6" style="padding: 0 31px 13px"> <b-nav-form class="form_index">
                    <b-form-input
                    size="l"
                    class="index_content mr-sm-2"
                    placeholder="Ban muon tim banh gi ?"
                    v-model="search.nameData"
                    ></b-form-input>
                    <b-button class="index_content bg-info" size="l" type="submit"
                    @click.prevent="searchData(search.nameData)"
                    >Tìm kiếm</b-button
                  >
                  </b-nav-form>
              </div>
    <!-- full menu -->
    <b-tab title=""  active>
     <div class="container bootdey">
      <div class="row">
        <div
          v-for="(food, index) in listFood"
          :key="index"
           class="product-grid col-xs-12 col-sm-6 col-md-4"
         >
          <Foodedit
            :food="food"
            @add-to-cart="addCart"
            @out-of-stock="alert"
          />
        </div>
      </div>
    </div>
     </b-tab>
  </b-tabs>
</div>
  </div>
  </div>


<!-- news -->
  <div class="tile">
      <h3 class="">SỰ KIỆN BÁNH KEM - TIN KHUYẾN MÃI</h3>
    </div>
    <div 
      v-for="(News, index) in listnews"
          :key="index"
      >
        <Newlist
        :News="News"
         />
   </div>     
  </main>
</template>
<script>
import Foodedit from '@/components/index/Foodedit'
import Newlist from '@/components/index/Newlist'
import OutstandingFood from '@/components/index/OutstandingFood'
import CategoryMenu from '@/components/index/CategoryMenu'
import Apidata from '@/api/Apidata'
export default {
  components: { 
    Foodedit,
    Newlist,
    OutstandingFood,
    CategoryMenu,
  } , 
   layout: 'default',
  data() {
    return {
      listFoodnew: [],
      listnews: [],
     listmenu: [],
     listSlider: [],
     listFood: [],
     search:{}
    }
  },
  async created() {
    await this.getnews()
    await this.getfoodnew()
    await this.getmenu()
    await this.GetSliderHot()
    await this.getfood()
  
  },
  mounted() {
     const recaptchaScript = document.createElement('script')
      recaptchaScript.setAttribute('src', 'https://getbootstrap.com/docs/5.1/dist/js/bootstrap.bundle.min.js')
      document.head.appendChild(recaptchaScript)
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

  async getnews() {
      try {
        const { data } = await Apidata.getnews(this.$axios)
        console.log(data)
       this.listnews = data
       
      } catch (err) {
        console.log(err)
      }
    },

 async getfoodnew() {
      try {
        const { data } = await Apidata.GetOutstandingFood(this.$axios,1)
        console.log(data)
        this.listFoodnew = data
      } catch (err) {
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



 async GetSliderHot() {
      try {
        const { data } = await Apidata.GetSliderHot(this.$axios, 1)
        console.log(data)
        this.listSlider = data

      } catch (err) {
        console.log(err)
      }
    }, 
   async searchData(nameData){
        try{
          const {data} = await Apidata.searchData(this.$axios,nameData)
          console.log(data)
          this.listFood = data
        }
        catch(err){
        }
   }
  },
  

}
</script>
<style scoped>
.tile{
  height: 50px;
  text-align: center;
  font-family: sans-serif;
  border: 1 solid #fff;
  background: #fff;
  margin-bottom: 0px;

}
.bootdey{
  border: 1px solid #fff;
  border-radius: 10px;
  min-width: 80%;
  background: #FFF;
  text-align: center;
}
.h-100 {
    height: 100%!important;
}

.box-hover {
    min-height: 210px;
    position: relative;
}

.cover-background {
    position: relative !important;
    background-size: cover !important;
    overflow: hidden !important;
    background-position: center !important;
    background-repeat: no-repeat !important;
}

.margin-30px-bottom {
    margin-bottom: 30px;
}

.box-hover:before {
    position: absolute;
    content: "";
    top: 0;
    left: 0;
    background: rgba(0,0,0,0.76);
    background: -webkit-linear-gradient(top, transparent, #000 116%);
    background: linear-gradient(-180deg, transparent, #000 116%);
    z-index: 0;
    width: 100%;
    height: 100%;
}

</style>