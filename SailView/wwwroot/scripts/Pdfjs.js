function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

window.downloadFile = function (fileName) {
    var link = document.createElement('a');
    link.href = fileName;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};
