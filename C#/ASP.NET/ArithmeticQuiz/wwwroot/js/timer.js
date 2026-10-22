let startDate = new Date().getTime() + parseInt(document.getElementById("timer").innerHTML.slice(0, 2)) * 60 * 1000;

let x = setInterval(function () {

    let now = new Date().getTime();

    let diff = (startDate - now);

    let minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60));
    let seconds = Math.floor((diff % (1000 * 60)) / 1000);

    if (minutes < 10  && seconds >= 10)
        document.getElementById("timer").innerHTML = "0" + minutes + ":" + seconds;
    else if (minutes < 10 && seconds < 10)
        document.getElementById("timer").innerHTML = "0" + minutes + ":" + "0" + seconds;
    else
        document.getElementById("timer").innerHTML = minutes + ":" + seconds;

    if (diff <= 0) {
        clearInterval(x);
        document.getElementById("save").disabled=true;
    }
}, 1000);