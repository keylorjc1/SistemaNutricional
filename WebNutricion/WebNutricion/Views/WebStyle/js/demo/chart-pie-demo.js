var proteinaData = [];
var actividadFisicaData = [];
var objetivoData = [];

// Llenar los arrays con los datos correspondientes
for (var i = 0; i < planificacionNutricionalData.length; i++) {
    proteinaData.push(planificacionNutricionalData[i].proteinas);
    actividadFisicaData.push(planificacionNutricionalData[i].actividadfisica);
    objetivoData.push(planificacionNutricionalData[i].objetivo);
}

// Pie Chart Example
var ctx = document.getElementById("myPieChart");
var myPieChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels: ["Proteinas", "Actividad Fisica", "Objetivo"],
        datasets: [{
            data: [proteinaData, actividadFisicaData, objetivoData],
            backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc'],
            hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf'],
            hoverBorderColor: ["rgba(234, 236, 244, 1)", "rgba(234, 236, 244, 1)", "rgba(234, 236, 244, 1)"],
        }],
    },
    options: {
        maintainAspectRatio: false,
        tooltips: {
            backgroundColor: "rgb(255,255,255)",
            bodyFontColor: "#858796",
            borderColor: '#dddfeb',
            borderWidth: 1,
            xPadding: 15,
            yPadding: 15,
            displayColors: false,
            caretPadding: 10,
        },
        legend: {
            display: false
        },
        cutoutPercentage: 80,
    },
});
