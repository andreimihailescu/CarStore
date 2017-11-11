/////////////////////////////////////////////////
function getInputHtml(value = "") {
    var localCounter = counter + 1,
        html = `<div class="form-group">
                    <label class="control-label col-md-1" for="Cars_` + counter + `__Id">Car ` + localCounter + `</label>
                    <input class="form-control text-box single-line" id="Cars_` + counter + `__Id" name="Cars[` + counter + `].Id" type="text" value="` + value + `">
                    <button type="button" class="btn btn-primary">Delete</button>
                </div>`;

    counter++;

    return html;
}

function addInputHtml(value) {
    var html = getInputHtml(value),
        target = $("body > div.container.body-content > form");

    target.prepend(html);
}

/////////////////////////////////////////////////



/////////////////////////////////////////////////
console.log("MODEL IS: ", model);
var counter = 0;

$("#AddInput").click(function () {
    addInputHtml();
});

if (model.Cars !== null) {
    model.Cars.forEach(function (car) {
        addInputHtml(car.Id);
    });
}

/////////////////////////////////////////////////