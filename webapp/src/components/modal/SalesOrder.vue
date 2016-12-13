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
            <input type="text" class="form-control" id="serie" v-model="encomenda.serie" placeholder="Serie">
          </div>
          <div class="form-group">
            <label for="date">Data da Encomenda</label>
            <input type="date" class="form-control" id="date" v-model="encomenda.data" placeholder="Data de Expiração">
          </div>
          <div class="form-group">
            <label for="cliente">Cliente</label>
            <select class="form-control selectpicker" id="cliente" v-model="selected" data-live-search="true" required>
              <option v-for="option in options" v-bind:value="option.value">
                {{ option.text }}
              </option>
            </select>
          </div>
          <div class="form-group">
            <label for="oportunidade">Oportunidade</label>
            <select class="form-control selectpicker" id="oportunidade" v-model="selectedOportunidade" data-live-search="true" required>
              <option v-for="option in optionsOportunidades" v-bind:value="option.id">
                {{ option.value }}
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
import config from '../../assets/config.json'
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
    return {encomenda:{descricao:'',data:Date.now(),serie:''},options:[],selected:'',artigos:[],optionsOportunidades:[],selectedOportunidade:''}
  },
  components:{ArticleListing},
  mounted: function(){
    this.$http.get(config.host+'/api/clientes/')
    .then((response)=>{
      for(var cliente of response.body){
        this.options.push({text:cliente.Nome,value:cliente.CodCliente});
      }
      this.$nextTick(()=>{
            $('.selectpicker').selectpicker('refresh');
          })
    })

    this.$http.get(config.host+'/api/oportunidades/')
    .then((response)=>{
      for(var oportunidade of response.body){
        this.optionsOportunidades.push({id:oportunidade.id,value:oportunidade.descricao});
      }
      this.$nextTick(()=>{
            $('.selectpicker').selectpicker('refresh');
          })
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
        idResponsavel:this.$root.vendedor.id
      }
      this.$http.post(config.host+'/api/encomendas/',encomenda)
        .then((response)=>{
          console.log(response);
        },(err)=>{
          console.log(err)
			});
    }
  }
}

</script>
