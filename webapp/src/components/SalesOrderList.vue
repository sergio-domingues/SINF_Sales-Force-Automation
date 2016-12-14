<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Encomendas'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Encomendas <i class="fa fa-plus pull-right clicable" v-show="!$root.adminMode" data-toggle="modal" data-target="#create-salesorder-modal"
						aria-hidden="true"></i></h1>
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
									<th>Cliente</th>
									<th>Valor</th>
									<th>Ações</th>
								</tr>
							</thead>
							<tbody>
								<div v-show="loading" class="spinner"></div>
								<router-link tag="tr" class="clicable" :to="'/salesorders/'+encomenda.NumeroDocumento" v-for="encomenda in encomendas">
									<td>{{encomenda.Data}}</td>
									<td>
										<router-link :to="'/customers/'+encomenda.Entidade">{{encomenda.Entidade}}</router-link>
									</td>
									<td>{{encomenda.TotalMercadoria}} €</td>
									<td>
										<router-link to="">
											<i v-show="!encomenda.Anulada" v-on:click="anularEncomenda(encomenda.NumeroDocumento)" class="fa fa-lg fa-trash" aria-hidden="true"></i>
										</router-link>
										<label v-show="encomenda.Anulada">ANULADA</label>
									</td>
							</tbody>
						</table>
					</div>
				</div>
			</div>

		</div>
		<!--/.row-->
		<create-salesorder-modal></create-salesorder-modal>
	</div>
</template>

<script>
import config from '../assets/config.json'

		import CreateSalesorderModal from './modal/SalesOrder.vue'

		function findById(array,id,idProp){
			for(var i=0; i<array.length; i++){
				if(array[i][idProp]===id){
					return i;
				}
			}
			return null;
		}

		export default {
			name: 'SalesOrderList',
			data () {
				return {encomendas:[],loading:true}
			},
			components:{CreateSalesorderModal},
			mounted: function(){
				if(this.$root.adminMode){
				this.$http.get(config.host+'/api/encomendas/')
				.then((response)=>{
					this.encomendas=response.body;
					this.loading=false;
				});
			}else{
				this.$http.get(config.host+'/api/vendedores/'+this.$root.vendedor.id+'/encomendas')
				.then((response)=>{
					this.encomendas=response.body;
					this.loading=false;
				});
			}
			},
			methods:{
				anularEncomenda:function(encNum){
					this.$http.delete(config.host+'/api/encomendas/'+encNum)
					.then((response)=>{
						this.encomendas.splice(findById(this.encomendas,'NumeroDocumento',encNum),1)
					});
				}
			}
		}
		</script>