function SearchSystem(input) {
    // Declare variables
    var filter, ul, a, i, txtValue;
    filter = input.value.toUpperCase();
    ul = document.getElementById("myUL");
    li = document.getElementById('lista').getElementsByTagName("tr");

    // Loop through all list items, and hide those who don't match the search query
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName('td')[1];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}
function showunity() {
    var e = document.getElementById("uniselect");
    var option = e.options[e.selectedIndex].value;
    var optionunidade = document.getElementById("addunidade");
    if (option == "other") {
        document.getElementById("campo_nome_unidade").value = "";
        document.getElementById("campo_abbr_unidade").value = "";
        optionunidade.hidden = false;
    }
    else {
        optionunidade.hidden = true;
    }
}