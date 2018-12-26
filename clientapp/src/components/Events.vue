<template>
<div id="count">
  <button @click="back">Назад</button>
    <table>
        <tr>
            <td>name</td>
      <td>location</td>
      <td>startDate</td>
      <td>enddate</td>
      <td>startReg</td>
      <td>endreg</td>
        </tr>
        <tr v-for="event in events" :key="event.id">
      <td>{{event.name}}</td>
      <td>{{event.location}}</td>
      <td>{{event.startDate}}</td>
      <td>{{event.enddate}}</td>
      <td>{{event.startReg}}</td>
      <td>{{event.endreg}}</td>
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
      url: "https://localhost:44317/api/event",
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
      events:[]
    }
  },
  methods:{
    updateTable:function(e){
      this.events = e;
    },
    back:function(){
      this.$router.go(-1);
    }
  }
}
</script>