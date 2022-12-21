fetchLeerlingen();


function fetchLeerlingen() {

    const requestOptions = {
        method: 'GET',
        redirect: 'follow',
        credentials: 'include'
    };

    fetch(ApiUrl + "Informatie/Leerlingen", requestOptions)
        .then(function (response) {
            return response.json();
        })
        .then(function (leerlingen) {
            let placeholder = document.querySelector("#LeerlingData");
            let out = "";
            for (let leerling of leerlingen) {
                out += `<tr><td>${leerling.leerlingId}</td><td>${leerling.wachtwoord}</td><td>${leerling.leerlingNaam}</td><td>${leerling.klas}</td><td>${leerling.mentorId}</td><td>${leerling.mentorNaam}</td></tr>`;
            }
            placeholder.innerHTML = out;
        })
        .catch (error => {
        alert('Oeps, er is iets mis gegaan');
    });
}






