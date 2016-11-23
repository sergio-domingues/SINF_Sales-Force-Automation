<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Encomendas'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Encomendas <i class="fa fa-plus pull-right clicable" data-toggle="modal" data-target="#create-salesorder-modal" aria-hidden="true"></i></h1>
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
								<router-link tag="tr" class="clicable" :to="'/salesorders/'+encomenda.NumeroDocumento" v-for="encomenda in encomendas">
									<td>{{encomenda.Data}}</td>
									<td><router-link :to="'/customers/'+encomenda.Entidade">{{encomenda.Entidade}}</router-link></td>
									<td>{{encomenda.TotalMercadoria}} €</td>
									<td>
										<router-link to="">
											<i v-on:click="deleteOportunity(oportunidade.id)" class="fa fa-lg fa-trash" aria-hidden="true"></i>
										</router-link>
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
import CreateSalesorderModal from './modal/SalesOrder.vue'
		export default {
			name: 'SalesOrderList',
			data () {
				return {encomendas:[]}
			},
			components:{CreateSalesorderModal},
			mounted: function(){
				this.$http.get('http://localhost:49559/api/encomendas/')
				.then((response)=>{
					this.encomendas=response.body;
				});
			}
		}
		</script>
