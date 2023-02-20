var sz=""
var db=1

for (let i = 0; i < 2; i++){
    for (let j = 0; j < 3; j++) {
        sz+='<img id="'+db+'" onmouseout="leemeles(this.id)" onmouseover="kiemeles(this.id)" onclick="nagyit(this.id)" style="width: 70px ; margin:5px;" src="kepek/mando'+db+'.jpg" alt="">'
        db+=1
    }
    sz+="<br>"
}

document.getElementById("keret").innerHTML=sz

function nagyit(kepid){
    document.getElementById("kephely").src="kepek/mando"+kepid+".jpg"
}

function kiemeles(kepid) {
    document.getElementById(kepid).style.border="2px solid blue"
    document.getElementById(kepid).style.borderRadius="50%"
}

function leemeles(kepid){
    document.getElementById(kepid).style.border="none"
    document.getElementById(kepid).style.borderRadius="0%"
}