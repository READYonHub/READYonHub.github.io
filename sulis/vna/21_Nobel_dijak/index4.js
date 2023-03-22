function nevetkeres(){
    console.log(tomb)
    let sz=""
    let nev=document.getElementById("benev").value
    for (const elem of tomb.prizes) {
        if (typeof elem.laureates === "undefined"){
        }
        else {
            for (const dijazott of elem.laureates) {
                if (typeof dijazott.firstname === "undefined" || typeof dijazott.surname === "undefined" ){
                }
                else{
                    if(dijazott.firstname.toUpperCase().includes(nev.toUpperCase()) || dijazott.surname.toUpperCase().includes(nev.toUpperCase())){
                        //alert(dijazott.surname)
                        sz+=`
                        <tr>
                        <td>
                        ${dijazott.firstname}
                        </td>
                        <td>
                        ${dijazott.surname}
                        </td>
                        <td>
                        ${elem.year}
                        </td>
                        </tr>`
                    }
            }
                
            }
            document.getElementById("kiirashelye").innerHTML=sz
        }
    }
}