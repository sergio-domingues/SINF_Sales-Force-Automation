<template>
  <div id="app">
    <navbar v-if="auth" v-on:loggedOut="loggedOut"></navbar>
    <sidebar v-if="auth" ></sidebar>
    <router-view v-if="auth"></router-view>

    <login v-on:loggedIn="loggedIn" v-if="!auth"></login>
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
    },
    loggedOut:function(){
      this.auth=false;
    }
  }
}
</script>
