<template>

 <div class="login-page" style="">
      <div class="form" >
        <div class="login">
          <div class="login-header" >
            <h3>ĐĂNG NHẬP</h3>
            
          </div>
        </div>
        <form class="login-form"  @submit.prevent="onSubmit">
          <input v-model="dataSubmit.username" type="text" class="form-control" placeholder="Tài khoản"/>
        <input
          v-model="dataSubmit.password"
          type="password"
          class="form-control"
          placeholder="Mật khẩu"
        />
          <button>login</button>
         
        </form>
      </div>
    </div>

</template>
<script>
import { mapActions } from 'vuex'
import accountApi from '@/api/accountApi'
export default {
  middleware: [
    'isLogin',
  ],
  data() {
    return {
      dataSubmit: {
        username: '',
        password: '',
      },
    }
  },
  methods: {
    ...mapActions({
      setToken: 'user/setToken',
      setRole: 'user/setRole',
    }),
    async onSubmit() {
      try {
        const data = await accountApi.login(this.$axios, this.dataSubmit)
        console.log(data.access_token)
        await this.setToken(data.access_token)
        await this.setRole(data.role)

        this.$router.push('/')
      } catch (err) {
        console.log(err)
        alert('Sai tên đăng nhập hoặc mật khẩu')
      }
    },
  },
}
</script>
<style scoped>
:root{
  background: yellowgreen;
}
header .header{
  background-color: #fff;
  height: 45px;
}
header a img{
  width: 134px;
margin-top: 4px;
}
.login-page {
  width: 360px;
  padding: 8% 0 0;
  margin: auto;
 
}
.login-page .form .login{
  margin-top: -31px;
margin-bottom: 26px;
}
.form {
  position: relative;
  z-index: 1;
  background: #FFFFFF;
  max-width: 360px;
  margin: 0 auto 100px;
  padding: 45px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
}
.form input {
  font-family: "Roboto", sans-serif;
  outline: 0;
  background: #f2f2f2;
  width: 100%;
  border: 0;
  margin: 0 0 15px;
  padding: 15px;
  box-sizing: border-box;
  font-size: 14px;
}
.form button {
  font-family: "Roboto", sans-serif;
  text-transform: uppercase;
  outline: 0;
  background-color: #328f8a;
  background-image: linear-gradient(45deg,#328f8a,#08ac4b);
  width: 100%;
  border: 0;
  padding: 15px;
  color: #FFFFFF;
  font-size: 14px;
  -webkit-transition: all 0.3 ease;
  transition: all 0.3 ease;
  cursor: pointer;
}
.form .message {
  margin: 15px 0 0;
  color: #b3b3b3;
  font-size: 12px;
}
.form .message a {
  color: #4CAF50;
  text-decoration: none;
}




</style>