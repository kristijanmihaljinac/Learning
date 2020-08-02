function analyzeColor(myColor) {
    switch (myColor) {
        case "Blue":
            alert("Just like the sky!");
            break
        case "Red":
            alert("Just like shiraz!");
            break
        default:
            alert("Suit yourself then...");
    }
}



// var myBankBalance = 0;
// var msg = "";

// while (myBankBalance <= 10) {
//   msg = msg + "My bank balance is $" + myBankBalance + "<br>";
//   myBankBalance ++;
// }
// document.write(msg);


function writeDate() {
    var currentDate = new Date(),
        day = currentDate.getDate(),
        month = currentDate.getMonth() + 1,
        year = currentDate.getFullYear();
    // document.write(day + "/" + month + "/" + year);
    document.getElementById("date").innerHTML = day + "/" + month + "/" + year;
}