$("#addItemIngredient").click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#editorRowsIngredients").append(html); }
    });
    return false;
});

$("#addItemStep").click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#editorRowsSteps").append(html); }
    });
    return false;
});
