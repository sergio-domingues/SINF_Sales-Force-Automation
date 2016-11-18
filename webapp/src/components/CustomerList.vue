<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Clientes'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Clientes</h1>
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


export default {
  name: 'CustomerList',
  data () {
    return {
		clientes:[]
	}
  },
  mounted: function(){
	  this.$http.get('http://localhost:49559/api/clientes')
		.then((response)=>{
			for(var cliente of response.body){
				this.clientes.push(cliente)
			}
	  })

  }
}
</script>
