<template>
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
              <a href="#" class="dropdown-toggle" data-toggle="dropdown">{{name}}<span class="caret"></span></a>
              <ul class="dropdown-menu" role="menu">
                <li><a href="#">Logout</a></li>
              </ul>
            </li>
          </ul>
        </div>

      </div>
      <!-- /.container-fluid -->
    </nav>
</template>

<script>
export default {
  name: 'navbar',
  data () {
    return {name:''}
  },
  mounted:function(){
    this.$http.get('http://localhost:49559/api/vendedores/1')
      .then((response)=>{
        this.$root.vendedor.id=response.body.cod;
        this.$root.vendedor.name=response.body.nome;
        this.name=response.body.nome;
      })

  }
}
</script>
