$(document).ready(function () {

    acaoDadosVeiculosReload();
});

function acaoDadosVeiculosReload() {

    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);

    loadMarcaPorModelo(id);
}

function loadMarcaPorModelo(attribute) {

    var $marca = $("#ddlMarcaId");
    var $modelo = $("#TxtModeloId");
    var $AnoFab = $('#ddlAnoId');
    var $anoMod = $('#ddlAnoModeloId');
    var $zeroKm = $('#checkbox-1');

    var first = $.getJSON('/Cotacao/LoadMarcaPorModeloCotacao/?cotacaoId=' + attribute);
    var second = $.getJSON('/Cotacao/LoadNomeModeloCotacao/?cotacaoId=' + attribute);
    var third = $.getJSON('/Cotacao/LoadInfoDadosVeiculosCotacao/?cotacaoId=' + attribute);

    $.when(first, second, third)
    .done(function (firstResult, secondResult, thirdResult) {

        var item = JSON.parse(JSON.stringify(firstResult[0]));
        var item2 = JSON.parse(JSON.stringify(secondResult[0]));
        var item3 = JSON.parse(JSON.stringify(thirdResult[0]));

        var anoFab = item3.Ano[0];
        var anoMod = item3.Ano[1];
        var zeroKm = item3.FlagZeroKm;

        $marca.val(item).change().trigger("chosen:updated");
        $modelo.val(item2).change();
        $AnoFab.val(anoFab).change();
        $anoMod.val(anoMod).change();

        if (zeroKm === true) {          
            //$zeroKm.prop('checked', true).trigger('change');
            $zeroKm.attr('checked', true).trigger('change');
        }
    });
};