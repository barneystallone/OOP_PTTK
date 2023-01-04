<template>
<div id="main-content" class="blog-page">
    <div class="container">
        <div class="row clearfix">
            <div class="col-lg-8 col-md-12 left-box">
                <div class="card single_post">
                    <div class="body">
                        <div class="img-post">
                        <img class="d-block img-fluid" :src="food.foodimghp"  alt="Hinh anh">
                        </div>
                        <h2><a href="#">{{food.foodname}} </a></h2>
                        <h3><a href="#">Mô tả: </a></h3>
                        <p> {{food.foodDescriptions}}</p>                                          
                    </div> 
                    <div class="body" v-if="food.foodimg1 != '' " >
                        <h3><a href="#">Hình ảnh mô tả: </a></h3>
                        <div class="img-post">
                        <img class="d-block img-fluid" :src="food.foodimg1"  alt="Hinh anh">
                        </div>
                    </div>
                    <div class="body"  v-if="food.foodimg1 != '' ">
                        <h3><a href="#">Hình ảnh mô tả: </a></h3>
                        <div class="img-post">
                        <img class="d-block img-fluid" :src="food.foodimg2"  alt="Hinh anh">
                        </div>
                    </div>
                        <div class="body"  v-if="food.foodimg1 != '' ">
                        <h3><a href="#">Hình ảnh mô tả: </a></h3>
                        <div class="img-post">
                        <img class="d-block img-fluid" :src="food.foodimg3"  alt="Hinh anh">
                        </div>
                    </div>
                        <div class="body"  v-if="food.foodimg1 != '' ">
                        <h3><a href="#">Hình ảnh mô tả: </a></h3>
                        <div class="img-post">
                        <img class="d-block img-fluid" :src="food.foodimg4"  alt="Hinh anh">
                        </div>
                        </div>
                    </div>
                
                    <div class="card">
                        <div class="header">
                          <h3>ĐÁNH GIÁ SẢN PHẨM</h3>
                        </div>
                        <div class="body">
                            <div class="card mb-3">
                                <div class="card-body">
                                    <div v-for="(listComment, index) in listComment" :key="index">
                                        <div      class="d-flex flex-start">

                                        <div class="w-100">
                                        <div class="d-flex justify-content-between align-items-center mb-3">
                                        <h6 class="text-primary fw-bold mb-0">
                                        {{listComment.customername}}

                                        </h6>
                                        <p class="mb-0">1 phút trước</p>
                                        </div>
                                        <p>{{listComment.commentDescriptions}}</p>
                                        <div class="d-flex justify-content-between align-items-center">
                                        <p class="small mb-0" style="color: #aaa;">
                                        <a href="#!" class="link-grey">Xóa</a> •
                                        <a href="#!" class="link-grey">Trả lời</a> •
                                        <a href="#!" class="link-grey">Thích</a>
                                        </p>
                                        <div class="d-flex flex-row">
                                        <i class="far fa-check-circle text-primary"></i>
                                        </div>
                                        </div>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                <div class="card">
                    <div class="body">
                    <div class="comment-form">
                        <form class="row clearfix"  @submit.prevent="AddComment(food)"> 
                            <div class="col-sm-12">
                            <div class="form-group">
                            <textarea rows="4"
                            v-model="comments"
                            class="form-control no-resize" placeholder="Đánh giá món ăn ..."></textarea>
                            </div>
                            <button type="submit" class="btn btn-block btn-primary">Gửi</button>
                            </div>                                
                        </form>
                            </div>
                            </div>
                            </div>
                            </div>
                            <div class="col-lg-4 col-md-12 right-box">
                            <div class="card">
                            <div class="header">
                            <h2>Danh mục</h2>
                            </div>
                            <div class="body widget">
                            <span class="posted_in "> <strong>Danh mục:</strong>                                    
                            <a v-if=" food.menuid === 1 " rel="tag" href="#">Thức ăn</a>
                            <a v-if=" food.menuid === 2 " rel="tag" href="#">Đồ uống</a>
                            <a v-if=" food.menuid === 3 " rel="tag" href="#">Đồ uống</a>.
                            </span>
                            </div>
                            <div class="body widget"> 
                            <strong>Giá : </strong> <span class="pro-price">{{food.foodprice.toLocaleString()}} VNĐ</span> 
                            </div>
                            <div class="body widget">
                            <label>Nhập số lượng</label>
                            <input type="quantiy" 
                            v-model="food.quantity"
                            class="form-control quantity"
                            value="1"
                            placeholder="Nhập số lượng!"
                            >
                            </div>
                            <!-- them vao gio hang -->
                             <div class=""  v-if="isUser">
                            <div class="body widget" v-if="food.foodInStock > 0">
                                <form   @submit.prevent="AddCart(food)">
                                    <button type="submit"                    
                                    class="btn btn-success" >
                                    <i class="fa fa-shopping-cart">
                                    </i> Thêm vào giỏ hàng</button>
                                 </form>
                          </div>
                          <!-- het hang -->
                          <div class="body widget" v-else> 
                                <form >
                                    <button type="submit" onclick="alert('Món ăn bạn đặt đã hết hàng! Vui lòng đạt món khách')"                   
                                    class="btn btn-secondary" >
                                    <i class="fa fa-shopping-cart">
                                    </i> Thêm vào giỏ hàng</button>
                            </form>
                        </div>
                        <!-- chua dang nhap -->
                        </div>
                          <div class="" v-else >    
                                   <div class="body widget" > 
                                <form >
                                    <button type="submit" onclick="alert('Vui lòng đăng nhập!')"                   
                                    class="btn btn-secondary" >
                                    <i class="fa fa-shopping-cart">
                                    </i> Thêm vào giỏ hàng</button>
                            </form>
                        </div>
                          </div>
                        
                </div>
            </div>

        </div>
    </div>
