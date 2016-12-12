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
                <a v-if="!this.$root.adminMode" href="#" class="dropdown-toggle" data-toggle="dropdown">{{name}}<span class="caret"></span></a>
                <a v-else href="#" class="dropdown-toggle" data-toggle="dropdown">Admin<span class="caret"></span></a>
                <ul class="dropdown-menu" role="menu">
                  <li v-if="!this.$root.adminMode"><a href="#" v-on:click="adminModeOn()">Admin Mode ON</a></li>
                  <li v-else><a href="#" v-on:click="adminModeOn()">Admin Mode OFF</a></li>
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
import config from '../assets/config.json'
  export default {
    name: 'navbar',
    data () {
      return {name:''}
    },
    mounted:function(){
      this.$http.get(config.host+'/api/vendedores/1')
        .then((response)=>{
          this.$root.vendedor.id=response.body.cod;
          this.$root.vendedor.name=response.body.nome;
          this.name=response.body.nome;
        })
    },
    methods:{
      adminModeOn: function() {
        this.$root.adminMode = !this.$root.adminMode;
      }
    }
}
</script>
