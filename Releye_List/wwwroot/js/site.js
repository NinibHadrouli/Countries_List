// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// ****** Ändring färgen änligt parameter som vi skickar (Rader i det här fallet) *****

// ****** Bestämma färg härifrån *****
var TableBackgroundNormalColor = "transparent";
var TableBackgroundMouseoverColor = "#FCE5E0";

function ChangeBackgroundColor(row) {
    row.style.backgroundColor = TableBackgroundMouseoverColor;
}

function RestoreBackgroundColor(row) {
    row.style.backgroundColor = TableBackgroundNormalColor;
}
//************************************
