<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :items="[{path:'leads',name:'Oportunidades'}]" :current="'Projecto de Implementação 1'"></breadcrumb>

		<div classt="row">
			<div class="col-lg-12">
				<h1 class="page-header">Projecto de Implementação 1</h1>
			</div>
		</div>
		<!--/.row-->

		<div class="row">
			<div class="col-lg-8">
				<div class="panel panel-default">
					<div class="panel-heading">Info
						<div class="pull-right">
							<i v-on:click="toggleEditing" v-bind:class="[editing ? 'fa-floppy-o' : 'fa-pencil', 'fa', 'fa-lg']" aria-hidden="true"></i>
							<i v-show="editing" v-on:click="cancelEditing" class="fa fa-lg fa-times" aria-hidden="true"></i>
						</div>
						
							
					</div>
					<div class="panel-body">

						<form class="form-horizontal">
							<div class="form-group">
								<label for="inputEmail3" class="col-sm-2 control-label">Id</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputEmail3" placeholder="Id" value="6" disabled>
								</div>
							</div>
							<div class="form-group">
								<label for="inputPassword3" class="col-sm-2 control-label">Cliente</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword3" placeholder="Password" value="XPTO1" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword2" class="col-sm-2 control-label">Nome</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword2" placeholder="Password" value="Projecto de Implementação 1" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword0" class="col-sm-2 control-label">Sumario</label>
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
		<div class="row">
			<div class="col-lg-12">
				<div class="panel panel-blue">
					<div class="panel-heading">Atividades</div>
					<div class="panel-body" style="background-color:white">
					</div>
				</div>
			</div>

		</div>
		<!--/.row-->

	</div>
</template>

<script>
export default {
  name: 'Lead',
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