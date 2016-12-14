<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :items="[{path:'activities',name:'Actividades'}]" :current="atividade.resumo"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">{{atividade.resumo}}</h1>
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
								<label for="resumo" class="col-sm-2 control-label">Resumo</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="resumo" placeholder="resumo atividade" v-model="atividade.resumo" :value="atividade.resumo" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="tipo" class="col-sm-2 control-label">Tipo</label>
								<div class="col-sm-10">
									<select class="form-control" id="tipo" v-model="atividade.idTipoAtividade" :disabled="!editing">
										<option v-for="tipo in tipos" v-bind:value="tipo.value" :selected="atividade.idTipoAtividade==tipo.value">
											{{ tipo.text }}
										</option>
									</select>
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
									<input type="text" class="form-control" id="dataInicio" placeholder="data inicio" v-model="atividade.dataInicio" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="dataFim" class="col-sm-2 control-label">Data de Fim</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="dataFim" placeholder="data fim" v-model="atividade.dataFim" :value="atividade.dataFim" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="Tipo" class="col-sm-2 control-label">Oportunidade</label>
								<div class="col-sm-10">
								<!--	 <v-select :value.sync="atividade.idCabecalhoOportunidadeVenda" :on-search="getOportunidades" :options="oportunidades" :label="id"></v-select> -->
									 <v-select  :options="['1','2','3']"></v-select>
								<!--	<select class="form-control selectpicker" id="idCabecalhoOportunidadeVenda"  v-model="atividade.idCabecalhoOportunidadeVenda" data-live-search="true" required>
										<option v-for="oportunidade in oportunidades" v-bind:value="oportunidade.id" :selected="atividade.idCabecalhoOportunidadeVenda==oportunidade.id" :disabled="!editing">
											{{ oportunidade.descricao }}
										</option>
									</select> -->
								</div>
							</div>

							<div class="form-group">
								<label for="local" class="col-sm-2 control-label">Local</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="local" v-model="atividade.local" placeholder="Local" :disabled="!editing">
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
import config from '../assets/config.json'

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
			options:[{'text': 'FEITA',value:1}, {'text': 'INCOMPLETA',value:0}],
			tipos: [],
			selected: null,
			oportunidades: []
		}
	},
	methods:{
		toggleEditing: function(){
			copy = (JSON.parse(JSON.stringify(this.atividade)));
			if(this.editing){
				//TODO: idCabecalhoOportunidadeVenda e adicionar idContactoPrincipal
				//TODO: DEPOIS TROCAR ISTO! 'http://localhost:49559/api/vendedores/'+this.$root.vendedor.id+'/atividades?dataInicio=2010-11-15&dataFim=2016-11-15'
				const URL = encodeURI(config.host+'/api/atividades/'+this.$route.params.id);
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
		},
		getOportunidades:function(){
			loading(true);
			this.$http.get(config.host+'/api/vendedores/'+this.$root.vendedor.id+'/oportunidades')
			.then((response)=>{
				this.oportunidades=response.body;
				loading(false);
			})
		}
	},
	mounted: function(){

		this.$http.get(config.host+'/api/atividades/tipos')
		.then((response)=>{
			for(var tipo of response.body){
				this.tipos.push({text:tipo.descricao, value:tipo.id});
			}
		})

		const URL = encodeURI(config.host+'/api/atividades/'+this.$route.params.id);
		this.$http.get(URL)
		.then((response)=>{
			this.atividade=response.body;
			const URL2 = encodeURI(config.host+'/api/atividades/tipos/'+response.body.idTipoAtividade);
			this.$http.get(URL2)
			.then((tipo)=>{
				this.atividade.tipoAtividade = tipo.body.descricao;
				this.$nextTick(()=>{
					$('.selectpicker').selectpicker('refresh');
				})
				console.log('Atividade');
				console.log(response);
			})
		});
	}
}
</script>

<style>
textarea {
	resize: vertical;
}
</style>
