<template>
  <div id="app">
    <navbar></navbar>
    <sidebar></sidebar>
    <router-view></router-view>
  </div>
</template>
<script>

import Navbar from './components/Navbar'
import Sidebar from './components/Sidebar'
import Breadcrumb from './components/Breadcrumb'

export default {
  name: 'app',
  components: {
    Navbar,
    Sidebar,
    Breadcrumb
  }
}
</script>
