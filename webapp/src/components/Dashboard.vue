<template>
  <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
    <breadcrumb :current="''"></breadcrumb>

    <div v-show="!this.$root.adminMode" class="row">
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
      <div class="col-xs-6 col-md-3">
        <div class="panel panel-default">
          <div class="panel-body easypiechart-panel">
            <h4>Objetivo Mensal</h4>
            <div class="easypiechart" id="easypiechart-blue" :data-percent="goal"><span class="percent">{{goal}}%</span>
            </div>
          </div>
        </div>
      </div>

      <div v-show="!this.$root.adminMode" class="col-md-8">
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
      <div class="page-header  col-lg-12">
        <h1 class="col-lg-6">KPI</h1>
        <h4 v-show="$root.adminMode" class="col-lg-6 text-right clicable" data-toggle="modal" data-target="#edit-goal-modal">
          <i class="fa fa-pencil pull-right" aria-hidden="true"></i>Editar Objetivos</h4>
      </div>
    </div>

    <div v-show="!this.$root.adminMode" class="col-xs-12 col-md-6 col-lg-4">
      <div class="panel panel-blue panel-widget ">
        <div class="row no-padding">
          <div class="col-sm-3 col-lg-5 widget-left">
            <i class="fa fa-shopping-bag fa-3x" aria-hidden="true"></i>
          </div>
          <div class="col-sm-9 col-lg-7 widget-right">
            <div class="large">{{kpi.NumTotalVendas}}</div>
            <div class="text-muted">Nº Vendas Totais</div>
          </div>
        </div>
      </div>
    </div>

    <div v-show="!this.$root.adminMode" class="col-xs-12 col-md-6 col-lg-4">
      <div class="panel panel-blue panel-widget ">
        <div class="row no-padding">
          <div class="col-sm-3 col-lg-5 widget-left">
            <i class="fa fa-shopping-bag fa-3x" aria-hidden="true"></i>
          </div>
          <div class="col-sm-9 col-lg-7 widget-right">
            <div class="large">{{kpi.NumVendasCompletas}}</div>
            <div class="text-muted">Nª Vendas Completas</div>
          </div>
        </div>
      </div>
    </div>

    <div v-show="!this.$root.adminMode" class="col-xs-12 col-md-6 col-lg-4">
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

    <div v-show="!this.$root.adminMode" class="col-md-6 col-lg-4">
      <div class="panel panel-blue">
        <div class="panel-heading">Melhores Clientes</div>
        <div class="panel-body overflow-panel" style="background-color: white">
          <div v-show="loading.kpi" class="spinner"></div>
          <ul class="todo-list">
            <router-link tag="li" :to="'/customers/'+key" class="todo-list-item clicable" v-for="(value, key) in kpi.MelhoresClientes">
              <div class="checkbox">
                {{key}}
              </div>
              <div class="pull-right">{{value}} €</div>
            </router-link>
          </ul>
        </div>
      </div>
    </div>


    <div v-show="!this.$root.adminMode" class="col-md-6 col-lg-4">
      <div class="panel panel-blue">
        <div class="panel-heading">Produtos Mais Vendidos</div>
        <div class="panel-body overflow-panel" style="background-color: white">
          <div v-show="loading.kpi" class="spinner"></div>
          <ul class="todo-list">
            <li class="todo-list-item" v-for="(value, key) in kpi.ProdutosMaisVendidos">
              <div class="checkbox">
                {{key}}
              </div>
             <div class="pull-right">{{value}} UN</div>
            </li>
          </ul>
        </div>
      </div>
    </div>

    <div v-show="!this.$root.adminMode" class="col-xs-12 col-md-6 col-lg-4">
      <div class="panel panel-blue panel-widget ">
        <div class="row no-padding">
          <div class="col-sm-3 col-lg-5 widget-left">
            <i class="fa fa-shopping-bag fa-3x" aria-hidden="true"></i>
          </div>
          <div class="col-sm-9 col-lg-7 widget-right">
            <div class="large">{{kpi.ValorTotalVendas}} €</div>
            <div class="text-muted">Valor Total de Vendas</div>
          </div>
        </div>
      </div>
    </div>




    <div v-show="!this.$root.adminMode" class="col-xs-12 col-md-6 col-lg-4">
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

    <div v-show="!this.$root.adminMode" class="col-xs-12 col-md-6 col-lg-4">
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

    <!-- KPI for Admin-->
    <div v-show="this.$root.adminMode" class="col-xs-12 col-md-6 col-lg-6">
      <div class="panel panel-blue panel-widget ">
        <div class="row no-padding">
          <div class="col-sm-3 col-lg-5 widget-left">
            <i class="fa fa-shopping-bag fa-3x" aria-hidden="true"></i>
          </div>
          <div class="col-sm-9 col-lg-7 widget-right">
            <div class="large">{{kpi.ValorMedioVendasPorVendedor}} €</div>
            <div class="text-muted">Valor Médio de Vendas por Vendedor</div>
          </div>
        </div>
      </div>
    </div>


    <div v-show="this.$root.adminMode" class="col-xs-12 col-md-6 col-lg-6">
      <div class="panel panel-blue">
        <div class="panel-heading">Melhores Vendedores</div>
        <div class="panel-body overflow-panel" style="background-color: white">
          <div v-show="loading.kpi" class="spinner"></div>
          <ul class="todo-list">
            <li class="todo-list-item" v-for="(value, key) in kpi.MelhoresVendedores">
              <div class="checkbox">
                {{key + '=>' + value}}
              </div>
              </router-link>
          </ul>
        </div>
      </div>
    </div>
    <edit-goal v-show="$root.adminMode"></edit-goal>

  </div>
  </div>
