<template>
  <div>
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
      <div class="container-fluid">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
          <a class="navbar-brand" href="#"><span>Pharma</span>CRM</a>
          <ul class="user-menu">
            <li class="dropdown pull-right">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown">Donald Trump <span class="caret"></span></a>
              <ul class="dropdown-menu" role="menu">
                <li><a href="#">Logout</a></li>
              </ul>
            </li>
          </ul>
        </div>

      </div>
      <!-- /.container-fluid -->
    </nav>

    <div id="sidebar-collapse" class="col-sm-3 col-lg-2 sidebar">
      <form role="search">
        <div class="form-group">
          <input type="text" class="form-control" placeholder="Search">
        </div>
      </form>
      <ul class="nav menu">
        <router-link tag="li" to="/" exact><a>Dashboard</a></router-link>
        <router-link tag="li" to="/customers"><a>Customers</a>
        </router-link>
        <router-link tag="li" to="/leads"><a>Leads</a></router-link>
        <router-link tag="li" to="/activities"><a>Activities</a></router-link>
        <router-link tag="li" to="/salesordes"><a>Sales Orders</a></router-link>
      </ul>

    </div>
  </div>
</template>

<script>
export default {
  name: 'navbar',
  data () {
    return {}
  }
}
</script>