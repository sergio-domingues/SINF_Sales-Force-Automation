import Vue from 'vue'
import Router from 'vue-router'
import App from './components/App.vue'

Vue.use(Router)


// routing
var router = new Router()

router.map({
  '/': {
    component: App
  }
})

router.beforeEach(function () {
  window.scrollTo(0, 0)
})

router.redirect({
  '*': '/error'
})

router.start(App, '#app')