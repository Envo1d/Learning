function sum(x, y) {
    if (y === undefined) y = 5;
    if (x === undefined) x = 8;
    console.log(x + y);
}

sum();
sum(6);
sum(6, 4);

function cSum(x = 8, y = 10 + x) {
    console.log(x + y);
}

cSum();
cSum(6);
cSum(6, 4);

function argSum() {
    let res = 0;
    for (const n of arguments)
        res += n;
    console.log(res)
}

argSum(6);
argSum(6, 4);
argSum(6, 4, 5);

function display(season, ...temps) {
    console.log(season);
    for (index in temps) {
        console.log(temps[index])
    }
}

display("Весна", -2, -3, 4, 2, 5);
display("Лето", 20, 23, 31);

// функция параметр

function sum(x, y) {
    return x + y;
}
function subs(x, y) {
    return x - y;
}
function operation(x, y, func) {
    const res = func(x, y);
    console.log(res);
}

console.log("Sum");
operation(10, 6, sum);

console.log("Subtract");
operation(10, 6, subs);

// возвращение функции
function menu(n) {
    if (n == 1) return function (x, y) { return x + y; }
    else if (n == 2) return function (x, y) { return x - y; }
    else if (n == 3) return function (x, y) { return x * y; }
    return function () { return 0; }
}
const action = menu(1);
const result = action(2, 5);
console.log(result);