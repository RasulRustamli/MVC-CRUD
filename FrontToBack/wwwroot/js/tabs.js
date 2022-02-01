//Section 2 Start

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


  function openCity1(evt1, cityName1) {
    var i, tabcontent1, tablinks1;
    tabcontent1 = document.getElementsByClassName("tabcontent1");
    for (i = 0; i < tabcontent1.length; i++) {
      tabcontent1[i].style.display = "none";
    }
    tablinks1 = document.getElementsByClassName("tablinks1");
    for (i = 0; i < tablinks1.length; i++) {
      tablinks1[i].className = tablinks1[i].className.replace(" active", "");
    }
    document.getElementById(cityName1).style.display = "block";
    evt1.currentTarget.className += " active";
  }
  document.getElementById("defaultOpen1").click();

//Section 2 End


//   Section 3 Start

function openCity3(evt, cityName) {
    var i, tabcontent3, tablinks3;
    tabcontent3 = document.getElementsByClassName("tabcontent3");
    for (i = 0; i < tabcontent3.length; i++) {
      tabcontent3[i].style.display = "none";
    }
    tablinks3 = document.getElementsByClassName("tablinks3");
    for (i = 0; i < tablinks3.length; i++) {
      tablinks3[i].className = tablinks3[i].className.replace(" active", "");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
  }
  document.getElementById("defaultOpen2").click();

  //   Section 3 End

  //   Section 4 Start

  function openCity4(evt, cityName) {
    var i, tabcontent4, tablinks4;
    tabcontent4 = document.getElementsByClassName("tabcontent4");
    for (i = 0; i < tabcontent4.length; i++) {
      tabcontent4[i].style.display = "none";
    }
    tablinks4 = document.getElementsByClassName("tablinks4");
    for (i = 0; i < tablinks4.length; i++) {
      tablinks4[i].className = tablinks4[i].className.replace(" active", "");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
  }
  document.getElementById("defaultOpen3").click();
  //   Section 4 End