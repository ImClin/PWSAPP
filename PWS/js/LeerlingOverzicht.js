var LeerlingId = '';

fetchLeerling();


function fetchLeerling() {
    var queryString = window.location.search;
    var urlParams = new URLSearchParams(queryString);
    LeerlingId = urlParams.get('LeerlingId');

    const requestOptions = {
        method: 'GET',
        redirect: 'follow',
        credentials: 'include'
    };

    fetch(ApiUrl + "Leerling/MijnGegevens/" + LeerlingId, requestOptions)
        .then(function (response) {
            return response.json();
        })
        .then(function (response) {
            document.getElementById("TabelNaam").innerHTML = response.leerlingNaam + " - " + response.klas
            fetchCijfers();
        })
}


function fetchCijfers() {

    const requestOptions = {
        method: 'GET',
        redirect: 'follow',
        credentials: 'include'
    };

    try {
        let url = ApiUrl + "Leerling/MijnCijfers/" + LeerlingId;
        fetch(url, requestOptions)
            .then(function (response) {
                return response.json();
            })
            .then(function (CijfersLijst) {
                let tblBody = document.querySelector("#MijnCijfers");
                //
                // Per vak een regel aanmaken
                //
                let aantalVakken = 0;
                for (let cijfers of CijfersLijst) {
                    let AantalCijfers = 0;
                    let Totaal = 0;
                    const row = document.createElement("tr");
                    //
                    var cell = document.createElement("td");
                    cell.innerText = cijfers.omschrijving;
                    cell.style.width = "150px";
                    row.appendChild(cell);
                    //
                    cell = document.createElement("td");
                    cell.innerText = cijfers.naam;
                    cell.style.width = "200px";
                    row.appendChild(cell);
                    //
                    // Per vak max 5 cijfer velden
                    //
                    for (let step = 0; step < 5; step++) {

                        const CijferCell = document.createElement("td");
                        var CijferInput = document.createElement("INPUT");
                        CijferInput.setAttribute("type", "number");
                        CijferInput.setAttribute("id", `Cijfer_${cijfers.vakId}_${step}`);
                        CijferInput.setAttribute("placeholder", "0.0");
                        CijferInput.setAttribute("min", "1.0");
                        CijferInput.setAttribute("max", "10.0");
                        CijferInput.style.width = "50px";


                        if (cijfers.behaald.length > step) {
                            AantalCijfers += 1;
                            let Cijfer = ((cijfers.behaald.at(step)) / 10);
                            CijferInput.setAttribute("value", Cijfer);
                            Totaal += cijfers.behaald.at(step);
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
                    GemInput.setAttribute("id", `txt_${cijfers.vakId}_gem`);
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
                    //
                    // VakId in hidden om bij bijwerken de input namen te kunnen bepalen
                    //
                    aantalVakken += 1;
                    const HiddenCell = document.createElement("td");
                    var vakIdHidden = document.createElement("INPUT");
                    vakIdHidden.setAttribute("type", "hidden");
                    vakIdHidden.setAttribute("id", `vakId_${aantalVakken}`);
                    vakIdHidden.setAttribute("value", cijfers.vakId);
                    vakIdHidden.style.width = "10px";
                    HiddenCell.appendChild(vakIdHidden);
                    row.appendChild(HiddenCell);

                    //
                    tblBody.appendChild(row);
                }
                document.getElementById("hidAantalVakken").value = aantalVakken;
            })
            .catch(error => alert(`Oeps, er is iets mis gegaan :${error.message} `));

    }
    catch (error) {
        alert(`Oeps, er is iets mis gegaan :${error.message} `);
    }

}


function Berekenen() {
    aantalVakken = document.getElementById("hidAantalVakken").value;
    for (let regel = 1; regel <= aantalVakken; regel++) {

        let vakVeld = `vakId_${regel}`
        let vakId = document.getElementById(vakVeld).value;
        let Totaal = 0;
        let aantal = 0;
        //
        for (let step = 0; step < 5; step++) {
            //
            // Cijfers uit de input halen voor kleur en gemiddelde
            // De inout velden heten 'Cijfer_xxxx_y'
            //
            var CijferVeld = document.getElementById(`Cijfer_${vakId}_${step}`);
            var Waarde = CijferVeld.value;
            if (Waarde != "") {
                let cijfer = parseInt(parseFloat(Waarde * 10));
                Totaal += cijfer;
                aantal += 1;
                CijferVeld.style.color = 'black';
                if (cijfer < 55)
                    CijferVeld.style.color = 'red';
            }
        }

        var gemVeld = document.getElementById(`txt_${vakId}_gem`);
        gemVeld.style.color = 'black';
        if (aantal > 0) {
            let Gemiddelde = ((Totaal / aantal) / 10).toFixed(1);
            gemVeld.setAttribute("value", Gemiddelde);
            if (Gemiddelde < 5.5)
                gemVeld.style.color = 'red';

        }
    }
}


