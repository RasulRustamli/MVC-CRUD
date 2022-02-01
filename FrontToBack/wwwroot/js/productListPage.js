// For quantity Section 2
function increase(){
    var a = 1;
    var textBox = document.getElementById("text");
    textBox.value++;
    
}    
function decrease(){
  var textBox = document.getElementById("text");
    
    if (textBox.value>0) {
      textBox.value--;
    }
   
}
// For Tab Section 3
function openCity(evt, cityName) {
  var i, tabcontent, tablinks;
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }
  tablinks = document.getElementsByClassName("tablinks");
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].className = tablinks[i].className.replace(" active", "");
  }
  document.getElementById(cityName).style.display = "block";
  evt.currentTarget.className += " active";
}
document.getElementById("defaultOpen").click();

