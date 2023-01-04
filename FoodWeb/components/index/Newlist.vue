<template>
    <div class="containers">
    <section id="featured-destinations" class="featured-destinations bg-lightblue">
      <div class="row no-gutters">
          
        <div class="col-12 col-md-6 d-flex align-items-center order-1 order-md-0">
          <div class="p-15">
            <h3>{{News.newsname}}</h3>
            <p>
                {{News.descriptions}}
            </p>
          </div>
        </div>

        <div class="col-12 col-md-6 order-0 order-md-1">
         
               <img class="vh-100 cover" :src="News.newsavata" alt=""  />
          
        </div>
      </div>
    </section>
    </div>
</template>
<script>
export default {
      props: {
    News: {
      type: Object,
      requred: true,
      default() {
        return {}
      },
    },
  },
}
</script>
<style >
.bg-lightblue{
    padding: 20px;
    border: 1px solid rgb(202, 196, 196);
    border-radius: 10px;
    margin: 50px 0;
}
.cover{
    max-width: 810px;

}

 @media (min-width: 576px) {
    .cover { max-width: 100%;}
  }
  @media (min-width: 360px) {
    .cover { max-width: 100%;}
  }
</style>