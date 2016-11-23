<template>
  <div class="modal fade" id="create-salesorder-modal" tabindex="-1" role="dialog" aria-labelledby="CreateLeadModal">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h4 class="modal-title">Nova Encomenda</h4>
        </div>
        <form v-on:submit.prevent="createSalesOrder">
        <div class="modal-body">
          <div class="form-group">
            <label for="serie">Serie</label>
            <input type="text" class="form-control" id="serie" v-model="encomenda.identificador" placeholder="Serie">
          </div>
          <div class="form-group">
            <label for="date">Data da Encomenda</label>
            <input type="date" class="form-control" id="date" v-model="encomenda.data" placeholder="Data de Expiração">
          </div>
          <div class="form-group">
            <label for="cliente">Cliente</label>
            <select class="form-control" id="cliente" v-model="selected">
              <option v-for="option in options" v-bind:value="option.value">
                {{ option.text }}
              </option>
            </select>
          </div>
          <article-listing :artigos="artigos"></article-listing>
          <div class="modal-footer">
          <button type="submit" class="btn btn-primary">Confirmar</button>
        </div>
      </form>
      </div>
    </div>
  </div>
</template>

<script>
import ArticleListing from '../ArticleListing.vue'
function deleteById(array,id,idProp){
	for(var elem of array){
		if(elem[idProp]===id){
			return elem;
		}
	}
	return null;
}
export default {
  name: 'CreateSalesOrderModal',
  data () {
    return {encomenda:{descricao:'',data:Date.now(),serie:''},options:[],selected:'',artigos:[]}
  },
  components:{ArticleListing},
  mounted: function(){
    this.$http.get('http://localhost:49559/api/clientes/')
    .then((response)=>{
      for(var cliente of response.body){
        this.options.push({text:cliente.Nome,value:cliente.CodCliente});
      }
    })
  },
  methods:{
    createSalesOrder: function(e){
      const encomenda =
      {
        Data:this.encomenda.data,
        Entidade:this.selected,
        Filial:"000",
        LinhasDocumento:this.artigos,
        Serie:this.encomenda.serie,
        idResponsavel:"1"
      }
      this.$http.post('http://localhost:49559/api/encomendas/',encomenda)
        .then((response)=>{
          console.log(response);
        },(err)=>{
          console.log(err)
			});
    }
  }
}

</script>
