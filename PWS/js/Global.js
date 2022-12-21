const ApiUrl = "https://webapiclin20221015150516.azurewebsites.net/api/";

GetStyle();
// https://www.w3schools.com/js/js_cookies.asp
// https://www.geeksforgeeks.org/how-to-load-css-and-js-files-dynamically/


function GetStyle() {

    // Style cookie ophalen
    let CurrentStyle = "Style1"
    let name = "Style=";
    let ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0 && c.length > 0) {
            CurrentStyle =  c.substring(name.length, c.length);
        }
    }

    // Creating link element
    var head = document.getElementsByTagName('head')[0]
    var style = document.createElement('link');
    style.href = `Styles/${CurrentStyle}.css`;
    style.type = 'text/css';
    style.rel = 'stylesheet';
    head.append(style);

}

function SetStyle(NewStyle) {
    const d = new Date();
    d.setTime(d.getTime() + (7 * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = "Style=" + NewStyle + ";" + expires + ";path=/";
    location.reload();

}


