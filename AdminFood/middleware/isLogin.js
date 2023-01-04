export default function ({store, redirect}, next){
  const isAdmin = store.getters["user/isLogin"];
  if(!isAdmin){
    // chuyen ve trang chu
    redirect('/')
  }
  next()
}