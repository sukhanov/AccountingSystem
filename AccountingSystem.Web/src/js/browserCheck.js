var nAgt = navigator.userAgent;
var browser, version, majorVersion, verOffset, ix, oldBrowser;

// Opera
if ((verOffset = nAgt.indexOf('Opera')) != -1) {
    browser = 'Opera';
    version = nAgt.substring(verOffset + 6);
    if ((verOffset = nAgt.indexOf('Version')) != -1) {
        version = nAgt.substring(verOffset + 8);
    }

    oldBrowser = getMajorVersion(version) < 12;
}

    // MSIE
else if ((verOffset = nAgt.indexOf('MSIE')) != -1) {
    browser = 'Microsoft Internet Explorer';
    version = nAgt.substring(verOffset + 5);

    oldBrowser = getMajorVersion(version) < 9;
}
    // Chrome
else if ((verOffset = nAgt.indexOf('Chrome')) != -1) {
    browser = 'Chrome';
    version = nAgt.substring(verOffset + 7);

    oldBrowser = getMajorVersion(version) < 26;
}
    // Firefox
else if ((verOffset = nAgt.indexOf('Firefox')) != -1) {
    browser = 'Firefox';
    version = nAgt.substring(verOffset + 8);

    oldBrowser = getMajorVersion(version) < 19;
}
    // MSIE 11+
else if (nAgt.indexOf('Trident/') != -1) {
    browser = 'Microsoft Internet Explorer';
    version = nAgt.substring(nAgt.indexOf('rv:') + 3);
}
    // Other browsers
else if ((nameOffset = nAgt.lastIndexOf(' ') + 1) < (verOffset = nAgt.lastIndexOf('/'))) {
    browser = nAgt.substring(nameOffset, verOffset);
    version = nAgt.substring(verOffset + 1);
    if (browser.toLowerCase() == browser.toUpperCase()) {
        browser = navigator.appName;
    }
}

function getMajorVersion(ver) {
    if ((ix = ver.indexOf(';')) !== -1) ver = ver.substring(0, ix);
    if ((ix = ver.indexOf(' ')) !== -1) ver = ver.substring(0, ix);
    if ((ix = ver.indexOf(')')) !== -1) ver = ver.substring(0, ix);

    var major = parseInt('' + ver, 10);
    if (isNaN(major)) {
        version = '' + parseFloat(navigator.appVersion);
        major = parseInt(navigator.appVersion, 10);
    }

    return major;
}

if (oldBrowser)
    window.location = "error.html";

document.getElementById("browserInfo").innerHTML = "Browser: " + browser;