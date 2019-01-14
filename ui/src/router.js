import Vue from 'vue'
import Router from 'vue-router'
import Send from './views/Send.vue'
import List from './views/List.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'send',
      component: Send
    },
    {
      path: '/list',
      name: 'list',
      component: List
    }
  ]
})
