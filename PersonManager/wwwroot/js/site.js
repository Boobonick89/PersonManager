// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showAddWindow() {
	document.getElementById("addWindow").showModal();
}

document.getElementById("addButton").addEventListener("click", showAddWindow);

function closeAddWindow() {
	document.getElementById("addWindow").close();
}

document.getElementById("closeButton").addEventListener("click", closeAddWindow);
