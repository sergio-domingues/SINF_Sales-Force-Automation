<template>
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<breadcrumb :items="[{path:'customers',name:'Clientes'}]" :current="cliente.Nome"></breadcrumb>

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">{{cliente.Nome}}</h1>
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
								<label for="inputEmail3" class="col-sm-2 control-label">Id</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputEmail3" placeholder="Id" :value="cliente.CodCliente" disabled>
								</div>
							</div>
							<div class="form-group">
								<label for="inputPassword3" class="col-sm-2 control-label">Nome</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword3" placeholder="Nome" v-model="cliente.Nome" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword2" class="col-sm-2 control-label">Morada</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="inputPassword2" placeholder="Morada" v-model="cliente.Morada" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="localidade" class="col-sm-2 control-label">Localidade</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="localidade" placeholder="Morada" v-model="cliente.Localidade" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="telefone" class="col-sm-2 control-label">Contacto</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="telefone" v-model="cliente.Telefone" placeholder="Contacto" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="contribuinte" class="col-sm-2 control-label">Contribuinte</label>
								<div class="col-sm-10">
									<input type="text" class="form-control" id="contribuinte" placeholder="Contribuinte" v-model="cliente.NumContribuinte" :disabled="!editing">
								</div>
							</div>

							<div class="form-group">
								<label for="inputPassword0" class="col-sm-2 control-label">Notas</label>
								<div class="col-sm-10">
									<textarea class="form-control" rows="3" :disabled="!editing">{{cliente.Notas}}</textarea>
								</div>
							</div>
						</form>
					</div>
				</div>
			</div>

		</div>
		<div class="row">
			<div class="col-lg-4">
				<div class="panel panel-blue">
					<div class="panel-heading">Atividades</div>
					<div class="panel-body" style="background-color:white">
						<div v-show="loading.atividades" class="spinner"></div>
<ul class="todo-list">
						<router-link tag="li" :to="'/activities/'+atividade.id" class="todo-list-item clicable" v-for="atividade in atividades">
							<div class="checkbox">
								{{atividade.descricao}}
							</div>
							<div class="pull-right">
								<i class="fa fa-check"v-bind:class="[atividade.estado ? 'fa-check' : 'fa-spinner', 'fa']" aria-hidden="true"></i>
							</div>
						</router-link>
</ul>
					</div>
				</div>
			</div>

			<div class="col-lg-4">
				<div class="panel panel-blue">
					<div class="panel-heading">Oportunidades</div>
					<div class="panel-body" style="background-color:white">
						<div v-show="loading.oportunidades" class="spinner"></div>
						<ul class="todo-list">
							<router-link tag="li" :to="'/leads/'+oportunidade.id" class="todo-list-item clicable" v-for="oportunidade in oportunidades">
								<div class="checkbox">
									{{oportunidade.descricao}}
								</div>
								<div class="pull-right">
									<i class="fa fa-check"v-bind:class="[null ? 'fa-check' : 'fa-spinner', 'fa']" aria-hidden="true"></i>
								</div>
							</router-link>
						</ul>
					</div>
				</div>
			</div>

			<div class="col-lg-4">
				<div class="panel panel-blue">
					<div class="panel-heading">Encomendas</div>
					<div class="panel-body" style="background-color:white">
						<div v-show="loading.encomendas" class="spinner"></div>
						<ul class="todo-list">
							<router-link tag="li" :to="'/salesorders/'+encomenda.NumeroEncomenda" class="todo-list-item clicable" v-for="encomenda in encomendas">
								<div class="checkbox">
									{{encomenda.descricao}}
								</div>
							</router-link>
						</ul>
					</div>
				</div>
			</div>

		</div>
		<!--/.row-->

	</div>
</template>

<script>
var clienteTemp;
export default {
  name: 'Customer',
  data () {
    return {editing:false,cliente:{},loading:{oportunidades:true,atividades:true,encomendas:true},oportunidades:[],atividades:[],encomendas:[]}
  },
  methods:{
	  toggleEditing: function(){
			clienteTemp=Object.assign({}, this.cliente);
		  if(this.editing){
			  this.$http.put('http://localhost:49559/api/clientes/'+this.cliente.CodCliente,this.cliente)
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
		 this.cliente=Object.assign({}, clienteTemp);
		 this.editing = !this.editing;
	  }
  },
	mounted: function(){
	  this.$http.get(encodeURI('http://localhost:49559/api/clientes/'+this.$route.params.id))
		.then((response)=>{
			this.cliente=response.body;
	  })

		//encomendas
		this.$http.get(encodeURI('http://localhost:49559/api/clientes/'+this.$route.params.id+'/encomendas'))
		.then((response)=>{
			this.loading.encomendas=false;
			this.encomendas=response.body;
	  })

		//oportunidades
		this.$http.get(encodeURI('http://localhost:49559/api/clientes/'+this.$route.params.id+'/oportunidades'))
		.then((response)=>{
			this.loading.oportunidades=false;
			this.oportunidades=response.body;
	  })

		//atividades
		this.$http.get(encodeURI('http://localhost:49559/api/clientes/'+this.$route.params.id+'/atividades'))
		.then((response)=>{
			this.loading.atividades=false;
			this.atividades=response.body;
	  })
	}
}
</script>

<style>
	textarea {
		resize: vertical;
	}
</style>
