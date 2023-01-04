<template>
           <main>
                <div class="team-style1 hoverstyle1">
                    <div class="team-img">
                        <img style="height: 200px; width: 320px;"  
                       :src="listmenu.menuavata" alt="">
                    </div>
                </div>
                <div class="team-info text-center" style="background: linear-gradient(to right, #ffc745, #f14f00)">
                        <h6 class="h5"><a :href="geturl(listmenu.menuid)"><b style="font-size: 24px">{{listmenu.menuname}}</b></a></h6>
                </div>
           </main> 
</template>
<script>
export default {
      props: {
    listmenu: {
      type: Object,
      requred: true,
      default() {
        return {}
      },
    },
  },
    methods: {
    geturl(detailmenuId)
    {
      const url ='detailMenu/' + detailmenuId;
      return url;
    }
  },
}
</script>
<style>

.team-style1 {
    position: relative;
}
.team-style1 .team-img {
    position: relative;
    border-radius: 0.25rem;
    overflow: hidden;
    border: 1px solid rgba(0, 0, 0, 0.09);
    text-align: center;
}
.team-style1 .team-img img {
    display: inline-block;
}
.team-style1 .team-social-icon {
    position: absolute;
    top: 0;
    overflow: hidden;
    width: auto;
    display: block;
    transition: all 0.3s ease-in-out;
    z-index: 9;
}
.team-style1 .team-social-icon ul {
    list-style: none;
    padding: 0;
    transition: all 0.3s ease-in-out;
    margin: 20px;
}
.team-style1 .team-social-icon ul li {
    margin-bottom: 8px;
}
.team-style1 .team-social-icon ul li:last-child {
    margin-bottom: 0;
}
.team-style1 .team-social-icon ul li a {
    background-color: #fff;
    color: #004975;
    font-size: 15px;
    display: inline-block;
    height: 36px;
    border-radius: 0.25rem;
    width: 36px;
    border: 1px solid rgba(0, 73, 118, 0.41);
    line-height: 36px;
    text-decoration: none;
    text-align: center;
    transition: all 0.3s ease 0s;
}
.team-style1 .team-social-icon ul li a:hover {
    background: #00baee;
    color: #fff;
    border: 1px solid #00baee;
}
.team-style1 .team-info {
    position: absolute;
    width: 100%;
    bottom: 0;
    padding: 20px;
    background: #00baee;
    text-align: center;
    border-bottom-right-radius: 0.25rem;
    border-bottom-left-radius: 0.25rem;
}
.team-style1 .team-info h6 {
    display: block;
    color: #fff;
    text-transform: capitalize;
}
.team-style1 .team-info small {
    display: block;
    color: #fff;
}
@media screen and (max-width: 991px) {
    .team-style1 .team-info {
        padding: 15px;
    }
}
@media screen and (max-width: 575px) {
    .team-style1 .team-social-icon ul li a {
        width: 30px;
        height: 30px;
        line-height: 30px;
        font-size: 13px;
    }
}
</style>