function ShowPass()
{
    var x = document.getElementById("txtPassword");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}


function BepaalSoort() {
    var queryString = window.location.search;
    var urlParams = new URLSearchParams(queryString);
    var soort = urlParams.get('soort');
    document.getElementById("Header").innerText = "Aanmelden " + soort;
}

function Aanmelden() {
    //
    // Controleer invoervelden
    //
    var queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    var Soort = urlParams.get('soort');
    var Gebruiker = document.getElementById("txtGebruiker").value.trim();
    var Wachtwoord = document.getElementById("txtPassword").value.trim();
    if (Gebruiker === "") {
        alert("Gebruiker is niet ingevuld!");
        return;
    };

    if (Wachtwoord === "") {
        alert("Wachtwoord is niet ingevuld!");
        return;
    };
    //
    // Aanmelden via de Rest api
    //



    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
        id: Gebruiker,
        wachtwoord: Wachtwoord,
        soort: Soort
    });

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };

    fetch(ApiUrl + "Logon", requestOptions)
        .then(response => response.text())
        .then(result => {
            var SessionToken = JSON.parse(result);
            if (SessionToken.ok) {
             //   alert("Aanmelden is gelukt " + SessionToken.token)
                if (Soort.startsWith('leer')) {
                    var url = "LeerlingOverzicht.html?LeerlingId=" + SessionToken.id ;
                    window.location.replace(url);
                }
                else {
                    var url = "DocentInvoer.html?DocentId=" + SessionToken.id;
                    window.location.replace(url);
                }
            }
            else {
                alert("Aanmelden is niet gelukt. Controleer gebruiker en wachtwoord.")
            }
        })
        .catch(error => alert('Oeps, er is iets mis gegaan'));



}




