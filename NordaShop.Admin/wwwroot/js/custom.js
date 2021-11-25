
$(document).ready(function () {

    // Close alert message 
    $("#close-alert").on("click", function () {
        $(this).parent().css({ "display": "none" });
    });

    // View product images
    $(".example").on("click", ".view-all-image", function () {
        let productid = $(this).data("id");
        if (productid != null && productid > 0) {
            $.ajax({
                url: '/Product/LoadProductImage',
                type: 'GET',
                dataType: "html",
                data: { productId: productid },
                success: function (res) {
                    if (res != null) {
                        $("#modal-media .modal-body").html(res);
                    }
                }
            });
        }
    });

    //Remove all images
    $("#modal-media").on("click", "#remove-files", function () {
        let productId = $("input[name=productid]").val();
        if (productId > 0) {
            swal({
                title: `Are you sure?`,
                text: "Once deleted, you will not be able to recover this data!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then((result) => {
                if (result) {
                    let imageCount = $("#gallery .images-container .row").children().length;
                    if (imageCount > 0) {
                        window.location.href = `/Product/RemoveAllImages/${productId}`;
                    } else {
                        console.log("This product has no image");
                    }
                }
            });
        }
    });

    // View load order status
    $(".example").on("click", ".order-status", function () {
        let item = $(this);
        let orderid = item.data("id");
        let status = item.data("status");
        if (orderid != null && orderid > 0) {
            $.ajax({
                url: '/Order/GetOrderStatus',
                type: 'GET',
                dataType: "html",
                data: { orderId: orderid, status: status },
                success: function (res) {
                    if (res != null) {
                        $("#order-status-modal .modal-body").html(res);
                    }
                }
            });
        }
    });


});
