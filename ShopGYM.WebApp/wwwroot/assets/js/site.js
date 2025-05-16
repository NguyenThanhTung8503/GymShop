$('body').on('click', '.option2', function () {

    const id = $(this).data('id');
    $.ajax({
        type: 'POST',
        url: '/Cart/AddToCart',
        data: { id: id },
        success: function (response) {
            console.log('Success:', response);
            alert('Sản phẩm đã được thêm vào giỏ hàng!');
            if (window.location.pathname === '/Cart/Index') {
                var cartController = new CartController();
                cartController.initialize();
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
})
function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}