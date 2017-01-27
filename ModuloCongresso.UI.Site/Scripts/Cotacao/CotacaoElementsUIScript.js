$(document).ready(function () {

    acaoCamposGeral();

    acaoMarcaModelo();

    acaoAno();

    acaoAnoModelo();

    acaoCheckZeroKM();

    acaoResultado();

    acaoTipoCalculo();

    acaoEndereco();

    acaoRelacaoSegurado();

    acaoPerguntaAntiFurto();

    acaoPerguntaGaragem();

    acaoQtdVeiculosResidencia();

    acaoPrincipalCondutor();

    acaoCalcular();

    acaoVoltar();

    //var navListItems = $('div.setup-panel div a'),
    //        allWells = $('.setup-content'),
    //        allNextBtn = $('.nextBtn');

    //allWells.hide();

    //navListItems.click(function (e) {
    //    e.preventDefault();
    //    var $target = $($(this).attr('href')),
    //            $item = $(this);

    //    if (!$item.hasClass('disabled')) {
    //        navListItems.removeClass('btn-primary').addClass('btn-default');
    //        $item.addClass('btn-primary');
    //        allWells.hide();
    //        $target.show();
    //        $target.find('input:eq(0)').focus();
    //    }
    //});

    //allNextBtn.click(function () {
    //    var curStep = $(this).closest(".setup-content"),
    //        curStepBtn = curStep.attr("id"),
    //        nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
    //        curInputs = curStep.find("input[type='text'],input[type='url']"),
    //        isValid = true;

    //    $(".form-group").removeClass("has-error");
    //    for (var i = 0; i < curInputs.length; i++) {
    //        if (!curInputs[i].validity.valid) {
    //            isValid = false;
    //            $(curInputs[i]).closest(".form-group").addClass("has-error");
    //        }
    //    }

    //    if (isValid)
    //        nextStepWizard.removeAttr('disabled').trigger('click');
    //});

    //$('div.setup-panel div a.btn-primary').trigger('click');


});

function acaoCamposGeral() {
    
    $('#IdChassiForm').attr('maxlength', 20);
    $('#formNomeId').attr('maxlength', 12);
    $('#formRGId').attr('maxlength', 7);
    $('#NumId').attr('maxlength', 4);
    $("#formDataNascId").attr('maxlength', 8);
    $('#formNomePrCondId').attr('maxlength', 15); 
    $('#formCPFId').mask('000.000.000-00', { reverse: true });
    $('#formFoneId').mask('(00) 00000-0000');
    $('#CEPId').mask('00000-000');
    $('#CepPernoiteId').mask('00000-000');
    $('#formCPFPrCondId').mask('000.000.000-00', { reverse: true });
    $('#NumId').mask('0000');
    $("#IdChassiForm").mask('00000000000000000000');
}

$(document).on('keypress', '#formRGId', function (event) {
    $("#formRGId").mask('0.000.000');
});

function acaoMarcaModelo() {

    var $state = $('#ddlMarcaId');
    var $province = $('#TxtModeloId');
        
    $state.change(function (event) {
        event.preventDefault();

        if ($state.val() != '') {
            $province.removeAttr('disabled');
            $province.empty();
            $province.val('');
            loadModelos($state.val());
        } else {
            $province.attr('disabled', 'disabled').val('');
        }
    }).trigger('change');
}

function loadModelos(attribute) {

    var url = "/Cotacao/LoadModelos/?valueId=" + attribute;

    $.getJSON(url, function (data) {

        $('#TxtModeloId').typeahead('destroy');
        $("#TxtModeloId").typeahead({
            minLength: 1,
            maxItem: 8,
            order: "asc",
            dynamic: true,
            source: data.Value
        });
    });
}

function acaoAno() {

    $('#ddlAnoId').select2({
        placeholder: "Selecione",
        allowClear: true
    });

    var numbers = [2016, 2015, 2014, 2013, 2012, 2011, 2010, 2009, 2008, 2007, 2006, 2005, 2004, 2003, 2002, 2001, 2000, 1999];

    var option = '';
    for (var i = 0; i < numbers.length; i++) {
        option += '<option value="' + numbers[i] + '">' + numbers[i] + '</option>';
    }
    $('#ddlAnoId').append(option);
}

function acaoAnoModelo() {

    $('#ddlAnoModeloId').select2({
        placeholder: "Selecione",
        allowClear: true
    });

    var numbers = [2017, 2016, 2015, 2014, 2013, 2012, 2011, 2010, 2009, 2008, 2007, 2006, 2005, 2004, 2003, 2002, 2001, 2000, 1999];
    var $stateAnoFab = $('#ddlAnoId');
    var anoModeloNumbers = [];
    var optionAnoModeloDown = '';
    var optionAnoModeloTop = '';

    $stateAnoFab.on("change", function (event) {

        if ($stateAnoFab.val() != '') {

            optionAnoModeloDown = '';
            optionAnoModeloTop = '';
            $('#ddlAnoModeloId').empty();
            $('#ddlAnoModeloId').val('').change();

            anoModeloNumbers = [$stateAnoFab.val()];
            optionAnoModeloDown += '<option value="' + anoModeloNumbers + '">' + anoModeloNumbers + '</option>';

            if ($stateAnoFab.val() !== "2017") {
                for (var i = 0; i < numbers.length; i++) {

                    if (anoModeloNumbers == numbers[i]) {
                        optionAnoModeloTop += '<option value="' + numbers[i - 1] + '">' + numbers[i - 1] + '</option>';
                    }
                }
            }

            optionAnoModeloTop += optionAnoModeloDown;

            $('#ddlAnoModeloId').append(optionAnoModeloTop);

        } else {
            $('#ddlAnoModeloId').remove(optionAnoModeloTop);
        }
    }).trigger('change');
}

