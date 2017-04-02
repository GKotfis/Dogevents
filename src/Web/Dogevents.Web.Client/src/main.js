import Vue from 'vue'
import Popular from './components/Popular.vue'
import JustAdded from './components/JustAdded.vue'
import axios from 'axios'

new Vue({
  el: '#popular',
  render: h => h(Popular)
})

new Vue(
  {
    el: "#justadded",
    render: h => h(JustAdded)
  }
)
