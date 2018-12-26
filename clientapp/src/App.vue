<template>
<div>
  <table>
    <tr v-for="contry in contries" :key="contry.id">
      <td>{{contry.name}}</td>

      <button @click="id = contry.id"></button>
    </tr>
  </table>
  <h1>{{id}}</h1>
  <hello-world msg="Fuck you"/>
</div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'
import $ from 'jquery'
export default {
  name: 'app',
  components: {
    HelloWorld
  },
  created:function(){
    var funk = this.updateTable;
    $.ajax({
      url: "https://localhost:44317/api/country",
      type:"GET",
      success: function(e){
        funk(e); 
      },
      error:function(){
        
      }
    });
  },
  data:function(){
    return {
      id:null,
      contries:[]
    }
  },
  methods:{
    updateTable:function(e){
      this.contries = e;
    }
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
