$("#submit").click(function () {
    $(".list-link").empty();
    var link = $("input[name=Url]").val();
    var selector = $("input[name=selector]").val();
    $.ajax({
        type: "POST",
        url: "linksDetail",
        data: {
            link: link,
            selector: selector,
        },
        success: function (data) {
            data.forEach(element => $(".list-link").append("<li>" + element + "</li>"));
        }
    });
  
});

$("#insert").click(function () {
    var url = $("input[name=Url]").val();
    var titleSelector = $("input[name=SelectorTitle]").val();
    var descriptionSelector = $("input[name=SelectorDescrition]").val();
    var imgSelector = $("input[name=SelectorImage]").val();
    var contentSelector = $("input[name=SelectorContent]").val();
    var CategoryId = $("select[name=category_id]").val();
    var token = $("input[name=__RequestVerificationToken]").val();
    $.ajax({
        type: "POST",
        url: "Create",
        data: {
            Url: url,
            SelectorTitle: titleSelector,
            SelectorDescrition: descriptionSelector,
            SelectorImage: imgSelector,
            SelectorContent: contentSelector,
            CategoryId: CategoryId,
            __RequestVerificationToken: token,
        },
        success: function (data) {
            if (data == "True") {
                swal("Good job!", "You clicked the button!", "success")
            } else {
                swal("Cancelled", "Your imaginary file is safe :)", "error");
            }
        }, error: function (data) {
            swal("Cancelled", "Your imaginary file is safe :)", "error");
        }
    });
});
$(".next-step").click(function () {
    $("input[name=link-step]").val($("input[name=link]").val());
    $("input[name=superselector]").val($("input[name=selector]").val());
});