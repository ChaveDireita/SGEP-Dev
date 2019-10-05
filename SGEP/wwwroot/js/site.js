// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

if (document.getElementById("lista-add-funcionario") != null)
{
    $(document).ready(function () {
        $('#lista-add-funcionario').multiselect();
    });
}