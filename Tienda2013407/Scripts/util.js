$(document).ready(function () {
    $('#productosTbl').DataTable();
});

function showAddModal() {
    $('#modalAdd').modal();
}

function showDetailModal() {
    $('#modalDetail').modal();
}

function showEditModal() {
    $('#modalEdit').modal();
}

function downloadFile() {
    window.top.location.href = '/api/Productoes/DownloadFile';
}