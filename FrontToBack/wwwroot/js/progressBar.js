
// Section 2 Start

function progress() {
    var prg = document.getElementById("progress");
    var percent=document.getElementById("percentCount");
    var counter = 5;
    var progress =25;
    var id =setInterval(frame,28.6)

    function frame() {
        if (progress == 475 && counter == 95) {
            clearInterval(id);
        }else{
            progress +=5;
            counter +=1;
            prg.style.width =progress + 'px';
            percent.innerHTML = counter + '%';
        }
    }
}
progress();

function progress1() {
    var prg1 = document.getElementById("progress1");
    var percent1=document.getElementById("percentCount1");
    var counter1 = 5;
    var progress1 =25;
    var id =setInterval(frame,34)

    function frame() {
        if (progress1 == 400 && counter1 == 80) {
            clearInterval(id);
        }else{
            progress1 +=5;
            counter1 +=1;
            prg1.style.width =progress1 + 'px';
            percent1.innerHTML = counter1 + '%';
        }
    }
}
progress1();

function progress2() {
    var prg2 = document.getElementById("progress2");
    var percent2=document.getElementById("percentCount2");
    var counter2 = 5;
    var progress2 =25;
    var id =setInterval(frame,50.6)

    function frame() {
        if (progress2 == 275 && counter2 == 55) {
            clearInterval(id);
        }else{
            progress2 +=5;
            counter2 +=1;
            prg2.style.width =progress2 + 'px';
            percent2.innerHTML = counter2 + '%';
        }
    }
}
progress2();

function progress4() {
    var prg4 = document.getElementById("progress4");
    var percent4=document.getElementById("percentCount4");
    var counter4 = 5;
    var progress4 =25;
    var id =setInterval(frame,28.6)

    function frame() {
        if (progress4 == 475 && counter4 == 95) {
            clearInterval(id);
        }else{
            progress4 +=5;
            counter4 +=1;
            prg4.style.width =progress4 + 'px';
            percent4.innerHTML = counter4 + '%';
        }
    }
}
progress4();

function progress5() {
    var prg5 = document.getElementById("progress5");
    var percent5=document.getElementById("percentCount5");
    var counter5 = 5;
    var progress5 =25;
    var id =setInterval(frame,34)

    function frame() {
        if (progress5 == 400 && counter1 == 80) {
            clearInterval(id);
        }else{
            progress5 +=5;
            counter5 +=1;
            prg5.style.width =progress5 + 'px';
            percent5.innerHTML = counter5 + '%';
        }
    }
}
progress5();

function progress6() {
    var prg6 = document.getElementById("progress6");
    var percent6=document.getElementById("percentCount6");
    var counter6 = 5;
    var progress6 =25;
    var id =setInterval(frame,50.6)

    function frame() {
        if (progress6 == 275 && counter2 == 55) {
            clearInterval(id);
        }else{
            progress6 +=5;
            counter6 +=1;
            prg6.style.width =progress6 + 'px';
            percent6.innerHTML = counter6 + '%';
        }
    }
}
progress6();

// Section 2 End

// Section 3 Start
function progressBig1() {
    var prgBig1 = document.getElementById("progress-Big1");
    var percentBig1=document.getElementById("percentCount-Big1");
    var counterBig1 = 1;
    var progressBig1 =11;
    var id =setInterval(frame,26.3)

    function frame() {
        if (progressBig1 == 1045 && counterBig1 == 95) {
            clearInterval(id);
        }else{
            progressBig1 +=11;
            counterBig1 +=1;
            prgBig1.style.width =progressBig1 + 'px';
            percentBig1.innerHTML = counterBig1 + '%';
        }
    }
}
progressBig1();

function progressBig2() {
    var prgBig2 = document.getElementById("progress-Big2");
    var percentBig2=document.getElementById("percentCount-Big2");
    var counterBig2 = 1;
    var progressBig2 =11;
    var id =setInterval(frame,32.3)

    function frame() {
        if (progressBig2 == 880 && counterBig2 == 80) {
            clearInterval(id);
        }else{
            progressBig2 +=11;
            counterBig2 +=1;
            prgBig2.style.width =progressBig2 + 'px';
            percentBig2.innerHTML = counterBig2 + '%';
        }
    }
}
progressBig2();

function progressBig3() {
    var prgBig3 = document.getElementById("progress-Big3");
    var percentBig3=document.getElementById("percentCount-Big3");
    var counterBig3 = 1;
    var progressBig3 =11;
    var id =setInterval(frame,48.2)

    function frame() {
        if (progressBig3 == 605 && counterBig3 == 55) {
            clearInterval(id);
        }else{
            progressBig3 +=11;
            counterBig3 +=1;
            prgBig3.style.width =progressBig3 + 'px';
            percentBig3.innerHTML = counterBig3 + '%';
        }
    }
}
progressBig3();
// Section 3 End