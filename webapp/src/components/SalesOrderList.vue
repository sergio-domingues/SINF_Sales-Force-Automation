<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Encomendas'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Encomendas</h1>
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
									<th>#</th>
									<th>Nome</th>
									<th>Cliente</th>
									<th>Rep. de Venda</th>
								</tr>
							</thead>
							<tbody>
								<router-link tag="tr" to="/salesorders/1" class="clicable">
									<th scope="row">1</th>
									<td>Energizers 1 </td>
									<td>Maria José da Silva</td>
									<td>José Esteves</td>
								</router-link>
								<router-link tag="tr" to="/salesorders/2" class="clicable">
									<th scope="row">2</th>
									<td>Energizers 2 </td>
									<td>Maria José da Silva</td>
									<td>José Esteves</td>
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
  name: 'LeadList',
  data () {
    return {}
  }
}
</script>