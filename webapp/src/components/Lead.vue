<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :items="[{path:'leads',name:'Oportunidades'}]" :current="oportunidade.descricao"></breadcrumb>

		<div classt="row">
			<div class="col-lg-12">
				<h1 class="page-header">{{oportunidade.descricao}}</h1>
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
									<input type="text" class="form-control" id="id" placeholder="Id" :value="oportunidade.id" disabled>
								</div>
							</div>
							<div class="form-group">
								<label for="cliente" class="col-sm-2 control-label">Cliente</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="cliente" placeholder="Cliente" v-model="oportunidade.entidade" :disabled="!editing">
								</div>
							</div>
							<div class="form-group">
								<label for="identificador" class="col-sm-2 control-label">Identificador</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="identificador" placeholder="Identificador" v-model="oportunidade.codigo" :disabled="!editing">
								</div>
							</div>
							<div class="form-group">
								<label for="dataExpiracao" class="col-sm-2 control-label">Data de Expiração</label>
								<div class="col-sm-10">
									<input type="date" class="form-control" id="dataExpiracao" placeholder="Data de Expiração" v-model="oportunidade.dataExpiracao" :disabled="!editing">
								</div>
							</div>
							<div class="form-group">
								<label for="descricao" class="col-sm-2 control-label">Descrição</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="descricao" placeholder="Descrição" v-model="oportunidade.descricao" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="valorTotalOV" class="col-sm-2 control-label">Valor Total</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="valorTotalOV" placeholder="Valot Total" v-model="oportunidade.valorTotalOV" :disabled="!editing">
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
var oportunidadeTemp;

export default {
  name: 'Lead',
  data () {
    return {editing:false,oportunidade:{}}
  },
  methods:{
	  toggleEditing: function(){
			oportunidadeTemp=JSON.parse(JSON.stringify(this.oportunidade));
		  if(this.editing){
				const URL = encodeURI('http://localhost:49559/api/oportunidades/'+this.oportunidade.id);
				this.$http.put('http://localhost:49559/api/oportunidades/'+this.oportunidade.id,this.oportunidade)
				.then((response)=>{
					this.editing = !this.editing;
					this.oportunidade=response.body;
				},(err)=>{
					console.log(err)
			})
		  }else{
					this.editing = !this.editing;
			}
	  },
	  cancelEditing:function(){
		 this.oportunidade=JSON.parse(JSON.stringify(oportunidadeTemp));
		 this.editing = !this.editing;
	  }
  },
	mounted: function(){
		const URL = encodeURI('http://localhost:49559/api/oportunidades/'+this.$route.params.id);
		this.$http.get(URL)
		.then((response)=>{
			this.oportunidade=response.body;
			this.oportunidade.data=new Date(this.oportunidade.data);
		})
}
}
</script>

<style>
	textarea {
		resize: vertical;
	}
</style>
