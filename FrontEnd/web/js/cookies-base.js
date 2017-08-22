function setCookie(name, value, days) {
    alert(name + ' ' + value + ' ' + days);
    var expires;

    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    } else {
        expires = "";
    }
    document.cookie = encodeURIComponent(name) + "=" + encodeURIComponent(value) + expires + "; path=/";
}

function getCookie(name) {
    var nameEQ = encodeURIComponent(name) + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) === 0) return decodeURIComponent(c.substring(nameEQ.length, c.length));
    }
    return null;
}

function removeCookie(cname) {
    setCoookie(cname, "", -1);
}

function getArrayCookies(cname) {
    var cs = getCookie(cname);
    if (cs) {
        return res = cs.split("@");
    }
    return null;
}

function addArrayCookies(cname, cs, exdays) {
    var res = cs[0];
    for (var i = 1; i < cs.length; i++) {
        res = res + "@" + cs[i];
    }
    setCookie(cname, res, exdays);
}