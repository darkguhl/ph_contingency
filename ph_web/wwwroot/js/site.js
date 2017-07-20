// Write your Javascript code.


//globals
var starmapdata;

//starmapdata
function DrawStarmap(corner) {
    var pos = { Top: corner.Y - window.innerHeight / 2, Left: corner.X - window.innerWidth / 2, Width: window.innerWidth, Height: window.innerHeight };
    $.post("StarMap", pos, function (data) {
        starmapdata = jQuery.parseJSON(data);
        var html = PH.Templates.Stars(starmapdata);
        //console.log(html);
        //$('#starmap').append(html);
        $('#starmap').html(html);
    });
}
