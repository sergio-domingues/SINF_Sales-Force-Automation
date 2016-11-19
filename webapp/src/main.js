import Vue from 'vue'
import App from './App'
import VueRouter from 'vue-router'
import Customer from './components/Customer.vue'
import CustomerList from './components/CustomerList.vue'
import Dashboard from './components/Dashboard.vue'
import Lead from './components/Lead.vue'
import LeadList from './components/LeadList.vue'
import Activity from './components/Activity.vue'
import ActivityList from './components/ActivityList.vue'
import SalesOrder from './components/SalesOrder.vue'
import SalesOrderList from './components/SalesOrderList.vue'
import NotFound from './components/NotFound.vue'
import Breadcrumb from './components/Breadcrumb.vue'
import VueResource from 'vue-resource'


Vue.use(VueRouter);
Vue.use(VueResource);

const store={
  vendedor:{id:'0',name:''}
}

const routes = [
  { path: '/', component: Dashboard },
  { path: '/customers', component: CustomerList },
  { path: '/customers/:id', component: Customer },
  { path: '/leads', component: LeadList },
  { path: '/leads/:id', component: Lead },
  { path: '/activities', component: ActivityList },
  { path: '/activities/:id', component: Activity },
  { path: '/salesorders', component: SalesOrderList },
  { path: '/salesorders/:id', component: SalesOrder },
  { path: '*', component: NotFound },
]

//Add history mode in future
const router = new VueRouter({
  linkActiveClass: 'active',
  routes
})

Vue.component('breadcrumb', Breadcrumb)

new Vue({
  router,
  data:store,
  el: '#app',
  render: h => h(App)
})
