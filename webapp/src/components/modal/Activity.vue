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
            <select class="form-control" id="tipo" v-model="selected">
              <option v-for="option in options" v-bind:value="option.value">
                TODO
              </option>
            </select>
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
            <label for="datetime">Data de Inicio</label>
            <input type="datetime-local" class="form-control" id="dataInicio" v-model="atividade.dataInicio" placeholder="Data de Inciio">
          </div>
          <div class="form-group">
            <label for="datetime">Data de Fim</label>
            <input type="datetime-local" class="form-control" id="dataFim" v-model="atividade.dataInicio" placeholder="Data de Fim">
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
  export default {
    name: 'CreateActivityModal',
    data () {
      return {atividade: {}, options:[{'text': 'FEITA',value:1}, {'text': 'INCOMPLETA',value:0}]}
    },
    methods:{
      createActivity: function(e){
  //TODO: FAZER QUANDO TIPO NAO FOR ID!
      /*  this.$http.post('http://localhost:49559/api/atividades/', this.atividade)
          .then((response)=>{
            console.log(response);
          },(err)=>{
            console.log(err)
  			});*/
        console.log('yay fez pedido ' + this.atividade.dataInicio)
      }
  }
}
</script>
