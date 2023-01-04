<template>
  <div>
<!--main page-->
    <div class="container px-4 px-lg-5 my-5">
        <div class="text-center text-black">
            <h1 class="display-4 fw-bolder">Menu</h1>
            <p class="lead fw-normal text-black-50 mb-0">Hãy order ngay</p>
        </div>
    </div>
       <div class="container">
      <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
        <h1 class="display-4">DeliCious  Food</h1>
      </div>
    <div>
        <b-tabs content-class="mt-3 listfood" fill >
          <b-tab title="ALL"  active>
            <div class="container bootdey">
            <div class="row">
                <div
                v-for="(food, index) in food"
                :key="index"
                class="product-grid col-xs-12 col-sm-6 col-md-4"
                >
            <!-- Food Item -->
                    <Foodedit
                    :food="food"
                    />
            <!-- Food Item -->
                </div>
            </div>
            </div>
           </b-tab>
        </b-tabs>
   </div>
  </div>
</div>
</template>
<script>
import Foodedit from '@/components/index/Foodedit'
export default {
      components: { Foodedit },
      methods: {

},
async asyncData({ $axios,params}) {
        const food = await $axios.$get(`/api/foods/viaCateId?MenuyId=${params.detailmenuId}`)
        console.log(food)
        return { food }
    },
}
</script>
<style >
.listfood{
  border: 1px solid rgb(228, 221, 221);
  padding: 40px;
  border-radius: 10px;
  min-width: 80%;
  background: rgb(223, 223, 230);
}
</style>