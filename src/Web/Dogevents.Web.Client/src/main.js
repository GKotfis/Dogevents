import Vue from 'vue'
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.css'
import App from './App.vue'


Vue.use(VueMaterial)

Vue.material.registerTheme({
  default: {
    primary: 'yellow',
    accent: 'blue',
    warn: 'red',
    background: { color: 'grey', hue: 100 }
  }
})

var app = new Vue({
  el: '#app',
  render: h => h(App)
})
