$("body").on("click", "#btnSubmit", function () {
    var base64 = $('#colors_sketch')[0].toDataURL();
    $("input[name=Signature]").val(base64);
});
$(function () {
    $('#colors_sketch').sketch();
    $(".tools a").eq(0).attr("style", "color:#000");
    $(".tools a").click(function () {
        $(".tools a").removeAttr("style");
        $(this).attr("style", "color:#000");
    });
});