var CartController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-plus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) + 1;
            updateCart(id, quantity);
        });

        $('body').on('click', '.btn-minus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) - 1;
            updateCart(id, quantity);
        });

        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            updateCart(id, 0);
        });
    }

    function updateCart(id, quantity) {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "POST",
            url: '/Cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
                loadData();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    function loadData() {
        $.ajax({
            type: "GET",
            url: '/Cart/GetListItems',
            success: function (res) {
                if (res.length === 0) {
                    $('#tbl_cart').hide();
                }

                $('#tbl_cart').show();
                var html = '';
                var total = 0;

                $.each(res, function (i, item) {
                    var amount = item.gia * item.soLuong;
                    total += amount;
                    html += "<tr>"
                        + "<td><img width=\"60\" src=\"" + $('#hidBaseAddress').val() + item.image + "\" alt=\"\" /></td>"
                        + "<td>" + item.tenSanPham + "</td>"
                        + "<td>"
                        + "<div class=\"input-group\" style=\"max-width: 150px;\">"
                        + "<input class=\"form-control\" style=\"max-width:34px; text-align: center;\" placeholder=\"1\" id=\"txt_quantity_" + item.idSanPham + "\" value=\"" + item.soLuong + "\" size=\"16\" type=\"text\">"
                        + "<button class=\"btn btn-outline-secondary btn-minus\" data-id=\"" + item.idSanPham + "\" type=\"button\"><i class=\"fas fa-minus\"></i></button>"
                        + "<button class=\"btn btn-outline-secondary btn-plus\" data-id=\"" + item.idSanPham + "\" type=\"button\"><i class=\"fas fa-plus\"></i></button>"
                        + "<button class=\"btn btn-danger btn-remove\" data-id=\"" + item.idSanPham + "\" type=\"button\"><i class=\"fas fa-trash\"></i></button>"
                        + "</div>"
                        + "</td>"
                        + "<td>" + amount.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' }) + "</td>"
                        + "</tr>";
                });

                html += "<tr><td colspan=\"3\"><strong>Tổng tiền</strong></td><td><strong>" + total.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' }) + "</strong></td></tr>";
                $('#cart_body').html(html);
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}