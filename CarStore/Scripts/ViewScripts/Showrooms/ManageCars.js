function getInputHtml() {
    counter++;
//    return `
//<div class="form-group">
//    <label for="Car ` + counter + `">Car ` + counter + `</label>
//    <input class="form-control" data-val="true" id="Car ` + counter + `" name="Car ` + counter + `" type="text" value="" />
//</div>
//`;

    return `
<div class="form-group">
    <input class="form-control" name="ints" type="text" value=""/>
</div>
`;
}

var counter = -1;

//// Add input button action
$("#AddInput").click(function () {
    var html = getInputHtml(),
        target = $("body > div.container.body-content > form");

    target.prepend(html);
});