// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleProfileMenu() {
    var profileMenu = document.getElementById('profile-menu');
    profileMenu.classList.toggle('hidden');
}

document.getElementById('profile-icon').addEventListener('click', toggleProfileMenu);