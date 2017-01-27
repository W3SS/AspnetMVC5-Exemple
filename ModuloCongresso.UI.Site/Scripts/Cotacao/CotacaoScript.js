$(document).ready(function () {

    $(document).on('click', "#item-button", function (event) {

        var buttonClass = $('input[name=options]:checked').val();

        VerifyRefreshProduct(buttonClass);

    });

    $("input[name=options]").on('change', null, function (event) {

        var buttonClass = $('input[name=options]:checked').val();

        $.ajax(
        {
            url: '/Cotacao/VerifyProduct/',
            type: 'GET',
            data: { buttonClass: buttonClass },

            success: function (result) {
                $("#dvtabCotacaoProdutos").html(result);
            }
        });
    });

    $(document).on('click', "#item-button_ReCalculo", function (event) {

        var cotacaoId = $(this).attr("data-id");

        var targetUrl = '/Cotacao/EditCotacaoAutomovel/' + cotacaoId;
        window.location.href = targetUrl;
    });

    $(document).on('click', "#btnInicial", function (event) {
        var targetUrl = '/Cotacao/Index';
        window.location.href = targetUrl;
    });
});

function VerifyRefreshProduct(attribute) {

    var url = '/Cotacao/ReloadProduct/?buttonClass=' + attribute;

    $.getJSON(url, function (data) {

        var targetUrl = '/Cotacao/' + data.Value;
        window.location.href = targetUrl;
    });
}