<template>
  <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
    <breadcrumb :current="''"></breadcrumb>

    <div class="row">
      <div class="col-lg-12">
        <h1 class="page-header">Painel</h1>
      </div>
    </div>
    <!--/.row-->

    <div class="row">
      <div class="col-lg-4">
        <div class="panel panel-default">
          <div class="panel-heading">Atividades</div>
          <div class="panel-body">
            <ul class="todo-list">
              <router-link tag="li" :to="'/atividade/'+atividade.id" class="todo-list-item" v-for="atividade in atividades">
                <div class="checkbox">
                  {{atividade.descricao}}
                </div>
                <div class="pull-right">
                  <i class="fa fa-check"v-bind:class="[editing ? 'fa-check' : 'fa-spinner', 'fa']" aria-hidden="true"></i>
                </div>
              </router-link>
            </ul>
          </div>
        </div>
      </div>

      <div class="col-lg-8">
        <div class="panel panel-default">
          <div class="panel-heading">Rota </div>
          <div class="panel-body">
          </div>
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col-md-4">
        <div class="panel panel-default">
          <div class="panel-heading">Calendário</div>
          <div class="panel-body">
          </div>
        </div>
      </div>

      <div class="col-md-8">
        <div class="panel panel-default">
          <div class="panel-heading">Oportunidades</div>
          <div class="panel-body">
          </div>
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col-lg-12">
        <h1 class="page-header">KPI</h1>
      </div>
    </div>

  </div>
</template>

<script>
export default {
  name: 'dashboard',
  data () {
    return {atividades:[]}
  },
  mounted:function(){
    this.$http.get('http://localhost:49559/api/vendedores/'+this.$root.vendedor.id+'/atividades?dataInicio=2010-11-15&dataFim=2016-11-15')
		.then((response)=>{
			this.atividades=response.body;
		})
  }
}
</script>