function acaoCheckZeroKM() {

    var $ddlAnoFab = $('#ddlAnoId');
    var $ddlAnoMod = $('#ddlAnoModeloId');
    var $checkState = $('#checkbox-1');

    $checkState.change(function () {
        if ($('input[id="checkbox-1"]:checked').length > 0) {
            $ddlAnoFab.attr('disabled', 'disabled').val('');

            $ddlAnoFab.val("2016").change();
            $('#ddlAnoModeloId').val('').change();

            acaoCriarRemoverRow01(true);

        } else {
            $ddlAnoFab.removeAttr('disabled');
            $ddlAnoFab.val('').change();
            $ddlAnoMod.val('').change();

            acaoCriarRemoverRow01(false);
        }
    }).trigger('change');
}

function acaoCriarRemoverRow01(element) {

    var position = $("#idContentVeic").children("#divAno_Id");
    var customDiv = $('<div class="row" id="answerCheck_01Id"></div>');

    if (element === true) {

        position.after(customDiv);
        $(customDiv).append(
            '<div class="col-sm-5">' +
            '   <div class="form-group">' +
            '       <label>Data de Saída</label>' +
            '       <input type="text" placeholder="dd/mm/aaaa" id="dataSaidaId" class="form-control">' +
            '   </div>' +
            '</div>' +
            '<div class="col-sm-5">' +
            '   <div class="form-group">' +
            '       <label>Odômetro</label>' +
            '       <input type="text" placeholder="Odômetro" class="form-control" id="idFormOdometro">' +
            '   </div>' +
            '</div>'
            );

        $('#idFormOdometro').attr('maxlength', 2);
        $('#dataSaidaId').attr('maxlength', 8);
    } else {
        $("#answerCheck_01Id").remove();
    }
}

$(document).on('keypress', '#idFormOdometro', function (event) {
    $('#idFormOdometro').mask('00');
});

$(document).on('keypress', '#dataSaidaId', function () {
    $('#dataSaidaId').mask('00/00/0000');
});

function acaoResultado() {

    $(document).on('click', "#btnBuscarVeic", function (event) {

        var marca = $('#ddlMarcaId').val();
        var modelo = $('#TxtModeloId').val();
        var anoFab = $('#ddlAnoId').val();
        var anoMod = $('#ddlAnoModeloId').val();
        var flagZeroKm;

        if ($('input[id="checkbox-1"]:checked').length > 0) {
            flagZeroKm = 1;
        } else {
            flagZeroKm = 0;
        }

        $("#errorSummary").hide();
        $("#errorSummary").empty();

        if (marca == "" || modelo == "" || anoFab == null || anoMod == null) {

            var message = "Necessário preencher os dados do Veículo!!!";
            $("#errorSummary").append('<div class="alert alert-danger alert-dismissable" ><button type="button" aria-hidden="true" class="close" data-dismiss="alert">×</button><h3>' + message + '</h3></div>');
            $("#errorSummary").slideToggle('slow');

        } else {
           
            var position = $("#divDadosVeiculos");
            var divResultado = $('<div class="col-lg-6" id="divResultadoId"></div>');

            position.after(divResultado);
            $(divResultado).append(
                '<div class="ibox float-e-margins">' +
                    '<div class="ibox-title">' +
                    '   <h5><strong>Resultados</strong></h5>' +
                    '   <div class="ibox-tools">' +
                    '   </div>' +
                    '</div>' +
                    '<div class="ibox-content no-padding">' +
                    '   <table class="footable table table-stripped toggle-arrow-tiny" data-page-size="3">' +
                    '      <tbody id="tbodyResultsId">' +
                    '      </tbody>' +
                    '      <tfoot> ' +
                    '           <tr>' +
                    '                <td>'+
                    '                    <button type="button" class="btn btn-outline button-glow btn-danger sm pull-left" id="btnBackFind">Back to</button>'+
                    '                </td>'+
                    '                <td colspan="5">'+
                    '                    <ul class="pagination pull-right"></ul>'+
                    '                </td>'+
                    '            </tr>' +
                    '      </tfoot> ' +
                    '   </table>' +
                    '</div>' +
                '</div>'
            );

            var url = '/Cotacao/LoadModelosResults/?marcaId=' + marca + '&modelo=' + modelo + '&anoFabricacao=' + anoFab + '&anoModelo=' + anoMod + '&zeroKm=' + flagZeroKm;

            $.getJSON(url, function (data) {

                var nomeMarca = $("#ddlMarcaId option:selected").text();
                var row;

                for (var i = 0; i < data.length; i++) {

                    var item = JSON.parse(JSON.stringify(data[i]));

                    row += '<tr id="' + item.ModeloId + '">';

                    row += '<td>' + '<label class="font-noraml"><font face="Palatino Linotype">'
                                        + nomeMarca + "  " + item.Descricao
                                        + "<br>" + item.AnoFabricacao + "/" + item.AnoModelo + " " + "R$: " + item.Valor.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td>'
                                  + '</font></label>' +
                           '<td>' + '<button type="button" class="btn btn-outline button-glow btn-primary btn-sm dim pull-right" id="btnSelectVeic" data-id="' + item.ModeloId + '">Escolher</button>' + '</td>';

                    row += '</tr>';
                }
                
                if (data.length === 0) {                  
                    row += '<tr><td>Não foi encontrado nenhum modelo com estas características. Realize nova busca!!!</td></tr>';
                }

                $("#tbodyResultsId").html(row);
            });

            $("#divResultadoId").show();
            $('.footable').footable();
            DisableDadosVeiculos();
        }
    });

    $(document).on('click', "#btnBackFind", function (event) {

        $("#divResultadoId").hide();
        $("#divResultadoId").remove();
        EnableDadosVeiculos();
    });

    $(document).on('click', "#btnSelectVeic", function(event) {

        var buttonModeloId = $(this).attr("data-id");

        $("#divResultadoId").remove();

        var marcaId = $("#ddlMarcaId option:selected").val();
        var imagem = loadDadosMarca(marcaId);

        var url = '/Cotacao/LoadSelectModelo/?modeloId=' + buttonModeloId;

        $.getJSON(url, function (data) {
            var item = JSON.parse(JSON.stringify(data));

            acaoCriarVeiculoEscolhido(true, item);
            $("#divResultadoId").slideToggle('slow');
        });

        acaoTravarCoberturaBasica(true, buttonModeloId);
    });

    $(document).on('click', "#btnNovaPesquisa", function (event) {

        $("#rowVeiculoEscolhido").hide();
        $("#divResultadoId").remove();
        EnableDadosVeiculos();
        acaoTravarCoberturaBasica(false, null);
    });
}

