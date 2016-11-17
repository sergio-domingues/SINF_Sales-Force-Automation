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
									<th>#</th>
									<th>First Name</th>
									<th>Last Name</th>
									<th>Username</th>
								</tr>
							</thead>
							<tbody>
								<router-link tag="tr" to="/customers/1">
									<th scope="row">1</th>
									<td>Mark</td>
									<td>Otto</td>
									<td>@mdo</td>
								</router-link>
								<router-link tag="tr" to="/customers/2">
									<th scope="row">2</th>
									<td>Jacob</td>
									<td>Thornton</td>
									<td>@fat</td>
								</router-link>
								<router-link tag="tr" to="/customers/3">
									<th scope="row">3</th>
									<td>Larry</td>
									<td>the Bird</td>
									<td>@twitter</td>
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
    return {}
  }
}
</script>