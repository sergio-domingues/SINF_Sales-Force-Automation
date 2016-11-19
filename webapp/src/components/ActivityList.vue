<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :current="'Atividades'"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Lista de Atividades</h1>
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

	</div>
</template>

<script>
export default {
  name: 'LeadList',
  data () {
    return {atividades : []}
  },
  mounted: function(){
		if(this.$root.$data.atividades.length>0){
			this.atividades=this.$root.atividades;
		}else{
	  this.$http.get('http://localhost:49559/api/atividades/')
		.then((response)=>{
			this.atividades=response.body;
			this.$root.$data.atividades=response.body;
	  });
  }
  },
  methods: {
	  displayDate: function(date){
		  var d = new Date(date);
		  	return  d.getDay()+ '-'+ d.getMonth()+ '-' + d.getFullYear()+' '+ d.getHours()+':'+ d.getMinutes()+':'+ d.getSeconds();
	  },
	  deleteActivity: function(id){
				  alert('delete Activity ' + id)
		/*  	this.$http.delete('http://localhost:49559/api/atividades/', id)
			  .then((res) =>{
				  alert('success')
				  console.log('sucess')
			  }, 
			  (err) => {
				  alert('error')
				  console.log('error')
			  });
			  */
	  }
  }
}
</script>