function acaoCriarVeiculoEscolhido(element, item) {

    var position = $("#divDadosVeiculos");
    var veiculoEscolhidoDiv = $('<div class="col-lg-6" id="rowVeiculoEscolhido"></div>');

    var itemMarca = JSON.parse(JSON.stringify(item.Marca));

    if (element === true) {

        position.after(veiculoEscolhidoDiv);
        $(veiculoEscolhidoDiv).append(
            '<div class="ibox float-e-margins">' +
                '<div class="ibox-title">' +
                '   <h5><strong>Resultados</strong></h5>' +
                '   <div class="ibox-tools">' +
                '   </div>' +
                '</div>' +
                '<div class="ibox-content no-padding">' +
                '   <ul class="list-group">' +
                '      <li class="list-group-item">' +
                '         <div class="row" id="rowSelectedVeiculo" data-id="'+item.ModeloId+'">' +
                '              <div class="col-sm-4">' +
                '                    <span><img class="icon" src="../../img/Veiculos/Marcas/' + itemMarca.Imagem + '" alt="Electricity" width="100" height="70"></span>' +
                '              </div>' +
                '              <div class="col-sm-8">' +
                '                 <div class="form-group">' +
                '                    <font face="Palatino Linotype">' +
                                           " " + item.Descricao +
                                           "<br>" + item.AnoFabricacao + "/" + item.AnoModelo + " " + "R$: " + item.Valor.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') +
                '                    </font>' +
                '                 </div>' +
                '             </div>' +
                '         </div>' +
                '      </li> ' +
                '      <li class="list-group-item">' +
                '         <div class="row">' +
                '              <div class="col-sm-12">' +
                '                    <button type="button" class="btn btn-outline button-glow btn-danger sm pull-left" id="btnNovaPesquisa">Nova Pesquisa</button>' +
                '              </div>' +
                '         </div>' +
                '      </li> ' +
                '   </ul>' +
                '</div>' +
            '</div>'
        );

    } else {
        $("#rowVeiculoEscolhido").remove();
    }
}

function loadDadosMarca(element) {

    var url = '/Cotacao/LoadDadosMarca/?marcaId=' + element;

    $.getJSON(url, function (data) {

        var item = JSON.parse(JSON.stringify(data));

        return item.Imagem;
    });
}

function DisableDadosVeiculos() {

    var $checkState = $('#checkbox-1');
    var $anoModelo = $('#ddlAnoModeloId');
    var $anoFab = $('#ddlAnoId');
    var $modelo = $('#TxtModeloId');
    var $marca = $('#ddlMarcaId');
    var $buttonFind = $('#btnBuscarVeic');

    var $modeloValor = $('#TxtModeloId').val();

    $checkState.attr('disabled', 'disabled');
    $anoModelo.attr('disabled', 'disabled');
    $anoFab.attr('disabled', 'disabled');
    $modelo.attr('disabled', 'disabled').val($modeloValor);
    $buttonFind.attr('disabled', 'disabled');

    //$marca.prop('disabled', true).trigger("chosen:updated");

    $("#ddlMarcaId option").each(function () {
        var $thisOption = $(this);
        var valueToCompare = $marca.val();

        if ($thisOption.val() !== valueToCompare) {
            $('#ddlMarcaId option[value="' + $thisOption.val() + '"]').attr('disabled', true).trigger("chosen:updated");
        }
    });
}

