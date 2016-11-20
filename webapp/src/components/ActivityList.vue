<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Atividades'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Atividades <i class="fa fa-plus pull-right clicable" data-toggle="modal" data-target="#create-activity-modal" aria-hidden="true"></i></h1>
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
									<th>Descrição</th>
									<th>Estado</th>
									<th></th>
								</tr>
							</thead>
							<tbody>
								<router-link tag="tr" v-for="atividade in atividades" :to="'activities/'+ encodeURIComponent(atividade.id)" class="clicable">
									<th scope="row">{{displayDate(atividade.dataInicio)}}</th>
									<td>TODO</td>
									<td>{{atividade.descricao}}</td>
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
function findById(array,id,idProp){
	for(var i=0;i<array.length;i++){
		if(array[i][idProp]===id){
			return i;
		}
	}
	return null;
}
import CreateModal from './modal/Activity.vue'
export default {
  name: 'ActivityList',
  data () {
    return {atividades : []}
  },
	components:{CreateModal},
  mounted: function(){
	  this.$http.get('http://localhost:49559/api/atividades/')
		.then((response)=>{
			this.atividades=response.body;
	  });
  },
  methods: {
	  displayDate: function(date){
		  var d = new Date(date);
		  	return  d.getDay()+ '-'+ d.getMonth()+ '-' + d.getFullYear()+' '+ d.getHours()+':'+ d.getMinutes()+':'+ d.getSeconds();
	  },
	  deleteActivity: function(id){
					const URL = encodeURI('http://localhost:49559/api/atividades/' + id)

	  	this.$http.delete(URL)
			  .then((res) =>{
					this.oportunidades.splice(findById(this.atividades,id,'id'),1);
				  console.log('sucess')
			  },
			  (err) => {
				  console.log('error')
			  });
	  }
  }
}
</script>
