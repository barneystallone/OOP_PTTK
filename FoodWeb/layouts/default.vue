<template>
  <div class="containerr">
    <!--User Component-->
    <Header />

    <Nuxt />
    <Footer />
  
  </div>
</template>
<script>
// import components
import Header from '@/components/Shared/Header.vue'
import Footer from '@/components/Shared/Footer.vue'
export default {
  name: 'Default',
  // decleare component
  components: {
    Header,
    Footer,
  },
}
</script>
<style >
.container{
background: #fff;
}

</style>