////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	wwwroot\js\logic.js
//
// summary:	Logic class
////////////////////////////////////////////////////////////////////////////////////////////////////

function getCategories(target) {
    if (qs('debug') == 'true' || (window.logicDebug != undefined && window.logicDebug == true)) { console.log('getCategories Called - target: ' + target); }
    getData(fillSelect, target, 'Api/GetCategories', '');
}

function getApis(target, category) {
    if (qs('debug') == 'true' || (window.logicDebug != undefined && window.logicDebug == true)) { console.log('getApis Called - target: ' + target + '\n   category: ' + category); }
    getData(fillSelect, target, 'Api/GetApis', '/' + category);
}

function getApiData(target, api, search) {
    if (qs('debug') == 'true' || (window.logicDebug != undefined && window.logicDebug == true)) { console.log('getData Called - target: ' + target + '\n   api: ' + api + '\n   search: ' + search); }
    getData(fillSelect, target, 'Api/GetData', '/' + api.replace(' ','_') + '/' + search);
}




function getData(callback, target, serverMethod, params) {
    if (qs('debug') == 'true' || (window.logicDebug != undefined && window.logicDebug == true)) { console.log('postMethod Called - Server Method: ' + serverMethod); }
    $.ajax({
        type: "Get",
        url: serverMethod + params,
        success: function (response) { if (callback != null && callback != undefined) callback(response, target); },
        failure: function (jqXHR, textStatus, errorThrown) {
            console.log('Failed: \n Server Method: ' + serverMethod + '\n  params: ' + params);
            console.log('jqXHR:');
            console.log(jqXHR);
            console.log('textStatus:');
            console.log(textStatus);
            console.log('errorThrown:');
            console.log(errorThrown);
            if (callback != null && callback != undefined) callback('fail', target);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log('Error: \n  Server Method: ' + serverMethod + '\n  params: ' + params);
            console.log('jqXHR:');
            console.log(jqXHR);
            console.log('textStatus:');
            console.log(textStatus);
            console.log('errorThrown:');
            console.log(errorThrown);
            if (callback != null && callback != undefined) callback('error', target);
        }
    });
}


function fillSelect(data,target) {
    if (qs('debug') == 'true' || (window.logicDebug != undefined && window.logicDebug == true)) { console.log('fillSelect Called - Target: ' + target + '\n    Data: ' + data); }
    var values = jQuery.parseJSON(data);
    var x = document.getElementById(target);
    if (x == null || values == null) return false;

    clearSelect(target);

    for (var i = 0; i < values.length; i++) {
        var option = document.createElement('option');
        option.text = values[i];
        x.add(option);
    }
    if (target == window.eventCategoryTarget) window.dispatchEvent(window.eventCategoryLoaded);
    if (target == window.eventApiTarget) window.dispatchEvent(window.eventApiLoaded);
}

function clearSelect(target) {
    var x = document.getElementById(target);
    for (var i = x.options.length - 1; i >= 0; i--) {
        x.remove(i);
    }
}

function filterSelect(target, value) {
    var sel = document.getElementById(target);
    for (var i = 0; i < sel.length; i++) {
        var txt = sel.options[i].text;
        var include = txt.toLowerCase().includes(value.toLowerCase());
        sel.options[i].style.display = include ? 'list-item' : 'none';
    }
}



// Gets query string arguments and returns value
function qs(key) {
    key = key.replace(/[*+?^$.\[\]{}()|\\\/]/g, "\\$&"); // escape RegEx meta chars
    var match = location.search.match(new RegExp("[?&]"+key+"=([^&]+)(&|$)"));
    return match && decodeURIComponent(match[1].replace(/\+/g, " "));
}