</div>
</template>
<script>
import { mapGetters } from 'vuex'
import Apidata from '@/api/Apidata'
export default {
  data() {
    return {
        listComment: [],
        listCustomer: [],
        comments: '',  
        food: {
        quantity: 0,

      },
    }
  },
  async created() {
  await this.getCustomer()
  await this.GetComment()
},
computed:{
...mapGetters({
      isUser: 'user/isUser',
      isView: 'user/isView',
    }),
},
  methods: {
  async getCustomer() {
    try {
      const { data } = await Apidata.getCustomer(this.$axios)
      console.log(data)
      this.listCustomer = data
    } 
    catch (err) {
      console.log(err)
    }
  },
    async AddCart(food) {
        if(food.quantity < 1 )
        {
            alert("Vui lòng nhập số lượng lớn hơn 0 ")
             
        }else
        {
      try {
           const tmpID = this.listCustomer[this.listCustomer.length - 1].customerid
                await this.$axios.post('/api/Carts', {
               foodid: food.foodid,
               foodname: food.foodname,
               foodprice: food.foodprice,
               foodimghp: food.foodimghp, 
               cartquantity: food.quantity,
               customerid: tmpID,
               allprice: food.quantity*food.foodprice
            })
       alert("Thêm vào giỏ hàng thành công.")     
       this.$router.push(`/checkout`)
      } catch (e) {
        this.error = e.response.data.messages
      }

        }
    },


    async AddComment(food)
    {
      if(this.comments === "")
      {
               alert("Vui lòng nhập nội dung")
      }else
      {
       try {
         const tmp = this.listCustomer[this.listCustomer.length - 1].customername
                await this.$axios.post('/api/Comments', {
               foodid: food.foodid,
               foodname: food.foodname,
               customername: tmp,
               commentDescriptions: this.comments, 

            })
       alert("Bình luận thành công !")     
       this.$router.push(`/Menu`)

      } catch (err) {
        alert('Vui lòng đăng nhập trước khi bình luận.')
      }
      }

    },

       async GetComment() {
      try {
        const { data } = await Apidata.GetComment(this.$axios, this.food.foodid)
        console.log(data)
        this.listComment = data

      } catch (err) {
        console.log(err)
      }
    },

    
},
async asyncData({ $axios,params}) {
        const food = await $axios.$get(`/api/foods/${params.detailfood}`)
        console.log(food)
        return { food }


        
    },


}
</script>
<style scoped>
.card {
    background: #fff;
    transition: .5s;
    border: 0;
    margin-bottom: 30px;
    border-radius: .55rem;
    position: relative;
    width: 100%;
    box-shadow: 0 1px 2px 0 rgb(0 0 0 / 10%);
}
.card .body {
    color: #444;
    padding: 20px;
    font-weight: 400;
}
.card .header {
    color: #444;
    padding: 20px;
    position: relative;
    box-shadow: none;
}
.single_post {
    -webkit-transition: all .4s ease;
    transition: all .4s ease
}

.single_post .body {
    padding: 30px
}

