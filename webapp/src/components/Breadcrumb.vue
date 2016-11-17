<template>
    <div class="row">
        <ol class="breadcrumb">
            <li>
                <router-link to="/"><i class="fa fa-home" aria-hidden="true"></i></router-link>
            </li>
             <li v-for="item in items">
                <router-link :to="'/'+item.path">{{item.name}}</router-link>
            </li>
            <li class="active">{{current}}</li>
        </ol>
    </div>
</template>


<script>
export default {
  name: 'Breadcrumb',
  data () {
    return {}
  },
  props:['items','current']
}
</script>