function EnableDadosVeiculos() {

    var $checkState = $('#checkbox-1');
    var $anoModelo = $('#ddlAnoModeloId');
    var $modelo = $('#TxtModeloId');
    var $anoFab = $('#ddlAnoId');
    var $marca = $('#ddlMarcaId');
    var $buttonFind = $('#btnBuscarVeic');

    $checkState.removeAttr('disabled');
    $anoModelo.removeAttr('disabled');
    $modelo.removeAttr('disabled');
    $marca.removeAttr('disabled');
    $buttonFind.removeAttr('disabled');

    if (!$('input[id="checkbox-1"]:checked').length > 0) {
        $anoFab.removeAttr('disabled');
    }

    $("#ddlMarcaId option").each(function () {
        var $thisOption = $(this);
        $('#ddlMarcaId option[value="' + $thisOption.val() + '"]').removeAttr('disabled', true).trigger("chosen:updated");
    });
}

function MountBasicInformation() {
    var objBasicInfo = new Object();
    objBasicInfo.MarcaId = $('#ddlMarcaId').val();
    objBasicInfo.ModeloId = $('#TxtModeloId').val();
    objBasicInfo.AnoFabricacao = $('#ddlAnoId').val();
    objBasicInfo.AnoModelo = $('#ddlAnoModeloId').val();

    return objBasicInfo;
}

function acaoTipoCalculo() {

    var tipoCalculo = $('#ddlTipoCalculoId');
    var dateStart = $('#dateStartId');

    var currentDate = new Date();
    var dateNow = (currentDate.getMonth() + 1) + "/" + currentDate.getDate() + "/" + currentDate.getFullYear();

    $('#dateStartId').val(dateNow);

    $('#ddlTipoCalculoId, #dateStartId').change(function (event) {
        event.preventDefault();

        var optionSelected = $("#ddlTipoCalculoId option:selected").text();

        if ($('#ddlTipoCalculoId').val() == "") {
            $('#dateEndId').attr('disabled', 'disabled');
            $('#dateEndId').empty();
            $('#dateEndId').val('');
        }
        else if (optionSelected == "Plurianual") {

            $('#dateEndId').removeAttr('disabled');
            $('#dateEndId').empty();
            $('#dateEndId').val('');

        } else {

            var url = '/Cotacao/LoadDataInicioFim/?dataVigenciaInicial=' + $('#dateStartId').val() + '&tipoCalculoId=' + $('#ddlTipoCalculoId').val();

            $.getJSON(url, function (data) {

                var item = JSON.parse(JSON.stringify(data));

                $('#dateEndId').val(item);
                $('#dateEndId').attr('disabled', 'disabled');
            });
        }
    }).trigger('change');
}

