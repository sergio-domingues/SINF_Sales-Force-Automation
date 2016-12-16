<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Atividades'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Atividades <i class="fa fa-plus pull-right clicable change-color" v-show="!$root.adminMode" data-toggle="modal" data-target="#create-activity-modal"
						aria-hidden="true"></i>
						<i class="fa fa-refresh pull-right clicable change-color" v-show="!$root.adminMode" v-on:click="refresh" aria-hidden="true"></i></h1>
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
									<th>Data</th>
									<th>Tipo</th>
									<th>Resumo</th>
									<th>Estado</th>
									<th></th>
								</tr>
							</thead>
							<tbody>
								<div v-show="loading" class="spinner"></div>
								<router-link tag="tr" v-for="atividade in atividades" :to="'activities/'+ encodeURIComponent(atividade.id)" class="clicable">
									<td>{{displayDate(atividade.dataInicio)}}</td>
									<td>{{atividade.tipoAtividade}}</td>
									<td>{{atividade.resumo}}</td>
									<td v-if="atividade.estado == 0">INCOMPLETA</td>
									<td v-else>FEITA</td>
									<td>
										<router-link to="">
											<i v-on:click="deleteActivity(atividade.id)" class="fa fa-lg fa-trash" aria-hidden="true"></i>
										</router-link>
									</td>
								</router-link>
							</tbody>
						</table>
					</div>
				</div>
			</div>

		</div>
		<!--/.row-->
		<create-modal></create-modal>
	</div>
</template>

<script>
import config from '../assets/config.json'

function findById(array,id,idProp){
	for(var i=0;i<array.length;i++){
		if(array[i][idProp]===id){
			return i;
		}
	}
	return null;
}

function functionequalID(id1, id2) {
	return id1 == id2;
}
import CreateModal from './modal/Activity.vue'
export default {
	name: 'ActivityList',
	data () {
		return {atividades : [], tipos: [],loading:true}
	},
	components:{CreateModal},
	mounted: function(){

		this.$http.get(config.host+'/api/atividades/tipos/')
		.then((tiposAtividades)=>{
			this.tipos = tiposAtividades.body;

			if(this.$root.adminMode){
				this.$http.get(config.host+'/api/atividades/')
				.then((response)=>{
					for(let i = 0; i < response.body.length; i++){
						this.atividades=response.body;
						var index =	findById(this.tipos, this.atividades[i].idTipoAtividade,'id')
						this.atividades[i].tipoAtividade = this.tipos[index].descricao;
						this.loading=false;
					}
				});
			}
			else{
				this.$http.get(config.host+'/api/vendedores/'+this.$root.vendedor.id+'/atividades?dataInicio=2010-11-15&dataFim=2017-11-15')
				.then((response)=>{
					for(let i = 0; i < response.body.length; i++){
						this.atividades=response.body;
						var index =	findById(this.tipos, this.atividades[i].idTipoAtividade,'id')
						this.atividades[i].tipoAtividade = this.tipos[index].descricao;
						this.loading=false;
					}
				});
			}
		});	
	},
	methods: {
		displayDate: function(date){
			var d = new Date(date);
			return d.toLocaleString('pt-PT');
		},
		deleteActivity: function(id){
			const URL = encodeURI(config.host+'/api/atividades/' + id)

			this.$http.delete(URL)
			.then((res) =>{
				this.atividades.splice(findById(this.atividades,id,'id'),1);
				console.log('sucess')
			},
			(err) => {
				console.log('error')
			});
		},
		refresh:function(){
				this.$http.get(config.host+'/api/vendedores/'+this.$root.vendedor.id+'/atividades?dataInicio=2010-11-15&dataFim=2017-11-15')
				.then((response)=>{
					for(let i = 0; i < response.body.length; i++){
						this.atividades=response.body;
						var index =	findById(this.tipos, this.atividades[i].idTipoAtividade,'id')
						this.atividades[i].tipoAtividade = this.tipos[index].descricao;
						this.loading=false;
					}
				});
		}
	}
}
</script>