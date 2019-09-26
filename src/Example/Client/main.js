import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import Buefy from 'buefy'
import 'mdi/css/materialdesignicons.css'
import App from './App.vue'
import router from './router'

Vue.config.productionTip = false
Vue.config.devtools = true

Vue.use(VueAxios, axios)
Vue.use(Buefy)

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
