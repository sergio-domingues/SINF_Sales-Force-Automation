<template>
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
                <td>{{artigo.PVP[0]*artigo.Quantidade}}</td>
                <td><i class="fa fa-lg fa-trash clicable" aria-hidden="true" v-on:click="removerArtigo(artigo)"></i>
                  <i class="fa fa-lg fa-minus clicable" aria-hidden="true" v-show="artigo.Quantidade >1" v-on:click="diminuirQuantidade(artigo)"></i>
                </td>
              </tr>
            </tbody>
          </table>

          <div class="row">
            <div class="col-lg-10 col-md-offset-1">
              <div class="input-group">
                <span class="input-group-btn">
                  <button class="btn btn-default" type="button">
                    <i class="fa fa-lg fa-search" aria-hidden="true"></i>
                  </button>
                </span>
                <input type="text" v-model="pesquisa" class="form-control" placeholder="Adicionar produtos">
              </div>
            </div>
          </div>

          <div class="row">
            <div class="col-lg-10 col-md-offset-1">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th>CodArtigo</th>
                    <th>Descrição</th>
                    <th>Disponibilidade</th>
                    <th>Opções</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="artigo in pesquisaReturnada">
                    <td>{{artigo.Codigo}}</td>
                    <td>{{artigo.Descricao}}</td>
                    <td v-if="artigo.StockAtual <= 0">indisponivel</td>
                    <td v-else>{{artigo.StockAtual}} </td>
                    <td><i class="fa fa-lg fa-plus clicable" aria-hidden="true" v-show="artigo.StockAtual >0" v-on:click="adicionarArtigo(artigo)"></i></td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
function findById(array,id,idProp){
	for(var i=0; i<array.length; i++){
		if(array[i][idProp]===id){
			return i;
		}
	}
	return -1;
}

export default {
  name: 'ArticleListing',
  data () {
    return {listaArtigos:[],pesquisa:'', pesquisaReturnada: []}
  },
  props:['artigos'],
  mounted:function(){
    this.$http.get('http://localhost:49559/api/artigos/')
    .then((response)=>{
      this.listaArtigos=response.body;
    });
  },
  watch: {
    pesquisa: function () {
      this.pesquisaReturnada = this.listaArtigos.filter(this.findArtigo);
    }
  },
  methods: {
    findArtigo : function(artigo){
      if(artigo['Descricao'].includes(this.pesquisa)){
        return true;
      }
      return false;
    },
    adicionarArtigo : function(artigo) {
      const indexArtigo=findById(this.artigos,artigo.Codigo,'CodigoArtigo');
      if(indexArtigo>=0){
          this.artigos[indexArtigo].Quantidade++;
      }else{
        this.artigos.push({CodigoArtigo:artigo.Codigo,DescricaoArtigo:artigo.Descricao,Quantidade:1,TotalLiquido:artigo.PrecoUltimo,PVP:artigo.PVPs});
      }
    },
    removerArtigo: function(artigo){
      this.artigos.splice(findById(this.artigos,artigo.CodigoArtigo,'CodigoArtigo'),1);
    },
    diminuirQuantidade:function(artigo){
      const indexArtigo=findById(this.artigos,artigo.CodigoArtigo,'CodigoArtigo');
      this.artigos[indexArtigo].Quantidade--;
    }
  }
}
</script>
