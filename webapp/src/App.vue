<template>
  <div id="app">
    <navbar v-show="auth"></navbar>
    <sidebar v-show="auth" ></sidebar>
    <router-view v-show="auth"></router-view>

    <login v-on:loggedIn="loggedIn" v-show="!auth"></login>
  </div>
</template>
<script>

import Navbar from './components/Navbar'
import Sidebar from './components/Sidebar'
import Breadcrumb from './components/Breadcrumb'
import Login from './components/Login'

export default {
  name: 'app',
  data:function(){
    return {auth:this.$root.auth}
  },
  components: {
    Navbar,
    Sidebar,
    Breadcrumb,
    Login
  },
  methods:{
    loggedIn:function(){
      this.auth=true;
    }
  }
}
</script>
