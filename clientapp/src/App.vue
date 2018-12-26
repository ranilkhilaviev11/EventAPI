
<template>
<div id="app">
    <p>
      <router-link to="/Countries">Перейти к Countries | </router-link> 
      <router-link to="/Companies">Перейти к Companies | </router-link>
      <router-link to="/Events">Перейти к Events</router-link> 
    </p>
    <router-view></router-view>
</div>
</template>


<script>
import Vue from 'vue'
import Router from 'vue-router'
import Countries from './components/Countries.vue'
import Companies from './components/Companies.vue'
import Events from './components/Events.vue'

Vue.use(Router)



const routes = [
  { path: '/Countries', component: Countries },
  { path: '/Companies', component: Companies },
  {path: '/Events', component: Events}
];
const router = new Router({
  routes
});
// const app = new Vue({
//   router
// }).$mount('#app');

export default {
  name: 'app',
  router,
  components: {
    Countries,
    // Events,
    Companies
  }  
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
