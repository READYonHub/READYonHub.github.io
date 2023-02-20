var sz = ""
db=1
for (let i = 0; i < 2; i++) 
{
    for (let j = 0; j < 3; j++)
    {
        sz += '<img style="width:150px;" src="mando'+db+'.jpg" alt="">'
        db++
    }
    sz += "<br>"
}
document.getElementById("kepecskek").innerHTML =  sz

function nagyit(kepid){
    document.getElementById("kephely").src="kepek/mando"+kepid+".jpg"
}
