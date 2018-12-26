<template>
<div id="count">
  <button @click="back">Назад</button>
    <table>
      <tr>
        <td>name</td>
        </tr>
        <tr v-for="contry in contries" :key="contry.id">
      <td>{{contry.name}}</td>
    </tr>
  </table>
    </div>
</template>

<script>
import $ from 'jquery'
export default {
  name: 'count',
  components: {
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
    },
    back:function(){
      this.$router.go(-1);
    }
  }
}
</script>