<template>
<div id="count">
  <button @click="back">Назад</button>
    <table>
      <tr>
        <td>name</td>
      <td>companyFieldOfActivity</td>
      </tr>
        <tr v-for="company in companies" :key="company.id">
      <td>{{company.name}}</td>
      <td>{{company.companyFieldOfActivity}}</td>
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
      url: "https://localhost:44317/api/company",
      type:"GET",
      success: function(e){
        funk(e); 
      },
      error:function(e){
        console.log(e);
      }
    });
  },
  data:function(){
    return {
      id:null,
      companies:[]
    }
  },
  methods:{
    updateTable:function(e){
      this.companies = e;
    },
    back:function(){
      this.$router.go(-1);
    }
  }
}
</script>