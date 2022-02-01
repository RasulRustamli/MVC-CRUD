
// Section 2 For Accordion
let toggles = document.getElementsByClassName('toggle')
let contentDiv = document.getElementsByClassName('contenent')
let icons=document.getElementsByClassName('icon')

for (let i = 0; i < toggles.length; i++) {
   toggles[i].addEventListener('click',()=>{
       if (parseInt(contentDiv[i].style.height)
       != contentDiv[i].scrollHeight){
        contentDiv[i].style.height = contentDiv[i].scrollHeight + "px";
        toggles[i].style.color= "#000000"
        icons[i].classList.remove('fa-plus')
        icons[i].classList.add('fa-minus');
       } 
       else{
           contentDiv[i].style.height = "0px";
           toggles[i].style.color='#000000';
           icons[i].classList.remove('fa-minus');
           icons[i].classList.add('fa-plus');
       }
       for (let j = 0; j < contentDiv.length; j++) {
           if(j!==i){
            contentDiv[j].style.height = "0px";
            toggles[j].style.color='#000000';
            icons[j].classList.remove('fa-minus');
            icons[j].classList.add('fa-plus');
           }    
       }
           
       
   })
    
}

// Section 3 For Accordion
let toggles1 = document.getElementsByClassName('toggle1')
let contentDiv1 = document.getElementsByClassName('contenent1')
let icons1=document.getElementsByClassName('icon1')

for (let i = 0; i < toggles1.length; i++) {
    toggles1[i].addEventListener('click',()=>{
        if (parseInt(contentDiv1[i].style.height)
        != contentDiv1[i].scrollHeight){
         contentDiv1[i].style.height = contentDiv1[i].scrollHeight + "px";
         toggles1[i].style.color= "#000000"
         icons1[i].classList.remove('fa-plus')
         icons1[i].classList.add('fa-minus');
        } 
        else{
            contentDiv1[i].style.height = "0px";
            toggles1[i].style.color='#000000';
            icons1[i].classList.remove('fa-minus');
            icons1[i].classList.add('fa-plus');
        }
        for (let j = 0; j < contentDiv1.length; j++) {
            if(j!==i){
             contentDiv1[j].style.height = "0px";
             toggles1[j].style.color='#000000';
             icons1[j].classList.remove('fa-minus');
             icons1[j].classList.add('fa-plus');
            }    
        }
            
        
    })
     
 }
