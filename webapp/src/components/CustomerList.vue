<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Clientes'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header" >Lista de Clientes
					<router-link v-show="!$root.adminMode" tag="i" class="fa fa-plus pull-right clicable change-color" :to="'/customers/new'"></router-link>
					<i class="fa fa-refresh pull-right clicable change-color" v-show="!$root.adminMode" v-on:click="refresh" aria-hidden="true"></i></h1>
			</div>
		</div>
		<!--/.row-->

		<div class="row">
			<div class="col-lg-12">
				<div class="panel panel-default">
					<div class="panel-body">
						<table class="table table-hover">
							<thead>
								<tr>
									<th>#Código</th>
									<th>Nome</th>
									<th>Morada</th>
									<th>NIF</th>
								</tr>
							</thead>
							<div v-show="loading" class="spinner"></div>
							<tbody>
								<router-link tag="tr" class="clicable" :to="'/customers/'+cliente.CodCliente" v-for="cliente in clientes">
									<td>{{cliente.CodCliente}}</td>
									<td>{{cliente.Nome}}</td>
									<td>{{cliente.Morada}}</td>
									<td>{{cliente.NumContribuinte}}</td>
								</router-link>
							</tbody>
						</table>
					</div>
				</div>
			</div>

			</div>
		<!--/.row-->

	</div>
</template>

<script>
import config from '../assets/config.json'

export default {
  name: 'CustomerList',
  data () {
    return {
		clientes:[],
		loading:true
	}
  },methods:{
	  refresh:function(){
		this.$http.get(config.host+'/api/clientes/')
		.then((response)=>{
			this.loading=false;
			this.clientes=response.body;
	  });
	  }
  },
  mounted: function(){
	  this.$http.get(config.host+'/api/clientes/')
		.then((response)=>{
			this.loading=false;
			this.clientes=response.body;
	  });
}
}
</script>
