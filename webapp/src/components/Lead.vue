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
								<label for="id" class="col-sm-2 control-label">Id</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="id" placeholder="Id" :value="oportunidade.id" disabled>
								</div>
							</div>
							<div class="form-group">
								<label for="cliente" class="col-sm-2 control-label">Cliente</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="cliente" placeholder="Cliente" :value="oportunidade.entidade" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="descricao" class="col-sm-2 control-label">Descrição</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="descricao" placeholder="Descrição" :value="oportunidade.descricao" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="valorTotalOV" class="col-sm-2 control-label">Valor Total</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="valorTotalOV" placeholder="Valot Total" :value="oportunidade.valorTotalOV + '€'" :disabled="!editing">
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
function findById(array,id,idProp){
	for(var elem of array){
		if(elem[idProp]==id){
			return elem;
		}
	}
	return null;
}

export default {
  name: 'Lead',
  data () {
    return {editing:false,oportunidade:{}}
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
  },
	mounted: function(){
		const oportunidade = findById(this.$root.oportunidades,this.$route.params.id,'id');
		if(oportunidade){
			this.oportunidade=oportunidade;
		}else{
		const URL = encodeURI('http://localhost:49559/api/oportunidades/'+this.$route.params.id);
		this.$http.get(URL)
		.then((response)=>{
			this.oportunidade=response.body;
			this.$root.oportunidades.push(response.body);
		})
	}
}
}
</script>

<style>
	textarea {
		resize: vertical;
	}
</style>
