<template>
    <div class="container">

      <form v-on:submit.prevent="requestLogin" class="form-signin">
        <h2 class="form-signin-heading">Please Login</h2>
        <label for="inputEmail" class="sr-only">Email</label>
        <input type="email" id="inputEmail" class="form-control" placeholder="Email address" v-model="Email" required autofocus>
        <label for="inputPassword" class="sr-only">Password</label>
        <input type="password" id="inputPassword" class="form-control" placeholder="Password" v-model="Password" required>
        <button class="btn btn-lg btn-primary btn-block" type="submit">Login</button>
      </form>

    </div> <!-- /container -->
</template>

<script>
import config from '../assets/config.json'

export default {
  name: 'Login',
  data () {
    return {failed:false,Email:'',Password:''}     //todo
  },
  methods:{
      requestLogin:function(){
        this.$http.post(config.host+'/api/authentication',{Email:this.Email,Password:this.Password})
          .then((response)=>{
              if(response.body ==='___'){  //admin mode
                  this.$root.auth=true;
                  this.$root.adminMode=true;
                  this.$emit('loggedIn');
              }else if(!isNaN(response.body.trim())){   //sales rep
                this.$root.auth=true;
                this.$root.vendedor.id=response;
                this.$emit('loggedIn');
              }else{
                alert('Email/Password não estão correctas!');
              }
          })
      }
  }

}
</script>
