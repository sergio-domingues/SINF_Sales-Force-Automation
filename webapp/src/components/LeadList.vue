<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Oportunidades'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Oportunidades</h1>
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
									<th>Descrição</th>
									<th>Valor da Oportunidade</th>
									<th>Cliente</th>
								</tr>
							</thead>
							<tbody>
								<router-link tag="tr" class="clicable" :to="'/leads/'+oportunidade.id" v-for="oportunidade in oportunidades">
									<td>{{oportunidade.descricao}}</td>
									<td>{{oportunidade.valorTotalOV}} €</td>
									<td><router-link :to="'/customers/'+oportunidade.entidade">{{oportunidade.entidade}}</router-link></td>
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
  name: 'LeadList',
  data () {
    return {oportunidades:[]}
  },
	mounted: function(){
	  this.$http.get('http://localhost:49559/api/oportunidades/')
		.then((response)=>{
			this.oportunidades=response.body;
	  });
  }
}
</script>
