<template>
  <div>
    <b-card no-body>
      <b-nav pills card-header slot="header" v-b-scrollspy:nav-scroller>
        <b-nav-item-dropdown text=" Quản lý bình luận KH" right-alignment>
          <b-dropdown-divider></b-dropdown-divider>
        </b-nav-item-dropdown>
      </b-nav>
      <b-card-body
        id="nav-scroller"
        ref="content"
        style="position:relative; height:300px; overflow-y:scroll; height: 450px;"
      >
      <div class="title">
            <h5>Danh sách</h5>
      </div>

    <table class="table">
    <thead>
        <tr>
        <th scope="col">#</th>
        <th scope="col">Tên Món Ăn</th>
        <th scope="col">Tên Khách Hàng</th>
        <th scope="col">Bình luận </th>
        <th scope="col"></th>
        </tr>
    </thead>
    <tbody >  
         <tr v-for="(listComment,index) in listComment" :key="index">
               <th  scope="row">KM00{{ (index + 1) }}</th>
               <td>{{ listComment.foodname }}</td>
               <td>{{ listComment.customername }}</td>
               <td>{{ listComment.commentDescriptions }}</td>
               <td>
              <button                   
                  type="button" 
                  class="btn btn-danger"
                  style=" 
                      border: none;
                      color: white;
                      padding: 15px 20px;
                      text-align: center;
                      text-decoration: none;
                      display: inline-block;
                      font-size: 15px;
                      margin: 4px 2px;
                      cursor: pointer;;"
                         v-on:click="DeleteComment(listComment.commentid)">
                   
                  Xóa
              </button>    
                </td>
        </tr>             
    </tbody>
    </table>
      </b-card-body>
    </b-card>
  </div>
</template>
<script>
import Apidata from '@/api/Apidata'
  export default {
      layout: 'LayoutsAdmin',
     data() {
    return {
      listComment: [],
    }
  },
  async created() {
    await this.getComment()
  },
  mounted() {

  },
  methods: {
    async getComment() {
      try {
        const { data } = await Apidata.getComment(this.$axios)
        console.log(data)

        this.listComment = data
      } catch (err) {
        console.log(err)
      }
    },

  DeleteComment(id)
  {
      this.$axios.delete(`/api/Comments/` + id).then(() =>
      {
          this.getComment()
      })
  }
  },

  }
</script>

<style>
.title{
    text-align: center;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
}
h5{
  font-weight: 700;

}
</style>