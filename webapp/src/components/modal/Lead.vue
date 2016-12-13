<template>

  <div class="modal fade" id="create-modal" tabindex="-1" role="dialog" aria-labelledby="CreateLeadModal">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h4 class="modal-title">Nova Oportunidade</h4>
        </div>
        <form v-on:submit.prevent="createLead">
          <div class="modal-body">
            <div class="form-group">
              <label for="descricao">Descrição</label>
              <input type="text" class="form-control" id="descricao" v-model="oportunidade.descricao" placeholder="Descrição">
            </div>
            <div class="form-group">
              <label for="identificador">Identificador</label>
              <input type="text" class="form-control" id="identificador" v-model="oportunidade.identificador" placeholder="Identificador">
            </div>
            <div class="form-group">
              <label for="date">Data de Expiraçao</label>
              <input type="date" class="form-control" id="date" v-model="oportunidade.data" placeholder="Data de Expiração">
            </div>
            <div class="form-group">
              <label for="cliente">Cliente</label>
              <select class="form-control selectpicker" id="cliente" data-live-search="true" v-model="selected" data-max-options="<10></10>" required>
              <option v-for="option in options" v-bind:value="option.value">
                {{ option.text }}
              </option>
            </select>
            </div>
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
function deleteById(array,id,idProp){
	for(var elem of array){
		if(elem[idProp]===id){
			return elem;
		}
	}
	return null;
}
export default {
  name: 'CreateLeadModal',
  data () {
    return {oportunidade:{descricao:'',data:null,identificador:''},options:[],selected:''}
  },
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
  },
  methods:{
    createLead: function(e){
      this.$http.post(config.host+'/api/oportunidades/',{descricao:this.oportunidade.descricao,entidade:this.selected,
          tipoEntidade:"C",vendedor:this.$root.vendedor.id,dataExpiracao:this.oportunidade.data,codigo:this.oportunidade.identificador})
        .then((response)=>{
          console.log(response);
        },(err)=>{
          console.log(err)
			});
    }
  }
}

</script>