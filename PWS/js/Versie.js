fetchVersie();


async function fetchVersie() {

    try {

        const requestOptions = {
            method: 'GET',
            redirect: 'follow',
            credentials: 'include'
        };

        const version = await (await fetch(ApiUrl + "Informatie/Versie", requestOptions)).text();

        document.getElementById("txtVersie").value = version

    } catch (err) { 
        alert('Oeps, er is iets mis gegaan');
    }

}


