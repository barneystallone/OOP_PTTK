<template>
    <div class="container">
<div class="container bootstrap snippets bootdeys">
      <div class="row text-center">
        <div class="col-sm-4">
          <div class="contact-detail-box">
            <i class="fa fa-th fa-3x text-colored"></i>
            <h4>Liên Hệ</h4>
            <abbr title="Phone">P:</abbr> 090 549 35 56<br>
            Fb <a href="https://www.facebook.com/nhahangtaidanangtochuctieccuoidanang" class="text-muted">Tiệm bánh </a>
          </div>
        </div><!-- end col -->

        <div class="col-sm-4">
          <div class="contact-detail-box">
            <i class="fa fa-map-marker fa-3x text-colored"></i>
            <h4>Địa Điểm</h4>

            <address>
            456 Đường 02 tháng 09 <br>
            Khu Công viên bắc tượng đài  Hải Châu, Đà Nẵng<br>
          </address>
          </div>
        </div><!-- end col -->

        <div class="col-sm-4">
          <div class="contact-detail-box">
            <i class="fa fa-book fa-3x text-colored"></i>
            <h4>Hỗ Trợ 24/7</h4>

            <p >Đường dây nóng</p>
            <h4 class="text-muted"> 0905.493.556 - 0975.545.659</h4>
          </div>
        </div><!-- end col -->

      </div>
      <!-- end row -->


      <div class="row">
        <div class="col-sm-6">
          <div class="contact-map">
            <img src="https://cdn.dealtoday.vn/img/s630x420/7fb436440ef84b9b9230068e558b1c24.jpg?sign=Ip5801fp-F8uRukpQqXhNQ" style="width: -webkit-fill-available;">
          </div>
        </div><!-- end col -->

        <!-- Contact form -->
        <div class="col-sm-6">
          <form role="form" name="ajax-form" id="ajax-form"   @submit.prevent="AddCustomerSP" method="post" class="form-main">

            <div class="form-group">
              <label for="name2">Tên</label>
              <input 
              class="form-control" 
              id="name2" name="name" 
              type="text" value="Name"
              v-model="dataSubmit.customerSPname">
              
            </div> <!-- /Form-name -->

            <div class="form-group">
              <label for="email2">Email</label>
              <input class="form-control" 
               v-model="dataSubmit.customerSPemail"
              id="email2" name="email" type="text" 
              value="E-mail"
                >
           
            </div> <!-- /Form-email -->

            <div class="form-group">
              <label for="message2">Lời nhắn</label>
              <textarea 
               v-model="dataSubmit.customerSPDescriptions"
              class="form-control" id="message2" name="message" rows="5">Lời nhắn</textarea>

              
            </div> <!-- /col -->

            <div class="row">            
              <div class="col-xs-12">
                <div id="ajaxsuccess" class="text-success">E-mail was successfully sent.</div>
                <div class="error" id="err-form" style="display: none;">There was a problem validating the form please check!</div>
                <div class="error" id="err-timedout">The connection to the server timed out!</div>
                <div class="error" id="err-state"></div>
                <button type="submit" class="btn btn-primary btn-shadow btn-rounded w-md" style="margin: 0px 24px 3px 13px;
    padding: 10px 30px;" id="send">Gửi</button>
              </div> <!-- /col -->
            </div> <!-- /row -->

          </form> <!-- /form -->
        </div> <!-- end col -->

      </div> <!-- end row -->
          
    </div>

    </div>
</template>
<script>
import Apidata from '@/api/Apidata'
export default {
 data(){
        return{
          dataSubmit:{
                customerSPname: '',
                customerSPemail: '',
                customerSPDescriptions: '',
          }
        }
    },
    methods:{
      async AddCustomerSP() {
      try {
      await Apidata.addCustomerSP(this.$axios, this.dataSubmit)
       alert("Phản hổi của bạn được ghi nhận !")
       
      } catch (err) {
        alert('Có lỗi xảy ra, vui lòng thử lại.' + JSON.stringify(err))
      }

    }
}

}
</script>
<style>
.container{
    padding: 0;
    background: #fff;
}
 
