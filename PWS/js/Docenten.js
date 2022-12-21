fetchDocenten();


function fetchDocenten() {

    const requestOptions = {
        method: 'GET',
        redirect: 'follow',
        credentials: 'include'
    };

    fetch(ApiUrl + "Informatie/Docenten", requestOptions)
        .then(function (response) {
            return response.json();
        })
        .then(function (docenten) {
            let placeholder = document.querySelector("#DocentData");
            let out = "";
            for (let docent of docenten) {
                out += `<tr><td>${docent.docentId}</td><td>${docent.wachtwoord}</td><td>${docent.naam}</td><td>${docent.omschrijving}</td><td>${docent.mentor}</td></tr>`;
            }
            placeholder.innerHTML = out;
        })
        .catch(error => {
            alert('Oeps, er is iets mis gegaan');
        });
} 






