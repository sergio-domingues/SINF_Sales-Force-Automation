<template>
    <div class="modal fade" id="edit-goal-modal" tabindex="-1" role="dialog" aria-labelledby="EditGoalModal">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Editar Objetivo</h4>
                </div>

                <form v-on:submit.prevent="editGoal">
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="Vendedor">Vendedor</label>
                            <select class="form-control" id="vendedor" v-model="goalId">
                <option v-for="vendedor in vendedores" :value="vendedor.cod">
                  {{ vendedor.nome }}
                </option>
              </select>
                        </div>

                        <div class="form-group">
                            <label for="Valor">Valor</label>
                            <input type="text" class="form-control" id="valor" v-model="valor" placeholder="Valor do Objetivo">
                        </div>

                        <div class="modal-footer">
                            <button type="submit" class="btn btn-primary">Confirmar</button>
                        </div>
                </form>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
</template>



<script>
  import config from '../../assets/config.json'
  export default {
    name: 'EditGoalModal',
    data () {
      return {vendedores: [],valor: 800,goalId:''}
    },
    mounted: function(){

      this.$http.get(config.host+'/api/vendedores')
      .then((response)=>{
        this.vendedores=response.body;
      })


    },
    methods:{
      editGoal: function(e){
        this.$http.put(config.host+'/api/objetivos/'+this.goalId,parseInt(this.valor))
        .then((response)=>{
        console.log("successo");
        },()=>{
          alert('Erro ao editar o goal');
        })
    }
  }
}
  </script>