function acaoEndereco() {

    var $cep = $('#CEPId');
    block_fomulario_cep();

    $cep.blur(function () {

        var cep = $(this).val().replace(/\D/g, '');

        if (cep != "") {

            var validacep = /^[0-9]{8}$/;

            if(validacep.test(cep)) {

                $("#LogradouroId").val("...");
                $("#BairroId").val("...");
                $("#CidadeId").val("...");
                $("#EstadoId").val("...");

                $.getJSON("//viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        $("#LogradouroId").val(dados.logradouro);
                        $("#BairroId").val(dados.bairro);
                        $("#CidadeId").val(dados.localidade);
                        $("#EstadoId").val(dados.uf);

                        $("#ComplId").removeAttr('disabled');
                        $("#NumId").removeAttr('disabled');

                        if (dados.logradouro == "")
                            $("#LogradouroId").removeAttr('disabled');
                        else if (dados.bairro == "")
                            $("#BairroId").removeAttr('disabled');
                    } 
                    else {
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } 
            else {
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } 
        else {
            limpa_formulário_cep();
        }
    });
}

function limpa_formulário_cep() {
    $("#LogradouroId").val("");
    $("#BairroId").val("");
    $("#CidadeId").val("");
    $("#EstadoId").val("");
}

function block_fomulario_cep() {
    $("#LogradouroId").attr('disabled', 'disabled');
    $("#BairroId").attr('disabled', 'disabled');
    $("#CidadeId").attr('disabled', 'disabled');
    $("#EstadoId").attr('disabled', 'disabled');
    $("#ComplId").attr('disabled', 'disabled');
    $("#NumId").attr('disabled', 'disabled');
}

function acaoRelacaoSegurado() {
    
    var optionsRelacao = ["Cônjuge ou Companheiro(a)", "Diretor, Superitendente, Gerente", "Empregado", "Espólio", "Filho(a)", "Irmão(ã)", "Leasing", "Outros", "Pai/Mãe", "Próprio"];
    var relacao = $('#ddlRelacaoSeguradoId');

    var option = [];
    option.push($("<option/>", { value: "", text: "Selecione" }));
    for (var i = 0; i < optionsRelacao.length; i++) {
        option.push($("<option/>", { value: optionsRelacao[i], text: optionsRelacao[i] }));
    }

    relacao.append(option).trigger("chosen:updated");
}

function acaoPerguntaAntiFurto() {
   
    $("input[name=checkFurto]").on('ifChecked', function (event) {

        var position = $("#rowAntiFurtoId");
        var customDiv = $('<div class="row" id="divDispositivo"></div>');
        var customDivFurto = $('<div class="row" id="divFurto"></div>');

        if (this.value == 'optionFurto_Sim') {

            acaoCriarRastreador(position, customDiv);
            acaoCriarAntiFurto($('#divDispositivo'), customDivFurto);

        } else if (this.value == 'optionFurto_Nao') {
            cleanPerguntasFurto();
        }
    });
}

function cleanPerguntasFurto() {
    
    $("#divDispositivo").remove();
    $("#divPropriedade").remove();
    $("#divFurto").remove();

    $("#ddlRastreadorId").remove();
    $("#ddlAntiFurtoId").remove();
    $("#ddlpropriedadeId").remove();
}

function acaoCriarRastreador(position, customDiv) {
    
    position.after(customDiv);
    $(customDiv).append(
        '<div class="col-sm-4">' +
            '<div class="form-group">' +
            '   <font face="Palatino Linotype">' +
            '       <strong>Rastreadores / Localizadores</strong>' +
            '   </font>' +
            '</div>' +
        '</div>' +
        '<div class="col-sm-8">' +
            '<div class="input-group">' +
            '    <select class="chosen-select" id="ddlRastreadorId" tabindex="2" style="width: 200px;"></select>' +
            ' </div>' +
        '</div>'
    );

    $('#ddlRastreadorId').chosen({
        placeholder: "Selecione",
        allowClear: true
    });

    var url = '/Cotacao/LoadDadosRastreador/';

    $.getJSON(url, function (data) {

        var option = [];
        option.push($("<option/>", { value: "", text: "Selecione" }));
        for (var i = 0; i < data.length; i++) {

            var item = JSON.parse(JSON.stringify(data[i]));

            option.push($("<option/>", { value: item.RastreadorId, text: item.Nome }));
        }

        $("#ddlRastreadorId").append(option).trigger("chosen:updated");
    });
}

function acaoCriarAntiFurto(position, customDivFurto) {
    
    position.after(customDivFurto);
    $(customDivFurto).append(
        '<div class="col-sm-4">' +
            '<div class="form-group">' +
            '   <font face="Palatino Linotype">' +
            '       <strong>Dispositivo Anti-Furto Comum</strong>' +
            '   </font>' +
            '</div>' +
        '</div>' +
        '<div class="col-sm-8">' +
            '<div class="input-group">' +
            '    <select class="chosen-select" id="ddlAntiFurtoId" tabindex="2" style="width: 200px;"></select>' +
            ' </div>' +
        '</div>'
    );

    $('#ddlAntiFurtoId').chosen({
        placeholder: "Selecione",
        allowClear: true
    });

    var url = '/Cotacao/LoadDadosDispositivoAntiFurto/';

    $.getJSON(url, function (data) {

        var option = [];
        option.push($("<option/>", { value: "", text: "Selecione" }));
        for (var i = 0; i < data.length; i++) {

            var item = JSON.parse(JSON.stringify(data[i]));

            option.push($("<option/>", { value: item.AntiFurtoId, text: item.Nome }));
        }

        $("#ddlAntiFurtoId").append(option).trigger("chosen:updated");
    });
}

$(document).on('change', '#ddlRastreadorId', function () {
    
    if (!$("#divPropriedade").length) {
        
        var position = $('#divDispositivo');
        var customDiv = $('<div class="row" id="divPropriedade"></div>');

        position.after(customDiv);
        $(customDiv).append(
            '<div class="col-sm-4">' +
                '<div class="form-group">' +
                '   <font face="Palatino Linotype">' +
                '       <strong>Propriedade do Rastreador?</strong>' +
                '   </font>' +
                '</div>' +
            '</div>' +
            '<div class="col-sm-8">' +
                '<div class="input-group">' +
                '    <select cclass="chosen-select" id="ddlpropriedadeId" tabindex="2" style="width: 200px;"></select>' +
                ' </div>' +
            '</div>'
            );

        $('#ddlpropriedadeId').chosen({
            placeholder: "Selecione",
            allowClear: true
        });

        var optionsPropriedade = ["Próprio", "Comodato", "Outros"];
        var relacao = $('#ddlpropriedadeId');

        var option = [];
        option.push($("<option/>", { value: "", text: "Selecione" }));
        for (var i = 0; i < optionsPropriedade.length; i++) {
            option.push($("<option/>", { value: optionsPropriedade[i], text: optionsPropriedade[i] }));
        }

        relacao.append(option).trigger("chosen:updated");
    }

    if ($("#ddlRastreadorId").val() === "") {      
        $("#divPropriedade").remove();
        $("#ddlpropriedadeId").remove();
    }
});

function acaoPerguntaGaragem() {
    
    $("input[name=checkGaragem]").on('ifChecked', function (event) {

        var position = $("#rowGaragemId");
        var customDiv = $('<div class="row" id="divResidencia"></div>');
        var customDivTrab = $('<div class="row" id="divTrabalho"></div>');
        var customDivFacul = $('<div class="row" id="divFaculdade"></div>');

        if (this.value == 'optionGaragem_Sim') {

            acaoCriarCampoResidencia(position, customDiv);
            acaoCriarCampoTrabalho($('#divResidencia'), customDivTrab);
            acaoCriarCampoFaculdade($('#divTrabalho'), customDivFacul);

        } else if (this.value == 'optionGaragem_Nao') {
            cleanPerguntasGaragem();
        }
    });
}

function cleanPerguntasGaragem() {

    $("#divResidencia").remove();
    $("#divTrabalho").remove();
    $("#divFaculdade").remove();
}

function acaoCriarCampoResidencia(position, customDiv) {

    position.after(customDiv);
    $(customDiv).append(
        '<div class="col-sm-4">' +
            '<div class="form-group">' +
            '   <font face="Palatino Linotype">' +
            '       <strong>Na Residência?</strong>' +
            '   </font>' +
            '</div>' +
        '</div>' +
        '<div class="col-sm-8">' +
            '<div class="input-group">' +
            '    <select class="chosen-select" id="ddlResidenciaId" tabindex="2" style="width: 200px;"></select>' +
            ' </div>' +
        '</div>'
    );

    $('#ddlResidenciaId').chosen({
        placeholder: "Selecione",
        allowClear: true
    });

    var optionsResidencia = ["Não", "Sim"];
    var relacao = $('#ddlResidenciaId');

    var option = [];
    option.push($("<option/>", { value: "", text: "Selecione" }));
    for (var i = 0; i < optionsResidencia.length; i++) {
        option.push($("<option/>", { value: optionsResidencia[i], text: optionsResidencia[i] }));
    }

    relacao.append(option).trigger("chosen:updated");
}

function acaoCriarCampoTrabalho(position, customDiv) {

    position.after(customDiv);
    $(customDiv).append(
        '<div class="col-sm-4">' +
            '<div class="form-group">' +
            '   <font face="Palatino Linotype">' +
            '       <strong>No Trabalho?</strong>' +
            '   </font>' +
            '</div>' +
        '</div>' +
        '<div class="col-sm-8">' +
            '<div class="input-group">' +
            '    <select class="chosen-select" id="ddlTrabalhoId" tabindex="2" style="width: 200px;"></select>' +
            ' </div>' +
        '</div>'
    );

    $('#ddlTrabalhoId').chosen({
        placeholder: "Selecione",
        allowClear: true
    });

    var optionsTrabalho = ["Não Trabalha ou não utiliza o veículo para ir ao trabalho","Não", "Sim"];
    var relacao = $('#ddlTrabalhoId');

    var option = [];
    option.push($("<option/>", { value: "", text: "Selecione" }));
    for (var i = 0; i < optionsTrabalho.length; i++) {
        option.push($("<option/>", { value: optionsTrabalho[i], text: optionsTrabalho[i] }));
    }

    relacao.append(option).trigger("chosen:updated");
}

function acaoCriarCampoFaculdade(position, customDiv) {

    position.after(customDiv);
    $(customDiv).append(
        '<div class="col-sm-4">' +
            '<div class="form-group">' +
            '   <font face="Palatino Linotype">' +
            '       <strong>No Colégio / Faculdade?</strong>' +
            '   </font>' +
            '</div>' +
        '</div>' +
        '<div class="col-sm-8">' +
            '<div class="input-group">' +
            '    <select class="chosen-select" id="ddlFaculdadeId" tabindex="2" style="width: 200px;"></select>' +
            ' </div>' +
        '</div>'
    );

    $('#ddlFaculdadeId').chosen({
        placeholder: "Selecione",
        allowClear: true
    });

    var optionsFaculdade = ["Não estuda ou não utiliza o veículo para tal fim", "Não", "Sim"];
    var relacao = $('#ddlFaculdadeId');

    var option = [];
    option.push($("<option/>", { value: "", text: "Selecione" }));
    for (var i = 0; i < optionsFaculdade.length; i++) {
        option.push($("<option/>", { value: optionsFaculdade[i], text: optionsFaculdade[i] }));
    }

    relacao.append(option).trigger("chosen:updated");
}

function acaoQtdVeiculosResidencia() {
    
    var options = ["Até 2", "Até 4", "Acima de 4"];
    var qtdVeic = $('#ddlQtdVeicResId');

    var option = [];
    option.push($("<option/>", { value: "", text: "Selecione" }));
    for (var i = 0; i < options.length; i++) {
        option.push($("<option/>", { value: i, text: options[i] }));
    }

    qtdVeic.append(option).trigger("chosen:updated");
}

function acaoPrincipalCondutor() {
    
    $("input[name=checkSegPr]").on('ifChecked', function (event) {

        var $Nome = $('#formNomeId');
        var $DataNascimento = $('#formDataNascId');
        var $Cpf = $('#formCPFId');

        if (this.value == 'optionSegPrinc_Sim') {

            $('#formCPFPrCondId').attr('disabled', 'disabled');
            $('#formNomePrCondId').attr('disabled', 'disabled');
            $('#formDtNascPrCondId').attr('disabled', 'disabled');

            if ($Nome.val() !== "" && $DataNascimento.val() !== "" && $Cpf.val() !== "") {

                $('#formCPFPrCondId').val($Cpf.val()).change();
                $('#formNomePrCondId').val($Nome.val()).change();
                $('#formDtNascPrCondId').val($DataNascimento.val()).change();
            }

        } else if (this.value == 'optionSegPrinc_Nao') {
            $('#formCPFPrCondId').val('').change();
            $('#formNomePrCondId').val('').change();
            $('#formDtNascPrCondId').val('').change();

            $('#formCPFPrCondId').removeAttr('disabled');
            $('#formNomePrCondId').removeAttr('disabled');
            $('#formDtNascPrCondId').removeAttr('disabled');
        }
    });
}

function acaoCalcular() {

    $(document).on('click', "#btnCalcular", function (event) {

        $("#errorSummaryCotacao").hide();
        $("#errorSummaryCotacao").empty();

        var model = MountBasicInformation();
        var item = MountItem();
        var perfil = MountPerfil();
        var questionario = MountQuestionario();
        var cliente = MountClient();
        var coberturas = MountCoberturas();

        model.Cliente = cliente;
        model.Item = item;
        model.Perfil = perfil;
        model.Questionario = questionario;
        model.Item.ListCoberturasItem = coberturas;

        $.ajax(
        {
            dataType: 'JSON',
            url: '/Cotacao/CotacaoAutomovel/',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ model: model }),

            success: function (response) {

                if (response.error == "") {
                    var url = "/Cotacao/CotacaoResultado?cotacaoId=" + response.model.CotacaoId + "&premioTotal=" + response.model.PremioTotal;
                    window.location.href = url;
                }

                if (response.error == "ModelStateError")
                    MountModelStateErrorMessage(response.model);

                //    //$("#errorSummary").append('<div class="alert alert-success"><button type="button" class="close" data-dismiss="alert">×</button><h3>' + response.message + '</h3></div>');

                if (response.error == "ValildationResultError")
                    MountValildationResultError(response.model);

                //$("#errorSummary").slideToggle('slow');
            },
            error: function (xhr) {
                alert("An error occured when trying to create your character. Plase try again later");
            }
        });
    });
}

