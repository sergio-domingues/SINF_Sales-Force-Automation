<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<div class="row">
			<ol class="breadcrumb">
				<li><a href="#"><i class="fa fa-home" aria-hidden="true"></i></a></li>
				<li>Clientes</li>
				<li class="active">Barack Obama</li>
			</ol>
		</div>
		<!--/.row-->

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Barack Obama</h1>
			</div>
		</div>
		<!--/.row-->

		<div class="row">
			<div class="col-lg-8">
				<div class="panel panel-default">
					<div class="panel-heading">Info<div class="pull-right"><i class="fa fa-pencil" aria-hidden="true"></i></div></div>
					<div class="panel-body">

						<form class="form-horizontal">
							<div class="form-group">
								<label for="inputEmail3" class="col-sm-2 control-label">Id</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputEmail3" placeholder="Id" value="6" disabled>
								</div>
							</div>
							<div class="form-group">
								<label for="inputPassword3" class="col-sm-2 control-label">Nome</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword3" placeholder="Password" value="Barack Hussein Obama" disabled>
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword2" class="col-sm-2 control-label">Morada</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword2" placeholder="Password" value="The White House" disabled>
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword1" class="col-sm-2 control-label">Contacto</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword1" placeholder="Password" value="91675984" disabled>
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword0" class="col-sm-2 control-label">Descrição</label>
								<div class="col-sm-10">
										<textarea class="form-control" rows="3" disabled>Barack Hussein Obama II é um advogado e político dos Estados Unidos, o 44.º e atual presidente daquele país, sendo o primeiro afro-americano a ocupar o cargo.</textarea>
								</div>
							</div>



						</form>


					</div>
				</div>
			</div>

		</div>
		<div class="row">
			<div class="col-lg-4">
				<div class="panel panel-blue">
					<div class="panel-heading">Atividades</div>
					<div class="panel-body"  style="background-color:white">
					</div>
				</div>
			</div>

			<div class="col-lg-4">
				<div class="panel panel-blue">
					<div class="panel-heading">Oportunidades</div>
					<div class="panel-body" style="background-color:white">
					</div>
				</div>
			</div>

			<div class="col-lg-4">
				<div class="panel panel-blue">
					<div class="panel-heading">Encomendas</div>
					<div class="panel-body"  style="background-color:white">
					</div>
				</div>
			</div>

		</div>
		<!--/.row-->

	</div>
</template>

<script>
export default {
  name: 'dashboard',
  data () {
    return {}
  }
}
</script>

<style>
textarea { resize:vertical ; }
</style>