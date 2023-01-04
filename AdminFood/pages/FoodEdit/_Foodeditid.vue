<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text="Quản lý Món Ăn  " right-alignment>
          <b-dropdown-item href="/admin/Foods/addfood" >Thêm món Món Ăn</b-dropdown-item>
          <b-dropdown-item href="/Foods/ListFood">Danh sách Món Ăn</b-dropdown-item>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
    <div class="title">
      <h5>Update Món Ăn</h5>
    </div>
      <form action=""  @submit.prevent="UpdateFood(food)">
        <div class="form-group-addfood">
          <label for="">Tên sản phẩm</label>
           <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Tên sản phẩm "
          >
            <input
              v-model="food.foodname"
              type="text"
              class="form-control" 
            />
            <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
        <div class="form-group">
          <label for="">Danh mục</label>
          <select v-model="food.menuid"  name="" class="form-control">

           <option v-for="(menu, index) in listmenu" :key="index"
             :value="menu.menuid">
             {{menu.menuname}}
           </option>
          </select>     
        </div>
        <div class="form-group">
          <label for="">Giá tiền</label>
           <ValidationProvider
            v-slot="{ errors }"
            rules="required"
            name="Giá tiền "
          >
          <input
             v-model="food.foodprice"
            type="number"
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
            name="Hình ảnh "
          >
          <input v-model="food.foodimghp" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>

        <div class="form-group">
          <label for="">Hình ảnh 1</label>
           <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh 1"
          >
          <input v-model="food.foodimg1" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
       <div class="form-group">
          <label for="">Hình ảnh 2</label>
           <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh 2 "
          >
          <input v-model="food.foodimg2" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>

       <div class="form-group">
          <label for="">Hình ảnh 3</label>
            <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh 3 "
          >
          <input v-model="food.foodimg3" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
       </div>

        <div class="form-group">
          <label for="">Hình ảnh 4</label>
            <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:255"
            name="Hình ảnh 4 "
          >
          <input v-model="food.foodimg4" type="text" class="form-control" />
          <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>


        <div class="form-group">
          <label for="">Tình Trạng</label>
          <select v-model="food.foodInStock"  class="form-control">

           <option value="1">
          Còn 
           </option>
                      <option value="0">
          Hết 
           </option>
          </select>     
        </div>
        <div class="form-group">
          <label for="">Loại</label>
          <select v-model="food.typefood"  class="form-control">

           <option value="1">
          Nổi Bật
           </option>
                      <option value="0">
          Không Nổi Bật 
           </option>
          </select>     
        </div>

        <div class="form-group">
          <label for="">Mô tả</label>
           <ValidationProvider
            v-slot="{ errors }"
            rules="required|max:500"
            name="Mô tả "
          >
           <textarea 
           v-model="food.foodDescriptions"
           type="text" class="form-control">
           </textarea>
           <p class="muted text-danger">
              {{ errors[0] }}
            </p>
          </ValidationProvider>
        </div>
         
        <button type="submit" class="btn btn-primary">Lưu</button>
        <button type="reset" class="btn btn-outline-primary">Nhập lại</button>
      </form>

      </b-card-body >
    </b-card>
  </div>
</template>
<script>
import Apidata from '@/api/Apidata'
export default {
    layout: 'LayoutsAdmin',
  data() {
    return {
      food: {
        foodname: "",
        menuyid: 0,
        foodprice: 1000,
        foodavata: "",
        foodDescriptions: "",
        foodInStock: 0
      },
    listmenu: [],
    }
  },
  async created() {
    await this.getmenu()
  },
  methods: {
        async UpdateFood(food) {
            try {
            await this.$axios.put('/api/foods/' + food.foodid, {
               foodid: food.foodid,
               foodname: food.foodname,
               menuid: food.menuid,
               foodprice: food.foodprice,
               foodimghp: food.foodimghp,
               foodimg1: food.foodimg1,
               foodimg2: food.foodimg2,
               foodimg3: food.foodimg3,
               foodimg4: food.foodimg4,
               foodDescriptions: food.foodDescriptions,
               foodInStock: food.foodInStock,
               typefood: food.typefood, 

            })
            alert("thanh cong")
            this.$router.push('/Foods/ListFood')
            } 
            catch (err) {
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
   
  },

async asyncData({ $axios,params}) {
        const food = await $axios.$get(`/api/foods/${params.Foodeditid}`)
        console.log(food)
        return { food }
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