function MountModelStateErrorMessage(model) {
    var div = '<div class="alert alert-danger">' +
                '<div class="row">' +
                    '<div class="col-sm-11">' +
                        '<h3>Oops! Ocorreram os seguintes erros:</h3>' +
                    '</div>' +
                    '<div class="col-sm-1">' +
                        '<button type="button" class="btn btn-danger btn-rounded button-glow" id="btnErrorSummaryCotacao">x</button>' +
                    '</div>' +
                '</div><ul>';


    for (var i = 0; i < model.length; i++) {
        if (model[i].Key.replace("model.", "") === "DataVigenciaFinal")
            div += '<li> ' + "Data Vigência Final Obrigatória" + '</li>';
        else if (model[i].Key.replace("model.", "") === "DataVigenciaInicial")
            div += '<li> ' + "Data Vigência Inicial Obrigatória" + '</li>';
        else
            div += '<li> ' + model[i].Value + '</li>';
    }

    div += '</ul></div>';
    $("#errorSummaryCotacao").append(div);
    $("#errorSummaryCotacao").show();
}

function MountValildationResultError(model) {
    var div = '<div class="alert alert-danger">' +
                '<div class="row">' +
                    '<div class="col-sm-11">' +
                        '<h3>Oops! Ocorreram os seguintes erros:</h3>' +
                    '</div>' +
                    '<div class="col-sm-1">' +
                        '<button type="button" class="btn btn-danger btn-rounded button-glow" id="btnErrorSummaryCotacao">x</button>' +
                    '</div>' +
                '</div><ul>';

    for (var i = 0; i < model.Erros.length; i++) {
        div += '<li>' + model.Erros[i].Message + '</li>';
    }


    div += '</ul></div>';
    $("#errorSummaryCotacao").append(div);
    $("#errorSummaryCotacao").show();
}

