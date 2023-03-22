console.log(tomb)
var sz='';
var sorszam = 0;
for (const elem of tomb.prizes) {
    sz+=`<div class="col-sm-4" data-bs-toggle="modal" data-bs-target="#myModal" onclick="katt(this.id)" id="${sorszam}">
        <div style="border:1px solid black;margin:10px;padding:10px;box-shadow:5px 5px 5px">
         <p>${elem.category}</p>
         <p>${elem.year}</p>
        </div>
        </div>`
    sorszam+=1
}

document.getElementById("ide").innerHTML=sz

function katt(hanyadik){
    //alert(hanyadik)
    var szoveg = ""
    if (typeof tomb.prizes[hanyadik].laureates === "undefined"){
        szoveg+= "Nem ismert!"
    }
    else {
        for (const elem  of tomb.prizes[hanyadik].laureates) {
            szoveg+=`<p> `
            if (typeof elem.firstname === "undefined"){
    
            }
            else {
                szoveg+= elem.firstname + ' '
            }
            if (typeof elem.surname === "undefined"){
    
            }
            else {
                szoveg+= elem.surname
            }
            szoveg+= `</p>
            <p> ${elem.motivation} </p>
            `
        }
    }

    
    document.getElementById("torzs").innerHTML= szoveg
}

