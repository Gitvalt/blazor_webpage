const NAME = 'ActiveLanguage';
const THEME = 'ActiveTheme';

function getLanguage() {
    let result = window.localStorage[NAME];
    return result ? result : navigator.language || navigator.userLanguage || 'fi';
}

function setLanguage(value) {
    window.localStorage[NAME] = value
}

function switchTheme() {
    if ($('html').hasClass("dark")) {
        setTheme("light");
    }
    else if ($('html').hasClass("light")) {
        setTheme("dark");
    }
    else {
        setTheme("dark");
    }
}

function getCurrentTheme() {
    if ($('html').hasClass("dark")) {
        return "dark";
    } else if ($('html').hasClass("light")) {
        return "light";
    } else {
        return "dark";
    }
}

function recordTheme() {
    window.localStorage[THEME] = getCurrentTheme()
}

function readThemeRecord() {
    let result = window.localStorage[THEME];

    if (result == null) {
        return getCurrentTheme();
    } else {
        return result;
    }
}

function setTheme(themeClass) {
    $('html').removeClass('light');
    $('html').removeClass('dark');

    var newClass = "";

    switch (themeClass) {
        case "dark":
        default:
            newClass = "dark";
            break;

        case "light":
            newClass = "light";
            break;
    }

    $('html').addClass(newClass);
    window.localStorage[THEME] = newClass;
}

function renderComponent(requestedComponent, destinationRoot) {
    if (!requestedComponent) {
        console.error("Requested component not found from document");
        return;
    }

    console.log(document);
    var rootObj = document.getElementById(destinationRoot);
    if (rootObj) {
        console.log("Root found");
        var myEleValue = myEle.value;

        if (requestedComponent == "prj-gallery") {
            console.log("Opening gallery");
            RenderProjectGalleryView();
        }
    }
    else {
        console.error("Root element for component not found?");
        return;
    }
}