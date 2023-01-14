//tabla
var block_meret = 25;
var sorok = 20;
var oszlopok = 20;
var tabla;
var context; 

//snake head
var kigyo_X = block_meret * 5;
var kigyo_Y = block_meret * 5;

var sebesseg_X = 0;
var sebesseg_Y = 0;

var kigyo_felulet = [];

//food
var kaja_X;
var kaja_Y;

var jatek_vege = false;

window.onload = function() {
    tabla = document.getElementById("tabla");
    tabla.height = sorok * block_meret;
    tabla.width = oszlopok * block_meret;
    context = tabla.getContext("2d"); //used for drawing on the tabla

    placeFood();
    document.addEventListener("keyup", changeDirection);
    // update();
    setInterval(update, 1000/10); //100 milliseconds
}

function update() {
    if (jatek_vege) {
        return;
    }

    context.fillStyle="black";
    context.fillRect(0, 0, tabla.width, tabla.height);

    context.fillStyle="red";
    context.fillRect(kaja_X, kaja_Y, block_meret, block_meret);

    if (kigyo_X == kaja_X && kigyo_Y == kaja_Y) {
        kigyo_felulet.push([kaja_X, kaja_Y]);
        placeFood();
    }

    for (let i = kigyo_felulet.length-1; i > 0; i--) {
        kigyo_felulet[i] = kigyo_felulet[i-1];
    }
    if (kigyo_felulet.length) {
        kigyo_felulet[0] = [kigyo_X, kigyo_Y];
    }

    context.fillStyle="lime";
    kigyo_X += sebesseg_X * block_meret;
    kigyo_Y += sebesseg_Y * block_meret;
    context.fillRect(kigyo_X, kigyo_Y, block_meret, block_meret);
    for (let i = 0; i < kigyo_felulet.length; i++) {
        context.fillRect(kigyo_felulet[i][0], kigyo_felulet[i][1], block_meret, block_meret);
    }

    //game over conditions
    if (kigyo_X < 0 || kigyo_X > oszlopok*block_meret || kigyo_Y < 0 || kigyo_Y > sorok*block_meret) {
        jatek_vege = true;
        alert("Game Over");
        location.reload();
    }

    for (let i = 0; i < kigyo_felulet.length; i++) {
        if (kigyo_X == kigyo_felulet[i][0] && kigyo_Y == kigyo_felulet[i][1]) {
            jatek_vege = true;
            alert("Game Over");
            location.reload();
        }
    }
}

function changeDirection(e) {
    if (e.code == "ArrowUp" && sebesseg_Y != 1) {
        sebesseg_X = 0;
        sebesseg_Y = -1;
    }
    else if (e.code == "ArrowDown" && sebesseg_Y != -1) {
        sebesseg_X = 0;
        sebesseg_Y = 1;
    }
    else if (e.code == "ArrowLeft" && sebesseg_X != 1) {
        sebesseg_X = -1;
        sebesseg_Y = 0;
    }
    else if (e.code == "ArrowRight" && sebesseg_X != -1) {
        sebesseg_X = 1;
        sebesseg_Y = 0;
    }
}


function placeFood() {
    //(0-1) * oszlopok -> (0-19.9999) -> (0-19) * 25
    kaja_X = Math.floor(Math.random() * oszlopok) * block_meret;
    kaja_Y = Math.floor(Math.random() * sorok) * block_meret;
}