</template>

<script>
import config from '../assets/config.json'
import EditGoal from './modal/Goal'

function fillMap(atividades) {
  var uluru = {lat:41.1785734, lng:-8.5962233};
  var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 11,
    center: uluru
  });
  var geocoder = new google.maps.Geocoder();
  var bounds = new google.maps.LatLngBounds();
  for (var i = 0; i < atividades.length; i++) {
  	var atividade = atividades[i];
	geocoder.geocode({
	  address: atividades[i].local
	},
	function (position) {
		if (position.length > 0) {
			var infowindow = new google.maps.InfoWindow({
			    content: "<p><a href=\"#/activities/" + atividade.id + "\">" + atividade.resumo + "</a></p>" +
			    	"<p>" + atividade.dataInicio + " - " + atividade.dataFim + "</p>"
			  });
		  var marker = new google.maps.Marker({
		    position: position[0].geometry.location,
		    map: map
		  });
		  marker.addListener('click', function() {
		    infowindow.open(map, marker);
		  });
		  infowindow.open(map, marker);
		  atividade.position = marker.position;
		  bounds.extend(marker.position);
		  map.fitBounds(bounds);
		  if (map.getZoom() > 16) map.setZoom(16); // Avoid too much zoom
		}
    });
  }
}

export default {
  name: 'dashboard',
  data () {
    return {atividades:[],oportunidades:[],loading:{atividades:true,oportunidades:true,kpi:true},kpi:{},goal:0}
  },
  components:{EditGoal},
  mounted:function(){

    if(this.$root.adminMode){
      this.$http.get('http://localhost:49559/api/kpi/').then((response)=>{
        this.kpi=response.body;
        this.loading.kpi=false;
      });
    }else{
      this.$http.get(config.host+'/api/vendedores/'+this.$root.vendedor.id+'/atividades?dataInicio=2010-11-15&dataFim=2016-11-15')
      .then((response)=>{
        this.atividades=response.body;
        this.loading.atividades=false;
        fillMap(this.atividades);
      });

      this.$http.get(config.host+'/api/vendedores/'+this.$root.vendedor.id+'/oportunidades/')
      .then((response)=>{
        this.loading.oportunidades=false;
        this.oportunidades=response.body;
      });

      this.$http.get(config.host+'/api/objetivos/'+this.$root.vendedor.id)
      .then((response)=>{
        this.goal=Math.round(parseInt(response.body.ValorCumprido)/parseInt(response.body.Valor)*100);
        this.$nextTick(()=>{
          var element = document.querySelector('.easypiechart');
          new EasyPieChart(element, {
            barColor:'#30a5ff'
          });
        })
      });

      this.$http.get(config.host+'/api/kpi/'+this.$root.vendedor.id)
      .then((response)=>{
        this.loading.kpi=false;
        this.kpi=response.body;
      });
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
