<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <HelloWorld :msg='msg'/>
    <p v-if="appreciations != null">{{appreciations}}</p>
    <button v-on:click="$adal.login()" >Sign In</button>
    <button v-on:click="$adal.logout()" >Sign Out</button>
    <button v-if="$adal.isAuthenticated()" v-on:click="getAppreciations()" >Get Appreciations</button>
    <div v-if="$adal.checkRoles(['Admin'])">You're also an admin</div>
    <div v-if="$adal.isAuthenticated()">You are signed in!</div>
    <div v-if="!$adal.checkRoles(['Admin'])">You're not an admin</div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src
import Axios from 'axios';

@Component({
  components: {
    HelloWorld
  },
  data () {
    return {
      msg: "Signing in...",
      appreciations: null
    }
  },
  async created () {
    if (this.$adal.isAuthenticated()) {
      this.msg = "Hello, " + this.$adal.user.profile.given_name 

      let userInfo = await this.getUserInfo()
      this.msg += '. It looks like your email address is ' + userInfo.mail + ' according to the Graph API'
    } else {
      this.msg = "Please sign in"
    }
  },

  methods: {
    async getUserInfo () {
      let res = await this.$graphApi.get(`me`, {
        params: {
          'api-version': 1.6
        }
      })
      console.log(res)
      return res.data
    },
    async getAppreciations (){
      Axios.get("http://localhost:7071/api/Appreciations?daysToLookBack=7")
      .then(Response => (this.$data.appreciations = Response))
    }
  }
})
export default class Home extends Vue {}
</script>
