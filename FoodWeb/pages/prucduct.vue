<template>

<div class="container bootdey">
<div class="row">
    <!-- Product Item -->

    <!-- Product Item -->
    <div v-for="(listFood,index) in listFood" :key="index"
     class="product-grid col-xs-12 col-sm-6 col-md-3">
      <div class="product-item">
        <div class="sale-tag">
          <span>SALE</span>
        </div>
        <div class="image">
          <a href=""><img :src="listFood.foodimghp" alt=""></a>
        </div>
        <div class="caption">
          <div class="name text-center">
            <a href="#">{{ listFood.foodname }}</a>
          </div>
          <div class="price">
            <span class="price-new">{{ listFood.foodprice }}</span>
          </div>
          <div class="cart">
            <button type="button" class="btn btn-primary">Add to Cart</button>
          </div>
        </div>
        <button type="button" class="btn btn-default wishlist" data-toggle="tooltip" data-placement="right" title="Wishlist"><i class="fa fa-heart"></i></button>
        <button type="button" class="btn btn-default compare" data-toggle="tooltip" data-placement="right" title="Compare"><i class="fa fa-circle-o"></i></button>
      </div>
    </div>
    <!--/ Product Item -->

  </div>
</div>
  
</template>
<script>
import Apidata from '@/api/Apidata'
  export default {

     data() {
    return {
      listFood: [],
    }
  },
  async created() {
    await this.getfood()
  },
  mounted() {

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

  },


   
  }
</script>
<style>
body{
   
    background: #fff;    
}
.image{
  max-height: 300px;
}
product-item a {
    display: block;
    color: #434a54;
    font-weight: 700
}

.product-item a:hover {
    color: #37bc9b
}

.product-item .price {
    color: #aab2bd;
    font-weight: 700
}

.product-item .price .price-new {
    color: #37bc9b
}

.product-grid .product-item {
    position: relative;
    width: 100%;
    border: none;
    padding-bottom: 4pc;
    margin-bottom: 30px;
    margin-right: 20px;
    border-radius: 3px;
    box-shadow: 0 1px 2px 0 #ccd1d9;
    overflow: hidden;
    z-index: 1
}

.product-grid .product-item img {
    width: 100%;
    padding: 20px;
}

.product-grid .product-item .item-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: 0 0;
    border-radius: 3px;
    -webkit-transition: background .3s ease-in-out;
    transition: background .3s ease-in-out
}

.product-grid .product-item:hover .item-overlay {
    background: rgba(170, 178, 189, .42)
}

.product-grid .product-item .clickable a {
    display: block;
    padding: 100%;
    z-index: 9
}

.product-grid .product-item .caption {
    position: absolute;
    bottom: -87pt;
    display: block;
    min-width: 100%;
    min-height: 180px;
    padding: 6px 15px;
    margin: 0;
    background: #fff;
    -webkit-transition: all .3s ease-in-out;
    transition: all .3s ease-in-out;
    z-index: 1
}

.product-grid .product-item .caption .cart {
    display: block;
    padding: 27px 0 0;
    clear: both
}

.product-grid .product-item .caption .btn-primary {
    width: 100%;
    color: #fff;
    background: #37bc9b;
    border: 1px solid #37bc9b;
    -webkit-transition: all .2s ease-in-out 0s;
    transition: all .2s ease-in-out 0s
}

.product-grid .product-item .caption .btn-primary:hover {
    color: #434a54;
    background: 0 0;
    border: 1px solid #656d78
}

.product-grid .product-item .caption .name a,
.product-grid .product-item .caption .price {
    text-align: center
}

.product-grid .product-item .caption .name a {
    text-transform: lowercase;
    line-height: 1pc;
    margin: 9px 0 0
}

.product-grid .product-item:hover .caption {
    -webkit-transform: translatey(-83px);
    transform: translatey(-83px)
}

.product-grid .product-item .compare,
.product-grid .product-item .wishlist {
    color: #fff;
    display: none;
    margin-bottom: 3px;
    height: 30px;
    width: 30px;
    line-height: 30px;
    text-align: center;
    padding: 0;
    border: none;
    -webkit-transition: .3s;
    transition: .3s
}

.product-grid .product-item .compare a,
.product-grid .product-item .wishlist a {
    display: block;
    color: #fff;
    font-size: 14px
}

.product-grid .product-item .wishlist {
    position: absolute;
    top: 15px;
    left: 15px;
    background: #37bc9b
}

.product-grid .product-item .wishlist:hover {
    background: #33b091
}

.product-grid .product-item .compare {
    position: absolute;
    top: 3pc;
    left: 15px;
    background: #434a54
}

.product-grid .product-item .compare:hover {
    background: #393f47
}

.product-grid .product-item:hover .compare,
.product-grid .product-item:hover .wishlist {
    display: block
}

.product-grid .product-item .sale-tag {
    width: 50px;
    height: 75pt;
    background: #37bc9b;
    position: absolute;
    top: -45px;
    right: -10px;
    -webkit-transform: rotate(-45deg);
    transform: rotate(-45deg)
}

.product-grid .product-item .sale-tag span {
    color: #fff;
    font-size: 11px;
    font-weight: 700;
    left: 2px;
    position: absolute;
    top: 3pc;
    -webkit-transform: rotate(45deg);
    transform: rotate(45deg)
}

@media (min-width:992px) {
    .product-grid .product-item {
        width: 213px
    }
}

@media (min-width:1200px) {
    .product-grid .product-item {
        width: 263px
    }
}
</style>