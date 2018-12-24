function ale(){
    $.ajax({
        url: "/Home/Index",
        accept: 'application / json',
  success: function(){
    alert("Load was performed.");
  },
    error: function(){
alert("Nope.");
    }
});
}