function MountBasicInformation() {
    var objCotacao = new Object();

    objCotacao.TipoCalculoId = $("#ddlTipoCalculoId option:selected").val();
    objCotacao.TipoSeguroId = $("#ddlTipoSeguroId option:selected").val();
    objCotacao.DataVigenciaInicial = toDate($('#dateStartId').val());
    objCotacao.DataVigenciaFinal = toDate($('#dateEndId').val());

    return objCotacao;
}

function MountItem() {
    
    var objItem = new Object();

    objItem.ModeloId = jQuery("#rowSelectedVeiculo").data("id");
    objItem.UsoId = $("#ddlUsoId option:selected").val();
    objItem.ImpostoId = $("#ddlIsencaoId option:selected").val();
    objItem.NumChassi = $("#IdChassiForm").val();

    if ($('input[value="optionChassi_Sim"]:checked').length > 0) {
        objItem.FlagRemarcado = true;
    } else {
        objItem.FlagRemarcado = false;
    }

    return objItem;
}

function MountPerfil() {
    
    var objPerfil = new Object();
    
    objPerfil.EstadoCivilId = $("#ddlEstadoCivilId option:selected").val();
    objPerfil.TipoResidenciaId = $("#ddlTipoResidenciaId option:selected").val();

    objPerfil.CpfPrincipalCondutor = $("#formCPFPrCondId").val().replace(/[^\d]+/g, '');
    objPerfil.NomePrincipalCondutor = $("#formNomePrCondId").val();
    objPerfil.DataNascPrincipalCondutor = $("#formDtNascPrCondId").val();

    if ($('input[value="optionMenorIdade_Sim"]:checked').length > 0) {
        objPerfil.FlagResideMenorIdade = true;
    } else {
        objPerfil.FlagResideMenorIdade = false;
    }

    if ($('input[value="optionSegPrinc_Sim"]:checked').length > 0) {
        objPerfil.FlagSegPrincipalCondutor = true;
    } else {
        objPerfil.FlagSegPrincipalCondutor = false;
    }

    if ($('input[value="optionPontos_Sim"]:checked').length > 0) {
        objPerfil.FlagPontosCarteira = true;
    } else {
        objPerfil.FlagPontosCarteira = false;
    }

    objPerfil.SexoId = $("#ddlSexoId option:selected").val();
    objPerfil.TempoHabilitacaoId = $("#ddlTempoHabId option:selected").val();
    objPerfil.QuantidadeVeicResidencia = $("#ddlQtdVeicResId option:selected").val();
    objPerfil.DistanciaTrabalhoId = $("#ddlDistanciaTrabalhoId option:selected").val();

    return objPerfil;
}

