import Vue from 'vue'

import { ValidationObserver, ValidationProvider, extend } from 'vee-validate'

import { required,min, max,email } from 'vee-validate/dist/rules';



import { messages } from 'vee-validate/dist/locale/vi.json'



extend('required', {

  ...required,

  message: messages.required,

})



extend('email', {

  ...email,

  message: messages.email,

})



extend('min', {

  ...min,

  message: messages.min,

})



extend('max', {

  ...max,

  message: messages.max,

})



Vue.component('ValidationObserver', ValidationObserver)

Vue.component('ValidationProvider', ValidationProvider)