address{
  font-size: 16px !important;
  font-weight: 500;
}

/*======= Contact ======*/

.form-control {
  box-shadow: none !important;
  outline: none !important;
  border: 2px solid #9cb0b9;
  height: 38px;
}
.form-control:hover ,.form-control:focus{
  border-color: #04060a;
}
.text-muted
{
  color : black !important;
  font-size: 20px;
  font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
  
}


.error {
  margin: 8px 0px;
  display: none;
  color: red;
}
#ajaxsuccess {
  font-size: 16px;
  width: 100%;
  display: none;
  clear: both;
  margin: 8px 0px;
}
.con_sub_text {
  margin: 20px 0px;
  font-size: 15px;
}

.contact-detail-box {
  margin-bottom: 50px;
}

.contact-detail-box address {
  font-size: 14px;
}
.contact-map {
  background-color: #ededed;
}

.title-box .border,.btn-primary,.back-to-top,
.logo i,.question-q-box,.social-circle li a:hover {
  background-color: #f16000 !important;
}
.title-box .title-alt,.text-colored,.footer a:hover,
.navbar-custom .navbar-nav li a:hover,
.navbar-custom .navbar-nav li a:focus,
.navbar-custom .navbar-nav li a:active,
.navbar-custom .navbar-nav li.active a {
  color: #f16000;
}

.btn-primary {
  border: 1px solid #f16000 !important;
}
.btn-primary:hover,
.btn-primary:focus,
.btn-primary:active,
.btn-primary.active,
.btn-primary.focus,
.btn-primary:active,
.btn-primary:focus,
.btn-primary:hover,
.open > .dropdown-toggle.btn-primary,
.btn-primary.active.focus, .btn-primary.active:focus, 
.btn-primary.active:hover, .btn-primary:active.focus, 
.btn-primary:active:focus, .btn-primary:active:hover, 
.open>.dropdown-toggle.btn-primary.focus, 
.open>.dropdown-toggle.btn-primary:focus, 
.open>.dropdown-toggle.btn-primary:hover {
  background-color: #d85600 !important;
  border: 1px solid #d85600 !important;
}

.btn-shadow.btn-primary {
  box-shadow: 1px 5px 9px rgba(241, 96, 1, 0.32);
}



/*======= Responsive ======*/
@media (min-width: 768px) {
    .nav-custom-left {
		margin-left: 5%;
	}
  .navbar-nav>li>a {
    padding-top: 10px;
    padding-bottom: 10px;
  }
  .contact-page .col-sm-6 {
    padding-left: 30px;
    padding-right: 30px;
  }
}

@media (max-width: 768px) {
  .navbar-custom {
        -moz-box-shadow: 0 2px 2px rgba(0,0,0,.1);
    -webkit-box-shadow: 0 2px 2px rgba(0,0,0,.1);
    box-shadow: 0 2px 2px rgba(0,0,0,.1);
  }
  .screen-space {
    margin: 0px auto 50px auto;
  }
  .feature-detail {
    padding: 0px 0px 50px 30px !important;
  }
  .footer h5 {
    margin-top: 30px;
  }
}


@media only screen and (min-width: 768px) and (max-width: 991px){
  .blog-wrapper .blog-item {
    width: 50%;
  }
  .navbar-custom .navbar-nav li a {
    font-size: 12px;
  }
  .blog-detail-box {
  padding-right: 0px;
}
}
@media only screen and (min-width: 767px) and (max-width: 991px){
  
}
@media (max-width: 767px) {
  .blog-wrapper .blog-item {
    width: 100%;
  }
  .logo {
    margin-top: 7px;
  }
  .blog-detail-box {
  padding-right: 0px;
}
}
</style>