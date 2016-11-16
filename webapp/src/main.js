import Vue from 'vue'
import App from './App'
import VueRouter from 'vue-router'
import Customer from './components/Customer.vue'
import CustomerList from './components/CustomerList.vue'
import Dashboard from './components/Dashboard.vue'
import Lead from './components/Lead.vue'
import LeadList from './components/LeadList.vue'


Vue.use(VueRouter);

const routes = [
  { path: '/customers', component: CustomerList },
  { path: '/customers/:id', component: Customer },
  { path: '/', component: Dashboard },
  { path: '/leads', component: LeadList },
  { path: '/leads/:id', component: Lead }
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
