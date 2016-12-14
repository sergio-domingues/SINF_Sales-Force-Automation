<template>
  <div class="modal fade"  id="create-activity-modal" tabindex="-1" role="dialog" aria-labelledby="CreateActivityModal">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h4 class="modal-title">Nova Atividade</h4>
        </div>

        <form v-on:submit.prevent="createActivity">
          <div class="modal-body">
            <div class="form-group">
              <label for="Tipo">Tipo</label>
              <select class="form-control" id="tipo" v-model="atividade.idTipoAtividade">
                <option v-for="tipo in tipos" v-bind:value="tipo.value">
                  {{ tipo.text }}
                </option>
              </select>
            </div>

            <div class="form-group">
              <label for="resumo">Resumo</label>
                <input type="text" class="form-control" id="resumo" placeholder="resumo atividade" v-model="atividade.resumo" :value="atividade.resumo">
            </div>

            <div class="form-group">
              <label for="Tipo">Estado</label>
              <select class="form-control" id="estado" v-model="atividade.estado">
                <option v-for="option in options" v-bind:value="option.value">
                  {{ option.text }}
                </option>
              </select>
            </div>

            <div class="form-group">
              <label for="Tipo">Cliente</label>
              <select class="form-control selectpicker" id="estado" v-model="atividade.idContactoPrincipal" data-live-search="true" required>
                <option v-for="cliente in clientes" v-bind:value="cliente.CodCliente">
                  {{ cliente.Nome }}
                </option>
              </select>
            </div>

            <div class="form-group">
              <label for="Tipo">Oportunidade</label>
              <select class="form-control selectpicker" id="estado" v-model="atividade.idCabecalhoOportunidadeVenda" data-live-search="true" required>
                <option v-for="oportunidade in oportunidades" v-bind:value="oportunidade.id">
                  {{ oportunidade.descricao }}
                </option>
              </select>
            </div>

            <div class="form-group">
              <label for="datetime">Data de Inicio</label>
              <input type="datetime-local" class="form-control" id="dataInicio" v-model="atividade.dataInicio" placeholder="Data de Inciio">
            </div>
            <div class="form-group">
              <label for="datetime">Data de Fim</label>
              <input type="datetime-local" class="form-control" id="dataFim" v-model="atividade.dataFim" placeholder="Data de Fim">
            </div>
            <div class="form-group">
              <label for="local">Local</label>
              <input type="text" class="form-control" id="local" v-model="atividade.local" placeholder="Local">
            </div>
            <div class="form-group">
              <label for="descricao">Descrição</label>
              <textarea class="form-control" rows="3"  v-model="atividade.descricao">
              </textarea>
            </div>

            <div class="modal-footer">
              <button type="submit" class="btn btn-primary">Confirmar</button>
            </div>
          </form>
        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
  </template>


  <script>
  import config from '../../assets/config.json'
  export default {
    name: 'CreateActivityModal',
    data () {
      return {atividade: {vendedor:this.$root.vendedor.id}, options:[{'text': 'FEITA',value:1}, {'text': 'INCOMPLETA',value:0}], tipos: [],clientes: [], oportunidades: []}
    },
    mounted: function(){
      this.$http.get(config.host+'/api/atividades/tipos')
      .then((response)=>{
        for(var tipo of response.body){
          this.tipos.push({text:tipo.descricao, value:tipo.id});
        }
      })

      this.$http.get(config.host+'/api/clientes')
      .then((response)=>{
          this.clientes=response.body;
          this.$nextTick(()=>{
            $('.selectpicker').selectpicker('refresh');
          })
      })

      this.$http.get(config.host+'/api/vendedores/'+this.$root.vendedor.id+'/oportunidades')
      .then((response)=>{
          this.oportunidades=response.body;
          this.$nextTick(()=>{
            $('.selectpicker').selectpicker('refresh');
          })
      })


    },
    methods:{
      createActivity: function(e){
        this.atividade.tipoEntidadePrincipal = "C";
        console.log('Infos antes de criar atividade');
        console.log(this.atividade);
        this.$http.post(config.host+'/api/atividades/', this.atividade)
        .then((response)=>{
          if(response.status == 201){
            $('#create-activity-modal').modal('hide');
          }else{
              console.log(this.atividade)
              console.log(response);
          }
        },(err)=>{
          console.log(err)
        });
      }
    }
  }
  </script>
