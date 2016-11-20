<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Oportunidades'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Oportunidades <i class="fa fa-plus pull-right clicable" data-toggle="modal" data-target="#create-modal" aria-hidden="true"></i></h1>

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
									<th>Descrição</th>
									<th>Valor da Oportunidade</th>
									<th>Cliente</th>
									<th>Ações</th>
								</tr>
							</thead>
							<tbody>
								<router-link tag="tr" class="clicable" :to="'/leads/'+oportunidade.id" v-for="oportunidade in oportunidades">
									<td>{{oportunidade.descricao}}</td>
									<td>{{oportunidade.valorTotalOV}} €</td>
									<td><router-link :to="'/customers/'+oportunidade.entidade">{{oportunidade.entidade}}</router-link></td>
									<td>
									<router-link to="">
										<i v-on:click="deleteOportunity(oportunidade.id)" class="fa fa-lg fa-trash" aria-hidden="true"></i>
									</router-link>
								</td>
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
	function deleteById(array,id,idProp){
		for(var i=0;i<array.length;i++){
			if(array[i][idProp]===id){
				return array.splice(i, 1);
			}
		}
		return null;
	}
	import CreateModal from './modal/Lead.vue'
	export default {
		name: 'LeadList',
		data () {
			return {oportunidades:[]}
		},
		components:{CreateModal},
		mounted: function(){
			this.$http.get('http://localhost:49559/api/oportunidades/')
			.then((response)=>{
				this.oportunidades=response.body;
			});
		},
		methods:{
			deleteOportunity:function(id){
				const URL=encodeURI('http://localhost:49559/api/oportunidades/'+id);
				this.$http.delete(URL).then((response)=>{
					this.oportunidades=deleteById(this.oportunidades,id,'id')
				,(err)=>{
					console.log("erro ao eliminar da DB");
				}})
			}
		}
	}
	</script>
