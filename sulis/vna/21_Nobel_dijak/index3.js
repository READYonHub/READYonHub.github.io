const d = new Date();
let year = d.getFullYear();
//document.getElementById("maiev").innerHTML = year;

for (let i = year; i >= 1901; i--) {
    let option = document.createElement("option")
    option.innerHTML = i
    document.getElementById("evek").appendChild(option)
    if (i == 2022) {
        option.setAttribute("selected","")
    }
}

keresev(2022)

//változtat

function valaszt(){
    let aktev = document.getElementById("evek").value
    keresev(aktev)
}



 //keresés év szerint
 function keresev(ev){


    
    //alert(ev)
    var sz='<ul>'
    for (const elem of tomb.prizes) {
        if (elem.year==ev)
        {
            sz+=`<li>${elem.category}`
            if (typeof elem.laureates === "undefined"){
                sz+= "<br>Nem ismert!"
            }
            else {
                for (const szemely of elem.laureates) {
                    sz+=`<p>${szemely.firstname} ${szemely.surname}</p>`
                }
            }
                    
                    
                    
            sz+=`</li> `
        }
    }
    sz+='</ul>'
    document.getElementById("talalatev").innerHTML=sz
}