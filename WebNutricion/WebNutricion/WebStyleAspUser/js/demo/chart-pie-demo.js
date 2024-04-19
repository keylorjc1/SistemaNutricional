
    var planificacionNutricionalData = @Html.Raw(JsonConvert.SerializeObject(Model.Item1, settings));

    // Crear arrays para cada conjunto de datos
    var pesos = [];
    var grasasCorporales = [];
    var grasas = [];

    // Llenar los arrays con los datos correspondientes
    for (var i = 0; i < planificacionNutricionalData.length; i++) {
        pesos.push(planificacionNutricionalData[i].peso);
    grasasCorporales.push(planificacionNutricionalData[i].grasacorporal);
    grasas.push(planificacionNutricionalData[i].grasas);
    }

    // Pie Chart Example
    var ctx = document.getElementById("myPieChart");
    var myPieChart = new Chart(ctx, {
        type: 'doughnut',
    data: {
        labels: ["Peso", "Grasa Corporal", "Grasas"],
    datasets: [{
        data: [pesos.reduce((a, b) => a + b, 0), grasasCorporales.reduce((a, b) => a + b, 0), grasas.reduce((a, b) => a + b, 0)],
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

