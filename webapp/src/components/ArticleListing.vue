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
                <td>{{artigo.TotalLiquido}}</td>
                <td><i class="fa fa-lg fa-trash clicable" aria-hidden="true"></i></td>
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
                <input type="text" class="form-control" placeholder="Adicionar produtos">
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
                  <tr v-for="artigo in artigos" v-if="artigo.show">
                    <td>{{artigosTotais.CodigoArtigo}}</td>
                    <td>{{artigosTotais.DescricaoArtigo}}</td>
                    <td>{{artigosTotais.Quantidade}}</td>
                    <td><i class="fa fa-lg fa-trash clicable" aria-hidden="true"></i></td>
                  </tr>
                </tbody>
              </table>
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
  name: 'ArticleListing',
  data () {
    return {artigosTotais:[],pesquisa:''}
  },
  props:['artigos'],
  mounted:function(){
    this.$http.get('http://localhost:49559/api/artigos/')
    .then((response)=>{
      this.artigosTotais=response.body;
      console.log(response.body);
    });
  }
}
</script>
