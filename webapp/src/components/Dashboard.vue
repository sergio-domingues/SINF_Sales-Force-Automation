<template>
  <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
    <breadcrumb :current="''"></breadcrumb>

    <div class="row">
      <div class="col-lg-12">
        <h1 class="page-header">Painel</h1>
      </div>
    </div>
    <!--/.row-->

    <div v-show="!this.$root.adminMode" class="row">
      <div class="col-lg-4">
        <div class="panel panel-default">
          <div class="panel-heading">Atividades</div>
          <div class="panel-body">
            <div v-show="loading.atividades" class="spinner"></div>
            <ul class="todo-list">
              <router-link tag="li" :to="'/activities/'+atividade.id" class="todo-list-item clicable" v-for="atividade in atividades">
                <div class="checkbox">
                  {{atividade.resumo}}
                </div>
                <div class="pull-right">
                  <i class="fa fa-check" v-bind:class="[atividade.estado ? 'fa-check' : 'fa-spinner', 'fa']" aria-hidden="true"></i>
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
            <div id="map"></div>
          </div>
        </div>
      </div>
    </div>

    <div v-show="!this.$root.adminMode" class="row">
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
            <div v-show="loading.oportunidades" class="spinner"></div>
            <ul class="todo-list">
              <router-link tag="li" :to="'/leads/'+oportunidade.id" class="todo-list-item clicable" v-for="oportunidade in oportunidades">
                <div class="checkbox">
                  {{oportunidade.descricao}}
                </div>
                <div class="pull-right">
                  <i class="fa fa-check" v-bind:class="[null ? 'fa-check' : 'fa-spinner', 'fa']" aria-hidden="true"></i>
                </div>
              </router-link>
            </ul>
          </div>
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col-lg-12">
        <h1 class="page-header">KPI</h1>
      </div>
    </div>

    <div class="col-xs-12 col-md-6 col-lg-3">
      <div class="panel panel-blue panel-widget ">
        <div class="row no-padding">
          <div class="col-sm-3 col-lg-5 widget-left">
            <i class="fa fa-shopping-bag fa-3x" aria-hidden="true"></i>
          </div>
          <div class="col-sm-9 col-lg-7 widget-right">
            <div class="large">{{kpi.NumTotalVendas}}</div>
            <div class="text-muted">Vendas Totais</div>
          </div>
        </div>
      </div>
    </div>

    <div class="col-xs-12 col-md-6 col-lg-3">
      <div class="panel panel-blue panel-widget ">
        <div class="row no-padding">
          <div class="col-sm-3 col-lg-5 widget-left">
            <i class="fa fa-shopping-bag fa-3x" aria-hidden="true"></i>
          </div>
          <div class="col-sm-9 col-lg-7 widget-right">
            <div class="large">{{kpi.NumVendasCompletas}}</div>
            <div class="text-muted">Valor Vendas</div>
          </div>
        </div>
      </div>
    </div>

    <div class="col-xs-12 col-md-6 col-lg-3">
      <div class="panel panel-blue panel-widget ">
        <div class="row no-padding">
          <div class="col-sm-3 col-lg-5 widget-left">
            <i class="fa fa-shopping-bag fa-3x" aria-hidden="true"></i>
          </div>
          <div class="col-sm-9 col-lg-7 widget-right">
            <div class="large">{{kpi.NumOportunidadesPendentes}}</div>
            <div class="text-muted">Oportunidades Pendentes</div>
          </div>
        </div>
      </div>
    </div>

    <div class="col-xs-12 col-md-6 col-lg-3">
      <div class="panel panel-blue panel-widget ">
        <div class="row no-padding">
          <div class="col-sm-3 col-lg-5 widget-left">
            <i class="fa fa-shopping-bag fa-3x" aria-hidden="true"></i>
          </div>
          <div class="col-sm-9 col-lg-7 widget-right">
            <div class="large">{{kpi.NovasOportunidades}}</div>
            <div class="text-muted">Novas Oportunidades</div>
          </div>
        </div>
      </div>
    </div>
    
    <div class="col-xs-12 col-md-6 col-lg-3">
      <div class="panel panel-blue panel-widget ">
        <div class="row no-padding">
          <div class="col-sm-3 col-lg-5 widget-left">
            <i class="fa fa-shopping-bag fa-3x" aria-hidden="true"></i>
          </div>
          <div class="col-sm-9 col-lg-7 widget-right">
            <div class="large">{{kpi.NumClientesAtivos}}</div>
            <div class="text-muted">Clientes Ativos</div>
          </div>
        </div>
      </div>
    </div>

    <div class="col-md-6 col-lg-6">
        <div class="panel panel-blue">
          <div class="panel-heading">Melhores Clientes</div>
          <div class="panel-body overflow-panel" style="background-color: white">
            <div v-show="loading.kpi" class="spinner"></div>
            <ul class="todo-list">
              <router-link tag="li" :to="'/customers/'+key" class="todo-list-item clicable" v-for="(value, key) in kpi.MelhoresClientes">
                <div class="checkbox">
                  {{key + '=>' + value}}
                </div>
              </router-link>
            </ul>
          </div>
        </div>
      </div>

    <div class="col-md-6 col-lg-6">
        <div class="panel panel-blue">
          <div class="panel-heading">Produtos Mais Vendidos</div>
          <div class="panel-body overflow-panel" style="background-color: white">
            <div v-show="loading.kpi" class="spinner"></div>
            <ul class="todo-list">
              <router-link tag="li" :to="'/customers/'+key" class="todo-list-item" v-for="(value, key) in kpi.ProdutosMaisVendidos">
                <div class="checkbox">
                  {{key + '=>' + value}}
                </div>
              </router-link>
            </ul>
          </div>
        </div>
      </div>

      

    </div>
  </div>
</template>

<script>
import config from '../assets/config.json'

function initMap() {
  var uluru = {lat:40.6570816, lng:-7.9137786};
  var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 10,
    center: uluru
  });
  var marker = new google.maps.Marker({
    position: uluru,
    map: map
  });
}

export default {
  name: 'dashboard',
  data () {
    return {atividades:[],oportunidades:[],loading:{atividades:true,oportunidades:true,kpi:true},kpi:{}}
  },
  mounted:function(){
    if(this.$root.adminMode){
      /*this.$http.get('http://localhost:49559/api/kpi/').then((response)=>{
        this.kpi=response.body;
        this.loading.kpi=false;
      });*/
    }else{
      this.$http.get(config.host+'/api/vendedores/'+this.$root.vendedor.id+'/atividades?dataInicio=2010-11-15&dataFim=2016-11-15')
      .then((response)=>{
        this.atividades=response.body;
        this.loading.atividades=false;
      });

      this.$http.get(config.host+'/api/vendedores/'+this.$root.vendedor.id+'/oportunidades/')
      .then((response)=>{
        this.loading.oportunidades=false;
        this.oportunidades=response.body;
      });

      this.$http.get(config.host+'/api/kpi/'+this.$root.vendedor.id)
      .then((response)=>{
        this.loading.kpi=false;
        this.kpi=response.body;
      });
      
      initMap();
    }
  }
}
</script>

<style>
  #map {
    height: 250px;
    width: 100%;
  }
</style>