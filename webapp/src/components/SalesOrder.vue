<template>
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <breadcrumb :items="[{path:'salesorders',name:'Encomendas'}]" :current="'Energizers 1'"></breadcrumb>

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Detalhes Encomenda</h1>
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
                                <label for="numdoc" class="col-sm-2 control-label">Número Documento</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="numdoc" placeholder="Id" v-model="encomenda.NumeroDocumento" disabled>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="data" class="col-sm-2 control-label">Data</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="data" placeholder="Data" v-model="encomenda.Data" :disabled="!editing">
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="cliente" class="col-sm-2 control-label">Cliente</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="cliente" placeholder="Cliente" v-model="encomenda.Entidade" :disabled="!editing">
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="serie" class="col-sm-2 control-label">Série</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="serie" placeholder="Série" v-model="encomenda.Serie" :disabled="!editing">
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="valor" class="col-sm-2 control-label">Total Mercadoria</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="valor" placeholder="Valor" v-model="encomenda.TotalMercadoria" :disabled="!editing">
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
                    <div class="panel-heading">Lista de Artigos
                    </div>
                    <div class="panel-body">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>CodArtigo</th>
                                    <th>Descrição</th>
                                    <th>Quantidade</th>
                                    <th>Total</th>
                                    <th>Opções</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="artigo in artigos">
                                    <td>{{artigo.CodigoArtigo}}</td>
                                    <td>{{artigo.DescricaoArtigo}}</td>
                                    <td>{{artigo.Quantidade}}</td>
                                    <td>{{artigo.TotalLiquido}}</td>
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
    return {editing:false,encomenda:{},artigos:[]}
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
  },
mounted:function(){
  this.$http.get('http://localhost:49559/api/encomendas/'+this.$route.params.id)
  .then((response)=>{
    this.encomenda=response.body;
    this.artigos=response.body.LinhasDocumento
  });
}
}
</script>

<style>

    .recipt {
        margin-top: 10px;
    }
</style>
