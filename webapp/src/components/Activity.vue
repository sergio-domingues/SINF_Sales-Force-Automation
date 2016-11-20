<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :items="[{path:'activities',name:'Actividades'}]" :current="'Atividade'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Atividade</h1>
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
								<label for="id" class="col-sm-2 control-label">Id</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="id" placeholder="Id" :value="atividade.id" disabled>
								</div>
							</div>

							<div class="form-group">
								<label for="tipo" class="col-sm-2 control-label">Tipo</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="tipo" placeholder="tipo" value="TODO" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="estado" class="col-sm-2 control-label">Estado</label>
								<div class="col-sm-10">
									<select class="form-control" id="cliente" v-model="atividade.estado" :disabled="!editing">
										<option v-for="option in options" v-bind:value="option.value">
											{{ option.text }}
										</option>
            						</select>
								</div>
							</div>

							<div class="form-group">
								<label for="dataInicio" class="col-sm-2 control-label">Data de Inicio</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="dataInicio" placeholder="data inicio" v-model="atividade.dataInicio" :value="atividade.dataInicio" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="dataFim" class="col-sm-2 control-label">Data de Fim</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="dataFim" placeholder="data fim" v-model="atividade.dataFim" :value="atividade.dataFim" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="tipoEntidade" class="col-sm-2 control-label">Tipo de Entidade</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="tipoEntidade" placeholder="Tipo de Entidade" v-model="atividade.tipoEntidadePrincipal" :value="atividade.local" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="vendedor" class="col-sm-2 control-label">Vendedor</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="vendedor" placeholder="vendedor" v-model="atividade.vendedor" :value="atividade.local" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="descricao" class="col-sm-2 control-label">Descrição</label>
								<div class="col-sm-10">
									<textarea class="form-control" rows="3"  v-model="atividade.descricao" :disabled="!editing">
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
var  copy;
function findById(array,id,idProp){
	for(var elem of array){
		if(elem[idProp]===id){
			return elem;
		}
	}
	return null;
}
export default {
	name: 'Activity',
  data () {
    return {
		editing:false,
		atividade : {},
		options:[{'text': 'FEITA',value:1}, {'text': 'INCOMPLETA',value:0}]
	}
  },
  methods:{
	  toggleEditing: function(){
			  copy = (JSON.parse(JSON.stringify(this.atividade)));
		  if(this.editing){
				//TODO: idCabecalhoOportunidadeVenda e adicionar idContactoPrincipal
				//TODO: DEPOIS TROCAR ISTO! 'http://localhost:49559/api/vendedores/'+this.$root.vendedor.id+'/atividades?dataInicio=2010-11-15&dataFim=2016-11-15'
	const URL = encodeURI('http://localhost:49559/api/atividades/'+this.$route.params.id);
	  this.$http.put(URL, this.atividade)
		.then((response)=>{
		console.log('response ' + response.body)
	  },(err)=>{
			console.log(err)
		})
		console.log('Enviar pedido para editar')
	}

		  this.editing = !this.editing;
	  },
	  cancelEditing:function(){
		  this.atividade = (JSON.parse(JSON.stringify(copy)));
		 this.editing = !this.editing;
	  }
  },
	mounted: function(){
	const URL = encodeURI('http://localhost:49559/api/atividades/'+this.$route.params.id);
	  this.$http.get(URL)
		.then((response)=>{
			this.atividade=response.body;
	  })
	}
}
</script>

<style>
	textarea {
		resize: vertical;
	}
</style>
