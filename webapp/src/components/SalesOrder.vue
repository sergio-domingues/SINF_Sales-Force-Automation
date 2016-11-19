<template>
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <breadcrumb :items="[{path:'salesorders',name:'Encomendas'}]" :current="'Energizers 1'"></breadcrumb>

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Ajuste de Detalhes</h1>
            </div>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-lg-8">
                <div class="panel panel-default">
                    <div class="panel-heading">Energizers 1
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
                                    <input type="text" class="form-control" id="inputEmail3" placeholder="Id" :value="$route.params.id" disabled>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Cliente</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="inputPassword3" placeholder="Cliente" value="Maria José da Silva" :disabled="!editing">
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="inputPassword2" class="col-sm-2 control-label">Oportunidade</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="inputPassword2" placeholder="Oportunidade" value="Projecto de Implementação"
                                        :disabled="!editing">
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="inputPassword0" class="col-sm-2 control-label">Rep. de Venda</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="inputPassword0" placeholder="Rep. de Venda" value="José Esteves" :disabled="!editing">
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">Lista de Encomendsas
                    </div>
                    <div class="panel-body">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Nome</th>
                                    <th>Quantidade</th>
                                    <th>Preço</th>
                                    <th>Opções</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>Green Ox</td>
                                    <td>2</td>
                                    <td>0.79 €</td>
                                    <td><i class="fa fa-lg fa-trash clicable" aria-hidden="true"></i></td>
                                </tr>
                                <tr>
                                    <th scope="row">2</th>
                                    <td>Blue AA</td>
                                    <td>4</td>
                                    <td>20 €</td>
                                    <td><i class="fa fa-lg fa-trash clicable" aria-hidden="true"></i></td>
                                </tr>
                            </tbody>
                        </table>

                        <div class="row">
                            <div class="col-lg-10">
                                <div class="input-group">
                                    <span class="input-group-btn">
                                    <button class="btn btn-default" type="button">
                                        <i class="fa fa-lg fa-search" aria-hidden="true"></i>
                                    </button>
                              </span>
                                    <input type="text" class="form-control" placeholder="Search for...">
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <i class="fa fa-lg fa-fw fa-plus-circle clicable" aria-hidden="true"></i>
                            </div>
                        </div>
                        <div class="row recipt">
                            <div class="col-lg-10">
                                <label class="pull-right"> Total: 20.79 € </label>
                            </div>
                            <div class="col-lg-2 ">
                                <i class="fa fa-lg fa-2x fa-cart-plus clicable" aria-hidden="true"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
export default {
  name: 'SalesOrders',
  data () {
    return {editing:false}
  },
  methods:{
	  toggleEditing: function(){
		  if(this.editing){
			  console.log('Enviar pedido para editar')
		  }
		  this.editing = !this.editing;
	  },
	  cancelEditing:function(){
		  //TODO
		 this.editing = !this.editing;
	  }
  }
}
</script>

<style>
    
    .recipt {
        margin-top: 10px;
    }
</style>