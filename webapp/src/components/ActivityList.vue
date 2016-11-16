<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<div class="row">
			<ol class="breadcrumb">
				<li><router-link to="/"><i class="fa fa-home" aria-hidden="true"></i></router-link></li>
				<li class="active">Atividades</li>
			</ol>
		</div>
		<!--/.row-->

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Atividades</h1>
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
									<th>Descrição</th>
									<th>Data</th>
								</tr>
							</thead>
							<tbody>
								<router-link tag="tr" to="/activities/1">
									<th scope="row">1</th>
									<td>Telefonar ao João</td>
									<td>17/10/2017</td>
								</router-link>
								<router-link tag="tr" to="/activities/2">
									<th scope="row">2</th>
									<td>Mandar mail á Maria</td>
									<td>18/12/2017</td>
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