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
                <th>Unidade</th>
                <th>Total</th>
                <th>Opções</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="artigo in artigos">
                <td>{{artigo.CodigoArtigo}}</td>
                <td>{{artigo.DescricaoArtigo}}</td>
                <td>{{artigo.Quantidade}}</td>
                <td>{{artigo.Unidade}}</td>
                <td>{{Math.round(artigo.PrecoUnitario*artigo.Quantidade*100)/100}}</td>
                <td><i class="fa fa-lg fa-trash clicable" aria-hidden="true" v-on:click="removerArtigo(artigo)"></i>
                  <input type="number" v-show="artigo.Quantidade >1" class="quant-select" v-model="artigo.QuantSelec"><i class="fa fa-lg fa-minus clicable"
                    aria-hidden="true" v-show="artigo.Quantidade >1" v-on:click="diminuirQuantidade(artigo)"></i>
                </td>
              </tr>
              <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td><strong>{{total}}€</strong></td>
                <td></td>
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
                    <th>Unidade</th>
                    <th>Preço unitário</th>
                    <th>Opções</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="artigo in pesquisaReturnada">
                    <td>{{artigo.Codigo}}</td>
                    <td>{{artigo.Descricao}}</td>
                    <td v-if="artigo.StockAtual <= 0">INDISPONIVEL</td>
                    <td v-else>{{artigo.StockAtual}} </td>
                    <td>{{artigo.unidade}}</td>
                    <td>{{artigo.PrecoMedio}}€</td>
                    <td><i class="fa fa-lg fa-plus clicable" aria-hidden="true" v-show="artigo.StockAtual >0 && artigo.PrecoMedio >0" v-on:click="adicionarArtigo(artigo)"></i></td>
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
import config from '../assets/config.json'

function findById(array,id,idProp){
	for(var i=0; i<array.length; i++){
		if(array[i][idProp]===id){
			return i;
		}
	}
	return -1;
}

function arredondarCentimos(preco) {
  return Math.round(preco * 100) / 100;
}

export default {
  name: 'ArticleListing',
  data () {
    return {listaArtigos:[],pesquisa:'', pesquisaReturnada: [], total: 0}
  },
  props:['artigos'],
  mounted:function(){
    this.$http.get(config.host+'/api/artigos/')
    .then((response)=>{
      for(let artigo of response.body){
        artigo.QuantSelec=1;
        this.listaArtigos.push(artigo);
      }
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
        this.total = arredondarCentimos(this.total + this.artigos[indexArtigo].PrecoUnitario);
      }else{
        this.artigos.push({CodigoArtigo:artigo.Codigo,DescricaoArtigo:artigo.Descricao,Quantidade:1,TotalLiquido:artigo.PrecoUltimo,PrecoUnitario:artigo.PVPs[0], Unidade:artigo.unidade, PrecoUnitario:artigo.PrecoUltimo, DescricaoUnidade:artigo.DescricaoUnidade});
        this.total = arredondarCentimos(this.artigos[this.artigos.length - 1].PrecoUnitario);
      }
    },
    removerArtigo: function(artigo){
      var pos = findById(this.artigos,artigo.CodigoArtigo,'CodigoArtigo');
      this.total = arredondarCentimos(this.total - this.artigos[pos].Quantidade * this.artigos[pos].PrecoUnitario);
      this.artigos.splice(pos,1);
    },
    diminuirQuantidade: function(artigo){
      const indexArtigo=findById(this.artigos,artigo.CodigoArtigo,'CodigoArtigo');

      this.total = arredondarCentimos(this.total - this.artigos[indexArtigo].PrecoUnitario);
      this.artigos[indexArtigo].Quantidade--;
      }
  }
}
</script>