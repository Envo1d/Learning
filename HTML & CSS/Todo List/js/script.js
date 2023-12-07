const clear = document.getElementsByClassName("clear");
const dateElem = document.getElementById("date");
const list = document.getElementById("list");
const input = document.getElementById("input");
const allBtn = document.getElementById("showAll");
const compBtn = document.getElementById("showComp");
const incBtn = document.getElementById("showInc");
const refreshBtn = document.getElementById("refresh");
const checked = "fa-check-circle";
const unchecked = "fa-circle-thin";
const line = "line";
let listC = [];
let id = 0;
let settings = { weekday: "long", month: "short", day: "numeric" };
let dateNow = new Date();
let dateString = dateNow.toLocaleDateString("ru-RU", settings)[0].toUpperCase() + dateNow.toLocaleDateString("ru-RU", settings).slice(1);
let isAllVisible = true;
let isCompVisible = false;
let isIncVisible = false;

dateElem.appendChild(document.createTextNode(dateString));

function add(task, id, isDone) {
    let completed = isDone ? checked : unchecked;
    let lineThrouhg = isDone ? line : "";
    let elem = `<li class="item" status='listelem'><i class="fa ${completed} co" status="complete" id=${id}></i><p class="task ${lineThrouhg}" status='text'>${task}</p><i class="fa fa-trash-o de" status="delete" id=${id}></i></li>`;
    list.insertAdjacentHTML("beforeend", elem);
}

document.addEventListener("keyup", function(event) {
    if (event.keyCode == 13) {
        let task = input.value;
        if (task) {
            add(task, id, false);
            listC.push({
                name: task,
                id: id,
                isDone: false,
            });
            id++;
            input.value = null;
        }
    }
});

allBtn.addEventListener('click', event => { showAll(); });
compBtn.addEventListener('click', event => { showComp(); });
incBtn.addEventListener('click', event => { showInc(); });
refreshBtn.addEventListener('click', event => { clearList(); });

function checkClick(element) {
    element.classList.toggle(checked);
    element.classList.toggle(unchecked);
    element.parentNode.querySelector(".task").classList.toggle(line);
    let id = 0;
    for (let i = 0; i < listC.length; i++) {
        if (listC[i].id == element.id) {
            id = i;
            break;
        }
    }
    listC[id].isDone = listC[id].isDone ? false : true;
}

function deleteClick(element) {
    element.parentNode.parentNode.removeChild(element.parentNode);
    let id = 0;
    for (let i = 0; i < listC.length; i++) {
        if (listC[i].id == element.id)
            id = i;
    }
    listC.splice(id, 1);
}

list.addEventListener("click", function(event) {
    const elem = event.target;
    const elemStatus = elem.attributes.status.value;

    if (elemStatus == "complete") {
        checkClick(elem);
    } else if (elemStatus == "delete") {
        deleteClick(elem);
    } else return;
});

function clearList() {
    while (list.firstChild) {
        list.firstChild.remove();
    }
    listC.length = 0;
}

function showComp() {
    if (!isCompVisible) {
        isCompVisible = true;
        isIncVisible = false;
        isAllVisible = false;
        while (list.firstChild) {
            list.firstChild.remove();
        }
        for (let i = 0; i < listC.length; i++) {
            if (listC[i].isDone == true)
                add(listC[i].name, listC[i].id, listC[i].isDone);
        }
    }
}

function showInc() {
    if (!isIncVisible) {
        isCompVisible = false;
        isIncVisible = true;
        isAllVisible = false;
        while (list.firstChild) {
            list.firstChild.remove();
        }
        for (let i = 0; i < listC.length; i++) {
            if (listC[i].isDone == false)
                add(listC[i].name, listC[i].id, listC[i].isDone);
        }
    }
}

function showAll() {
    if (!isAllVisible) {
        isAllVisible = true;
        while (list.firstChild) {
            list.firstChild.remove();
        }
        isCompVisible = false;
        isIncVisible = false;
        for (let i = 0; i < listC.length; i++) {
            add(listC[i].name, listC[i].id, listC[i].isDone);
        }
    }
}