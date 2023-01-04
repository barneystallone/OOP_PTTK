<template>
            <div class="container">
            <div class="login-form" style="max-width:500px">
                <ValidationObserver v-slot="{ handleSubmit }">
                <form method="post"   @submit.prevent="handleSubmit(registers)" >
                    <h1 style="margin-left:42px">ĐĂNG KÝ</h1>
                    <div class="input-box">
                        <i >Tên đăng nhập</i>
                        <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|max:255"
                        name="Tên đăng nhập "    >
                        <input name="customername" type="text" v-model="dataSubmit.customername" placeholder="Nhập tên" >
                         <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                       </ValidationProvider>
                    </div>
                     <div class="input-box">
                        <i style="margin-right:72px">Email</i>
                        <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|email"
                        name="Email "    >
                        <input   name="customerEmail" type="text" v-model="dataSubmit.customeremail"  placeholder="Nhập Email">
                         <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                    </ValidationProvider>
                    </div>
                    <div class="input-box">
                        <i style="margin-right:14px">Số điện thoại</i>
                       <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|max:10"
                        name="Số điện thoai "    >
                        <input   name="customernumber" type="text" v-model="dataSubmit.customernuber" placeholder="Nhập số điện thoại">
                        <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                    </ValidationProvider>
                    </div>                     
                    <div class="input-box">
                        <i style="margin-right:42px">Mật khẩu</i>
                        <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|min:6"
                        name="Mật khẩu ">   
                        <input   name="customerpassword" type="password" v-model="dataSubmit.customerpassword" placeholder="Nhập mật khẩu">
                        <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                    </ValidationProvider>
                    </div>                  
                    <div class="btn-box">
                        <button type="submit">
                            Đăng ký
                        </button>
                    </div>
                </form> 
               </ValidationObserver>
            </div>
            </div>
</template>
<script>
import Apidata from '@/api/Apidata'
export default {
  layout: 'default',
 data(){
        return{
          dataSubmit:{
                customername: '',
                customeremail: '',
                customernuber: '',
                customerpassword: '',
          }
        }
    },

    methods:{
      async registers() {
      try {
      await Apidata.register(this.$axios, this.dataSubmit)
    
      alert("Bạn đã đăng kí thành công.")
      
       this.$router.push(`/login`)
      } catch (err) {
        alert('Tên đăng nhập hoặc Email đã tồn tại trong hệ thống.' + JSON.stringify(err))
      }

    }
}
}
</script>
<style scoped>
.main{
    background-color: #dddddd;
    min-height: 500px;
    padding: 7.5px 15px;
}

.containerf{
    
    margin-top: 50px;
    margin-bottom: 50px;
}
.login-form{
    width: 100%;
    max-width: 400px;
    margin: 20px auto;
    background-color: #e1e8eb;
    padding: 15px;
    border: 2px dotted #cccccc;
    border-radius: 10px;
    height: 550px;
}
h1{
    color: #009999;
    font-size: 20px;
    margin-bottom: 30px;
    text-align: center;
    font-family: sans-serif;
    font-size: 40px;
}
.input-box{
    margin-bottom: 30px;
}
.input-box input{
    padding: 7.5px 15px;
    width: 100%;
    border: 1px solid #cccccc;
    outline: none;
}
.btn-box{
    text-align: right;
    margin-top: 30px;
}
.btn-box button{
    padding: 7.5px 15px;
    border-radius: 2px;
    background-color: #009999;
    color: #ffffff;
    border: none;
    outline: none;
}
</style>