.single_post .img-post {
    position: relative;
    overflow: hidden;
    max-height: 500px;
    margin-bottom: 30px
}

.single_post .img-post>img {
    -webkit-transform: scale(1);
    -ms-transform: scale(1);
    transform: scale(1);
    opacity: 1;
    -webkit-transition: -webkit-transform .4s ease, opacity .4s ease;
    transition: transform .4s ease, opacity .4s ease;
    max-width: 100%;
    filter: none;
    -webkit-filter: grayscale(0);
    -webkit-transform: scale(1.01)
}

.single_post .img-post:hover img {
    -webkit-transform: scale(1.02);
    -ms-transform: scale(1.02);
    transform: scale(1.02);
    opacity: .7;
    filter: gray;
    -webkit-filter: grayscale(1);
 
}

.single_post .img-post:hover .social_share {
    display: block
}

.single_post .footer {
    padding: 0 30px 30px 30px
}

.single_post .footer .actions {
    display: inline-block
}

.single_post .footer .stats {
    cursor: default;
    list-style: none;
    padding: 0;
    display: inline-block;
 
    margin: 0;
    line-height: 35px
}

.single_post .footer .stats li {
    border-left: solid 1px rgba(160, 160, 160, 0.3);
    display: inline-block;
    font-weight: 400;
    letter-spacing: 0.25em;
    line-height: 1;
    margin: 0 0 0 2em;
    padding: 0 0 0 2em;
    text-transform: uppercase;
    font-size: 13px
}

.single_post .footer .stats li a {
    color: #777
}

.single_post .footer .stats li:first-child {
    border-left: 0;
    margin-left: 0;
    padding-left: 0
}

.single_post h3 {
    font-size: 20px;
    text-transform: uppercase
}

.single_post h3 a {
    color: #242424;
    text-decoration: none
}

.single_post p {
    font-size: 16px;
    line-height: 26px;
    font-weight: 300;
    margin: 0
}

.single_post .blockquote p {
    margin-top: 0 !important
}

.single_post .meta {
    list-style: none;
    padding: 0;
    margin: 0
}

.single_post .meta li {
    display: inline-block;
    margin-right: 15px
}

.single_post .meta li a {
    font-style: italic;
    color: #959595;
    text-decoration: none;
    font-size: 12px
}

.single_post .meta li a i {
    margin-right: 6px;
    font-size: 12px
}

.single_post2 {
    overflow: hidden
}

.single_post2 .content {
    margin-top: 15px;
    margin-bottom: 15px;
    padding-left: 80px;
    position: relative
}

.single_post2 .content .actions_sidebar {
    position: absolute;
    top: 0px;
    left: 0px;
    width: 60px
}

.single_post2 .content .actions_sidebar a {
    display: inline-block;
    width: 100%;
    height: 60px;
    line-height: 60px;
    margin-right: 0;
    text-align: center;
    border-right: 1px solid #e4eaec
}

.single_post2 .content .title {
    font-weight: 100
}

.single_post2 .content .text {
    font-size: 15px
}

.right-box .categories-clouds li {
    display: inline-block;
    margin-bottom: 5px
}

.right-box .categories-clouds li a {
    display: block;
    border: 1px solid;
    padding: 6px 10px;
    border-radius: 3px
}

.right-box .instagram-plugin {
    overflow: hidden
}

.right-box .instagram-plugin li {
    float: left;
    overflow: hidden;
    border: 1px solid #fff
}

.comment-reply li {
    margin-bottom: 15px
}

.comment-reply li:last-child {
    margin-bottom: none
}

.comment-reply li h5 {
    font-size: 18px
}

.comment-reply li p {
    margin-bottom: 0px;
    font-size: 15px;
    color: #777
}

.comment-reply .list-inline li {
    display: inline-block;
    margin: 0;
    padding-right: 20px
}

.comment-reply .list-inline li a {
    font-size: 13px
}

@media (max-width: 640px) {
    .blog-page .left-box .single-comment-box>ul>li {
        padding: 25px 0
    }
    .blog-page .left-box .single-comment-box ul li .icon-box {
        display: inline-block
    }
    .blog-page .left-box .single-comment-box ul li .text-box {
        display: block;
        padding-left: 0;
        margin-top: 10px
    }
    .blog-page .single_post .footer .stats {
        float: none;
        margin-top: 10px
    }
    .blog-page .single_post .body,
    .blog-page .single_post .footer {
        padding: 30px
    }
}
</style>