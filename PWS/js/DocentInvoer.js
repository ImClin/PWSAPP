fetchDocent();
var DocentId = '';
var VakId = 0;

function fetchDocent() {

    // Ondewrstaande even uit nu even altijd vanwege testen met SMI
    var queryString = window.location.search;
    var urlParams = new URLSearchParams(queryString);
    DocentId = urlParams.get('DocentId');
    document.getElementById("hidDocentId").value = DocentId;

    const requestOptions = {
        method: 'GET',
        redirect: 'follow',
        credentials: 'include'
    };

    try {
        let url = ApiUrl + "Docent/MijnGegevens/" + DocentId
        fetch(url, requestOptions)
            .then(function (response) {
                return response.json();
            })
            .then(function (response) {
                document.getElementById("TabelNaam").innerHTML = response.naam + " - " + response.omschrijving;
                VakId = response.vakId;
                fetchCijfers();
            })
            .catch(error => alert(`Oeps, er is iets mis gegaan :${error.message} `))



    }
    catch (error) {
        alert(`Oeps, er is iets mis gegaan :${error.message} `);
    }


}


function fetchCijfers() {

    const requestOptions = {
        method: 'GET',
        redirect: 'follow',
        credentials: 'include'
    };

    try {
        let url = ApiUrl + "Docent/MijnKlas/" + VakId;
        fetch(url, requestOptions)
            .then(function (response) {
                return response.json();
            })
            .then(function (leerlingen) {
                let tblBody = document.querySelector("#LeerlingData");
                //
                // Per leerling een regel aanmaken
                //
                for (let leerling of leerlingen) {
                    let AantalCijfers = 0;
                    let Totaal = 0;
                    const row = document.createElement("tr");
                    //
                    const cell = document.createElement("td");
                    cell.innerText = leerling.naam;
                    cell.style.width = "200px";
                    row.appendChild(cell);
                    //
                    // Per leerling max 5 cijfer velden
                    //
                    for (let step = 0; step < 5; step++) {

                        const CijferCell = document.createElement("td");
                        var CijferInput = document.createElement("INPUT");
                        CijferInput.setAttribute("type", "number");
                        CijferInput.setAttribute("id", `Cijfer_${leerling.leerlingId}_${step}`);
                        CijferInput.setAttribute("placeholder", "0.0");
                        CijferInput.setAttribute("min", "1.0");
                        CijferInput.setAttribute("max", "10.0");
                        CijferInput.style.width = "50px";


                        if (leerling.behaald.length > step) {
                            AantalCijfers += 1;
                            let Cijfer = ((leerling.behaald.at(step)) / 10);
                            CijferInput.setAttribute("value", Cijfer);
                            Totaal += leerling.behaald.at(step);
                            if (Cijfer < 5.5)
                                CijferInput.style.color = 'red';
                        }
                        else
                            CijferInput.setAttribute("value", "");

                        CijferCell.appendChild(CijferInput);
                        row.appendChild(CijferCell);
                    }
                    //
                    // Gemiddelde berekenen
                    //
                    const GemCell = document.createElement("td");
                    var GemInput = document.createElement("INPUT");
                    GemInput.setAttribute("type", "number");
                    GemInput.setAttribute("id", `txt_${leerling.id}_gem`);
                    GemInput.setAttribute("placeholder", "0.0");
                    GemInput.setAttribute("readOnly", "true");
                    if (AantalCijfers > 0) {
                        let Gemiddelde = ((Totaal / AantalCijfers) / 10).toFixed(1);
                        GemInput.setAttribute("value", Gemiddelde);
                        if (Gemiddelde < 5.5)
                            GemInput.style.color = 'red';
                    }
                    else
                        GemInput.setAttribute("value", "");


                    GemInput.style.width = "100px";
                    GemCell.appendChild(GemInput);
                    row.appendChild(GemCell);


                    tblBody.appendChild(row);
                }
            })
            .catch(error => alert(`Oeps, er is iets mis gegaan :${error.message} `));

    }
    catch (error) {
        alert(`Oeps, er is iets mis gegaan :${error.message} `);
    }

}

function OpslaanEnBijwerken() {
    var LeerlingResultaat = { vakId: 0, leerlingId: "string", behaald: [0] };
    var NieuweCijfers = [];
    DocentId = document.getElementById("hidDocentId").value;


    //De nieuwe cijfers klaar zetten door alle leerlingen weer langs te 
    //lopen en de 5 mogelijke invoer velden op te halen
    const requestOptions = {
        method: 'GET',
        redirect: 'follow',
        credentials: 'include'
    };

    let url = ApiUrl + "Docent/MijnKlas/" + VakId;
    fetch(url, requestOptions)
        .then(function (response) {
            return response.json();
        })
        .then(function (leerlingen) {
            let tblBody = document.querySelector("#LeerlingData");
            for (let leerling of leerlingen) {
                var LeerlingResultaat = { vakId: 0, leerlingId: "string", behaald: [] };
                LeerlingResultaat.vakId = leerling.vakId;
                LeerlingResultaat.leerlingId = leerling.leerlingId;
                for (let step = 0; step < 5; step++) {
                    // De inout velden heten 'Cijfer_xxxx_y'
                    var CijferVeld = `Cijfer_${leerling.leerlingId}_${step}`
                    var Waarde = document.getElementById(CijferVeld).value;
                    if (Waarde != "") {
                        var Cijfer = parseInt(parseFloat(Waarde * 10));
                        LeerlingResultaat.behaald.push(Cijfer);
                    }
                }
                NieuweCijfers.push(LeerlingResultaat);
                var i = 0;
            }

            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");


            var raw = JSON.stringify(NieuweCijfers);
            var postOptions = {
                method: 'POST',
                headers: myHeaders,
                body: raw,
                redirect: 'follow'
            };

            fetch(ApiUrl + "Docent/CijfersBijwerken", postOptions)
                .then(function (response) {
                    var i = 0;
                })
                .then(function () {
                    var i = 0;
                    location.reload();
                })
                .catch(error => alert('Oeps, er is iets mis gegaan'));


        })
        .catch(error => alert(`Oeps, er is iets mis gegaan :${error.message} `));
    //Oude cijfers verwijderen en nieuwe cijfers versturen, en weer bijgewerkt ophalen



}

