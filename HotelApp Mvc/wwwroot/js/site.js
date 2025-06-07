// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function myFunction() {
    let x = document.getElementById("myrange1").value;
    document.getElementById("rangeValue").innerHTML = x;
}

function TimeFunc() {

    var sTime = document.getElementById("StartTime").value;
    var stime2 = new Date(sTime);
    var ETime = document.getElementById("EndTime").value;
    var etime2 = new Date(ETime);

    if (stime2 < etime2) {
        var timeDiff = Math.abs(etime2.getTime() - stime2.getTime());

        // تبدیل میلی‌ثانیه به روز
        var tdays = Math.ceil(timeDiff / (1000 * 3600 * 24));

        document.getElementById("days").value = tdays;
        /*document.getElementById("days").innerText = tdays; */
    }
    else if (stime2 > etime2) {
        alert("تاریخ های وارد شده اشتباه می باشند ");
    }
    else if (stime2 == etime2) {
        alert("شما باید حداقل یک روز در هتل اقامت داشته باشد ! ")
    }

    var roomprice = parseInt(document.getElementById("roomprice").innerHTML); 
    var price2 = tdays * roomprice;
    document.getElementById("price1").value = price2;


    //reserve form 
/*    document.getElementById("chIn1").innerHTML = stime2;
    document.getElementById("chOut1").innerHTML = etime2;
    document.getElementById("ResPrice").innerHTML = price2;

    var selectedAdult = document.getElementById("selAdult").value;
    var selectedChild = document.getElementById("selchild").value;
    var sumCap = selectedAdult + selectedChild;
    document.getElementById("ResCap").innerHTML = sumCap;*/ 
     
    

}
var values = [];
function savevalues() {
    var stime = stime2;
    var etime = etime2;
    var endprice = price2;

    var selectedAdult = document.getElementById("selAdult").value;
    var selectedChild = document.getElementById("selchild").value;
    var sumCap = selectedAdult + selectedChild;

    values[0] = stime;
    values[1] = etime;
    values[2] = endprice;
    values[3] = sumCap;
    window.location.href = "https://localhost:7004/Reserves/RoomReserve"
    /*        values.push(stime);
            values.push(etime);
            values.push(endprice);
            values.push(sumCap); */
}
function displayvalues() {
    document.getElementById("chIn1").innerHTML = values[0];
    document.getElementById("chOut1").innerHTML = values[1];
    document.getElementById("ResPrice").innerHTML = values[2];
    document.getElementById("ResCap").innerHTML = values[3];
}