import Vue from 'vue'
import App from './App'
import VueRouter from 'vue-router'
import Customer from './components/Customer'
import CustomerList from './components/CustomerList'
import Dashboard from './components/Dashboard'

Vue.use(VueRouter);

const routes = [
  { path: '/customers', component: CustomerList },
  { path: '/customers/:id', component: Customer },
  { path: '/', component: Dashboard }
]

//Add history mode in future
const router = new VueRouter({
  linkActiveClass: 'active',
  routes
})

new Vue({
  router,
  el: '#app',
  render: h => h(App)
})
