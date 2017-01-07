if ((navigator.userAgent.indexOf("Opera") || navigator.userAgent.indexOf('OPR')) != -1) {
    setBrowserInfo('Opera');
}
else if (navigator.userAgent.indexOf("Chrome") != -1) {
    setBrowserInfo('Chrome');
}
else if (navigator.userAgent.indexOf("Safari") != -1) {
    setBrowserInfo('Safari');
}
else if (navigator.userAgent.indexOf("Firefox") != -1) {
    setBrowserInfo('Firefox');
}
else if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true))
{
    setBrowserInfo('IE');
}
else {
    setBrowserInfo('unknown');
}

function setBrowserInfo(info) {
    document.getElementById("browserInfo").innerHTML = "Browser: " + info;
}