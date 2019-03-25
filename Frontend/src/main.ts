import Vue from 'vue';
import axios from 'axios'
import { default as Adal, AxiosAuthHttp } from 'vue-adal'
import App from './App.vue';
import router from './router';

Vue.config.productionTip = false;
const graphApiBase = `https://graph.windows.net`
const graphApiResource = '00000002-0000-0000-c000-000000000000'

Vue.use(Adal, {
  config: {
    tenant: '472d1d61-3d2e-415f-9dff-a6d01c634825',
    clientId: 'a62ecc88-8579-4bab-8827-d1e90efa56b7',
    redirectUri: 'http://localhost:8080',
    cacheLocation: 'localStorage'
  },
  requireAuthOnInitialize: false,
  router: router
})

Vue.use({
  install (vue, opts = {}) {
    // Configures an axios http client with a interceptor to auto-acquire tokens
    vue.prototype.$graphApi = AxiosAuthHttp.createNewClient({
      // Required Params
      axios: axios,
      resourceId: graphApiResource, // Resource id to get a token against

      // Optional Params
      router: router, // Enables a router hook to auto-acquire a token for the specific resource

      baseUrl: graphApiBase, // Base url to configure the client with

      onTokenSuccess (http: { defaults: { baseURL: string; }; }, context: { user: { profile: { tid: any; }; }; }, token: any) { // Token success hook
        // When an attempt to retrieve a token is successful, this will get called.
        // This enables modification of the client after a successful call.
        if (context.user) {
          // Setup the client to talk with the Microsoft Graph API
          http.defaults.baseURL = `${graphApiBase}/${context.user.profile.tid}`
        }
      },

      onTokenFailure (error: any) { // Token failure hook
        // When an attempt to retrieve a token is not successful, this will get called.
        console.log(error)
      }
    })
  }
})

new Vue({
  router,
  render: (h) => h(App),
}).$mount('#app');
