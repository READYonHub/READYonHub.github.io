var tomb = 
[
"vicc1","rosszavicc2","kegyetlenvicc3","hitetlenvicc4","felejthetetlenvicc5",""
];

var kepek = [
    "1.png",
    "2.png",
    "3.png",
    "4.png",
    "5.png"
]

function vicc(){
//alert("Hello")
var vlt = Math.floor(Math.random() * tomb.length)
console.log(vlt)

document.getElementById("vicchelye").innerHTML=tomb[vlt]

document.getElementById("vicckepek").src = kepek[vlt]


}
vicc()