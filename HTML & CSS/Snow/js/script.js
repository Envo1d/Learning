function Winter(node) {
    this.node = node;
    this.timerToAdd;
    this.timerToCheck;
}
Winter.prototype.startSnow = function() {
    this.timerToAdd = setInterval(() => {
        let maxXCord = window.innerWidth;
        let add = Math.floor(Math.random() * (2 + 5) - 5);
        if (add == 1) {
            let sf = document.createElement('IMG');
            let id = Math.floor(Math.random() * (13 - 1) + 1);
            sf.src = `img/${id}.png`;
            sf.alt = 'snowflake';
            sf.classList.add('snowflake');
            sf.style.left = `${Math.floor(Math.random() * (maxXCord - 1) + 1)}px`;
            this.node.appendChild(sf);
        }
    }, 80);
    this.timerToCheck = setInterval(() => {
        Array.from(document.getElementsByClassName('snowflake'))
            .forEach((element) => {
                if (parseInt(getComputedStyle(element).top, 10) + 14 >= window.innerHeight) {
                    this.node.removeChild(element);
                }
            });
    }, 30);
}

Winter.prototype.stopSnow = function() {
    clearInterval(this.timerToAdd);
}

let winter = new Winter(document.getElementById('main'));

let isClicked = false;
document.getElementById('btn').addEventListener('click', event => {
    if (!isClicked) {
        event.target.textContent = 'Stop';
        winter.startSnow();
        isClicked = true;
    } else {
        isClicked = false;
        event.target.textContent = 'Start';
        winter.stopSnow();
    }
});