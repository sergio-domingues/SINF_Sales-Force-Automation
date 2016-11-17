<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :items="[{path:'activities',name:'Actividades'}]" :current="'Ajuste de Detalhes'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Ajuste de Detalhes</h1>
			</div>
		</div>
		<!--/.row-->

		<div class="row">
			<div class="col-lg-8">
				<div class="panel panel-default">
					<div class="panel-heading">Info
						<div class="pull-right">
							<i v-on:click="toggleEditing" v-bind:class="[editing ? 'fa-floppy-o' : 'fa-pencil', 'fa', 'fa-lg','clicable']" aria-hidden="true"></i>
							<i v-show="editing" v-on:click="cancelEditing" class="fa fa-lg fa-times clicable" aria-hidden="true"></i>
						</div>


					</div>
					<div class="panel-body">

						<form class="form-horizontal">
							<div class="form-group">
								<label for="inputEmail3" class="col-sm-2 control-label">Id</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputEmail3" placeholder="Id" :value="$route.params.id" disabled>
								</div>
							</div>
							<div class="form-group">
								<label for="inputPassword3" class="col-sm-2 control-label">Tipo</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword3" placeholder="Password" value="Barack Hussein Obama" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword2" class="col-sm-2 control-label">Estado</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword2" placeholder="Password" value="The White House" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword0" class="col-sm-2 control-label">Data de Inicio</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword0" placeholder="Password" value="The White House" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword1" class="col-sm-2 control-label">Data de Fim</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword1" placeholder="Password" value="The White House" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword4" class="col-sm-2 control-label">Local</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword4" placeholder="Password" value="91675984" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword0" class="col-sm-2 control-label">Descrição</label>
								<div class="col-sm-10">
									<textarea class="form-control" rows="3" :disabled="!editing">Barack Hussein Obama II é um advogado e político dos Estados Unidos, o 44.º e atual presidente daquele país, sendo o primeiro afro-americano a ocupar o cargo.
									</textarea>
								</div>
							</div>



						</form>


					</div>
				</div>
			</div>

		</div>
	</div>

</template>

<script>
export default {
  name: 'Customer',
  data () {
    return {editing:false}
  },
  methods:{
	  toggleEditing: function(){
		  if(this.editing){
			  console.log('Enviar pedido para editar')
		  }
		  this.editing = !this.editing;
	  },
	  cancelEditing:function(){
		  //TODO
		 this.editing = !this.editing;
	  }
  }
}
</script>

<style>
	textarea {
		resize: vertical;
	}
</style>