<template>
  <div class="container">
    <div data-spy="scroll" data-target="#navbar" data-offset="72" class="position-relative">
    <section id="process" class="process">
      <div class="container-fluid container-fluid-max">
        <div class="row text-center py-5">
          <div class="col-12 pb-4">
            <h1 style="color:red">GIỚI THIỆU VỀ CHÚNG TÔI</h1>
          </div>
         
          
        </div>
      </div>
    </section>
  <div class="b-example-divider"></div>
  <div v-for="(listAbout, index) in listAbout" :key="index"
   class="container my-5">
    <div class="row p-4 pb-0 pe-lg-0 pt-lg-5 align-items-center rounded-3 border shadow-lg ">
      <div class="col-lg-6 p-3 p-lg-5 pt-lg-3">
        <h1 class="display-4 fw-bold lh-1"><b>{{listAbout.abouttitle}}</b></h1>
        <p class="lead">{{listAbout.aboutDescriptions}}</p>
        <div class="d-grid gap-2 d-md-flex justify-content-md-start mb-4 mb-lg-3">
          <button type="button" class="btn btn-success btn-lg px-4 me-md-2 fw-bold">Trang chủ</button>
        </div>
      </div>
      <div class="col-lg-5 offset-lg-1 p-0 overflow-hidden shadow-lg">
          <img class="rounded-lg-3" :src="listAbout.aboutimg" alt="" width="-webkit-fill-available">
      </div>
    </div>
  </div>

  <div class="b-example-divider mb-0"></div>

    </div>
  </div>
</template>
<script>
import Apidata from '@/api/Apidata'
  export default {
     data() {
    return {
      listAbout: [],
    }
  },
  async created() {
    await this.getAbout()
  },
  mounted() {

  },
  methods: {
   async getAbout() {
      try {
        const { data } = await Apidata.getAbout(this.$axios)
        console.log(data)

        this.listAbout = data
      } catch (err) {
        console.log(err)
      }
    },

  },  
  }
</script>
<style scoped>
*{
  font-family: Verdana, Geneva, Tahoma, sans-serif;
}
.row{
  padding: 10px;
}
</style>
