//var j = 2;

//function filter() {
//    var input, filter, table, tr, td, i, txtValue;
//    input = document.getElementById("Input");
//    filter = input.value.toUpperCase();
//    table = document.getElementById("Table");
//    tr = table.getElementsByTagName("tr");

//    for (i = 0; i < tr.length; i++) {
//        td = tr[i].getElementsByTagName("td")[j];
//        if (td) {
//            txtValue = td.textContent || td.innerText;
//            if (txtValue.toUpperCase().indexOf(filter) > -1) {
//                tr[i].style.display = "";
//            } else {
//                tr[i].style.display = "none";
//            }
//        }
//    }
//}

//document.getElementById("Select").addEventListener('change', (event) => {
//    console.log(event.target.value);
//    j = event.target.value;
//    document.getElementById("Input").placeholder = "Search for " + event.target.options[event.target.selectedIndex].text.toLowerCase() + "..";
//});

document.getElementById("MainSelect").addEventListener('change', (e) => {
    if (e.target.value == "diff") {
        document.getElementsByClassName("diff")[0].style.display = "inline";
        document.getElementsByClassName("fl")[0].style.display = "none";
        document.getElementsByClassName("pn")[0].style.display = "none";
    }
    else if (e.target.value == "fl") {
        document.getElementsByClassName("diff")[0].style.display = "none";
        document.getElementsByClassName("fl")[0].style.display = "inline";
        document.getElementsByClassName("pn")[0].style.display = "none";
    }
    else if(e.target.value == "pn"){
        document.getElementsByClassName("diff")[0].style.display = "none";
        document.getElementsByClassName("fl")[0].style.display = "none";
        document.getElementsByClassName("pn")[0].style.display = "inline";
    }
});