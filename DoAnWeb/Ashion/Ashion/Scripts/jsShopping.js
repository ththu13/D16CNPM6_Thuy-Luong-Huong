$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $('.pro-qty input').val();

        if (tQuantity !== '') {
            quantity = parseInt(tQuantity);
        }

        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',  
            data: { id: id, quantity: quantity },  
            success: function (rs) {
                if (rs.Success) {
                    $('.tip').html(rs.Count);
                    alert(rs.msg);
                }
            }
        });
    });

    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        var conf = confirm('Bạn có muốn xóa tất cả khỏi giỏ hàng không?')
        //alert(id + " " + quantity);
        if (conf === true) {
            DeleteAll();
        }

    });

    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data("id");
        var quantity = $('#Quantity_' + id).val();
        Update(id, quantity);
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có muốn xóa khỏi giỏ hàng không?')
        //alert(id + " " + quantity);
        if (conf === true) {
            $.ajax({
                url: '/shoppingcart/delete',
                type: 'POST',  // Sửa lỗi: sử dụng dấu ':' thay vì '='
                data: { id: id },  // Sửa lỗi: sử dụng dấu ':' thay vì '='
                success: function (rs) {
                    if (rs.Success) {
                        $('.tip').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
       
    });
});

function ShowCount() {
    $.ajax({
        url: '/shoppingcart/ShowCount',
        type: 'GET',  // Sửa lỗi: sử dụng dấu ':' thay vì '='
        success: function (rs) {
            $('.tip').html(rs.Count);
        }
    });
}

function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function Update(id,quantity) {
    $.ajax({
        url: '/shoppingcart/Update',
        type: 'POST',
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}


function LoadCart() {
    $.ajax({
        url: '/shoppingcart/Partial_Item_Cart',
        type: 'GET',  // Sửa lỗi: sử dụng dấu ':' thay vì '='
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}




