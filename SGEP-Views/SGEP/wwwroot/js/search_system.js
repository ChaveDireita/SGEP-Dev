function SearchSystem(input) {
    // Declare variables
    var filter, ul, a, i, txtValue;
    filter = input.value.toUpperCase();
    ul = document.getElementById("myUL");
    li = document.getElementById('lista').getElementsByTagName("tr");

    // Loop through all list items, and hide those who don't match the search query
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName('td')[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}