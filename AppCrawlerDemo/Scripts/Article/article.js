function deleteArticle(article) {
    const articleID = article.dataset.id;
    var token = $("input[name=__RequestVerificationToken]").val();
    swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result) {
            $.ajax({
                type: "POST",
                url: "Delete",
                data: {
                    Id: articleID,
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
        }
    })
}