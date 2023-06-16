window.generatePDF = async () => {
    var element = document.body;
    var canvas = await html2canvas(element);
    var imgData = canvas.toDataURL('image/png');
    var pdf = new jsPDF();
    pdf.addImage(imgData, 'PNG', 0, 0);
    pdf.save("download.pdf");
};