function MountQuestionario() {
    
    var objQuestionario = new Object();

    objQuestionario.RastreadorId = $("#ddlRastreadorId option:selected").val();
    objQuestionario.AntiFurtoId = $("#ddlAntiFurtoId option:selected").val();
    objQuestionario.CepPernoite = $("#CepPernoiteId").val().replace(/[^\d]+/g, '');
    objQuestionario.RelacaoSegurado = $("#ddlRelacaoSeguradoId option:selected").val();

    if ($('input[value="optionBLIND_Sim"]:checked').length > 0) {
        objQuestionario.FlagBlindado = true;
    } else {
        objQuestionario.FlagBlindado = false;
    }

    if ($('input[value="optionPNE_Sim"]:checked').length > 0) {
        objQuestionario.FlagAdaptadoDeficiente = true;
    } else {
        objQuestionario.FlagAdaptadoDeficiente = false;
    }

    if ($('input[value="optionGAS_Sim"]:checked').length > 0) {
        objQuestionario.FlagKitGas = true;
    } else {
        objQuestionario.FlagKitGas = false;
    }

    if ($('input[value="optionLEAS_Sim"]:checked').length > 0) {
        objQuestionario.FlagAlienado = true;
    } else {
        objQuestionario.FlagAlienado = false;
    }

    if ($('input[value="optionFurto_Sim"]:checked').length > 0) {
        objQuestionario.FlagAntiFurto = true;
    } else {
        objQuestionario.FlagAntiFurto = false;
    }

    if ($('input[value="optionGaragem_Sim"]:checked').length > 0) {
        objQuestionario.FlagGararem = true;
    } else {
        objQuestionario.FlagGararem = false;
    }

    objQuestionario.GararemResidencia = $("#ddlResidenciaId option:selected").text();
    objQuestionario.GararemTrabalho = $("#ddlTrabalhoId option:selected").text();
    objQuestionario.GararemFaculdade = $("#ddlFaculdadeId option:selected").text();
    objQuestionario.PropriedadeRastreador = $("#ddlpropriedadeId option:selected").text();

    return objQuestionario;
}

function MountCoberturas() {
    
    var objCoberturas = [];

    $("#listCobId > li").each(function (index, element) {
        var cobertura = {};
        cobertura["CoberturaId"] = element.id;
        cobertura["Valor"] = GetValueCobertura(element);

        objCoberturas.push(cobertura);
    });

    return objCoberturas;
   
}

function MountClient() {
    
    var objCliente = new Object();

    objCliente.ProfissaoId = $("#ddlProfissaoId option:selected").val();
    objCliente.PaisResidenciaId = $("#ddlPaisId option:selected").val();
    objCliente.Nome = $("#formNomeId").val();
    objCliente.SobreNome = $("#formSobrenomeId").val();
    objCliente.Email = $("#formEmailId").val();
    objCliente.CPF = $("#formCPFId").val().replace(/[^\d]+/g, '');
    objCliente.telefone = $("#formFoneId").val().replace(/[^\d]+/g, '');
    objCliente.RG = $("#formRGId").val().replace(/[^\d]+/g, '');
    objCliente.DataNascimento = $('#formDataNascId').val();
    objCliente.CEP = $("#CEPId").val().replace(/[^\d]+/g, '');
    objCliente.Logradouro = $("#LogradouroId").val();
    objCliente.Numero = $("#NumId").val();
    objCliente.Complemento = $("#ComplId").val();
    objCliente.Bairro = $("#BairroId").val();
    objCliente.Cidade = $("#CidadeId").val();
    objCliente.Estado = $('#EstadoId').val();

    return objCliente;
}

function toDate(element) {
    var dateParts = element.split(/(\d{1,2})\/(\d{1,2})\/(\d{4})/);
    return dateParts[2] + "/" + dateParts[1] + "/" + dateParts[3];
}

function GetValueCobertura(obj) {

    return parseFloat(jQuery(obj).find(".touchspin2").val());
    //jQuery(obj).children().children().next().next().children().children().next().next().val();
}

function acaoTravarCoberturaBasica(state, value) {
    
    if (state === true) {

        var coberturaBasicaId;
        var valorVeiculo;

        var first = $.getJSON('/Cotacao/VerifyFlagBasic');
        var second = $.getJSON('/Cotacao/VerifyValorModelo/?valueId=' + value);

        $.when(first, second)
            .done(function(firstResult, secondResult) {

                coberturaBasicaId = firstResult[0];
                valorVeiculo = secondResult[0];

                $("#listCobId > li").each(function(index, element) {

                    if (coberturaBasicaId === parseInt(element.id)) {
                        jQuery(element).find(".touchspin2").val(valorVeiculo.toFixed(2)).change();
                        jQuery(element).find(".touchspin2").attr('disabled', 'disabled');
                    }
                });
            });
    } else {
        
        $("#listCobId > li").each(function (index, element) {

            jQuery(element).find(".touchspin2").val('').change();
            jQuery(element).find(".touchspin2").removeAttr('disabled');
        });
    }
}

$(document).on('click', "#btnErrorSummaryCotacao", function (event) {
    $("#errorSummaryCotacao").hide();
    $("#errorSummaryCotacao").empty();
});

function acaoVoltar() {

    $(document).on('click', "#btnVoltar", function (event) {
        var targetUrl = '/Cotacao/Index';
        window.location.href = targetUrl;
    });
}