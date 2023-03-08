var a=0;b=0;c=0;
var muvelet =0;
var muv=0; 
var vesszo = 0;

function beszamjegy(szam)
{
    if (document.getElementById("kijelzo").value == '0')
    {
        document.getElementById("kijelzo").value = szam;
    }
    else
    {
        document.getElementById("kijelzo").value += szam;
    }
}

function muveletvegzes(m)
{
    switch(m)
    {
        case 1:
            a = Number(document.getElementById("kijelzo").value);
            muv = 1;
            muvelet=1;
            vesszo=0;
            break;
        case 2:
            a = Number(document.getElementById("kijelzo").value);
            muv = 1;
            muvelet=2;
            vesszo=0;
            break; 
        case 3:
                a = Number(document.getElementById("kijelzo").value);
                muv = 1;
                muvelet=3;
                vesszo=0;
                break;
        case 4:
                a = Number(document.getElementById("kijelzo").value);
                muv = 1;
                muvelet=4;
                vesszo=0;
                break;           
    }
    document.getElementById("kijelzo").value = 0;
    document.getElementById("hiba").innerHTML = "";
}
function szamol()
{
    document.getElementById("hiba").innerHTML = "";
    if(muv==1)
    {
        b = Number(document.getElementById("kijelzo").value);
        switch(muvelet)
        {
            case 1 : c=a+b;break;
            case 2 : c=a-b;break;
            case 3 : c=a*b;break;
            case 4 : c=a/b;break;
        }
        document.getElementById("kijelzo").value 
    }
}