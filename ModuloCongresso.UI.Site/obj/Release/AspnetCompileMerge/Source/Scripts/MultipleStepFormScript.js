$(document).ready(function () {

    var $rows = $('#tablePalestra tr');
    $("input[id=search]").keyup(function () {
        var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

        $rows.show().filter(function () {
            var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
            return !~text.indexOf(val);
        }).hide();
    });

    $(".btnAddPalestra").click(function () {
        // Get the id from the link
        var recordToDelete = $(this).attr("data-id");

        if (recordToDelete != '') {

            // Perform the ajax post
            $.post("/ShoppingCart/RemoveFromCart", { "id": recordToDelete },

                function (data) {
                    // Successful requests get here
                    // Update the page elements
                    if (data.ItemCount == 0) {
                        $('#row-' + data.DeleteId).fadeOut('slow');
                    } else {
                        $('#item-count-' + data.DeleteId).text(data.ItemCount);
                    }

                    $('#cart-total').text(data.CartTotal);
                    $('#update-message').text(data.Message);
                    $('#cart-status').text('Cart (' + data.CartCount + ')');
                });
        }
    });
    
    $("input[name=options]").on('change', null, function (event) {

        var url = null;

        if ($('input[name=options]:checked').val() == "btnAll")
        {
            url = '/ManageCliente/GetAll/';
        }
        else if ($('input[name=options]:checked').val() == "btnDisponivel")
        {
            url = '/ManageCliente/GetNonRegister/';
        }
        else
        {
            url = '/ManageCliente/GetRegister/';
        }

        $("#errorSummary").hide();
        $("#errorSummary").empty();

        $.ajax(
        {
            url: url,
            type: 'GET',
            data: {},

            success: function (result) {
                $("#dvtabPalestras").html(result);

            }
        });
    });

    $(document).on('click', "#item-button", function (event) {
        var model = MountBasicInformation();
        var buttonClass = $(this).attr("name");

        model.PalestraId = $(this).attr("data-id");

        $("#errorSummary").hide();
        $("#errorSummary").empty();

        $.ajax(
        {
            dataType: 'JSON',
            url: '/ManageCliente/Register/',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ model: model, buttonClass: buttonClass }), 
            
            success: function (response) {
                if (response.error == "") {
                    $("#errorSummary").append('<div class="alert alert-success"><button type="button" class="close" data-dismiss="alert">×</button><h6>' + response.message + '</h6></div>');

                    if ($('input[name=options]:checked').val() == "btnAll")
                    {
                        $('#row-' + model.PalestraId).children().children().fadeOut('slow');
                        $('#row-' + model.PalestraId).children().children().fadeIn('slow', VerifyRefreshInformation(model, buttonClass));
                    }
                    else
                    {
                        $('#row-' + model.PalestraId).fadeOut('slow');
                    }
                }

                if (response.error == "ModelStateError")
                    MountModelStateErrorMessage(response.model);

                if (response.error == "ValildationResultError")
                    MountValildationResultError(response.model);

                //$("#errorSummary").slideToggle('slow');
            },
            error: function (xhr) {
                alert("An error occured when trying to create your character. Plase try again later");
            }
        });
    });
});

function MountBasicInformation() {
    var objBasicInfo = new Object();
    objBasicInfo.PalestraId = $(this).attr("data-id");

    return objBasicInfo;
}

function VerifyRefreshInformation(model, attribute) {

    var url = '/ManageCliente/GetInfo/?palestraId=' + model.PalestraId + '&acaoSelecionada=' + attribute;

    $.getJSON(url, function (data) {

        if (data.Value == "Add")
        {
            $('#row-' + model.PalestraId).children().children().removeClass('btn btn-success btn-xs').addClass('btn btn-danger btn-xs');
            $('#row-' + model.PalestraId).children().children().children().removeClass('fa fa-check').addClass('fa fa-times');
            $('#row-' + model.PalestraId).children().children().children().text(" Cancelar")
            $('#row-' + model.PalestraId).children().children().attr('name', 'btnRemovePalestra');
        }
        else
        {
            $('#row-' + model.PalestraId).children().children().removeClass('btn btn-danger btn-xs').addClass('btn btn-success btn-xs');
            $('#row-' + model.PalestraId).children().children().children().removeClass('fa fa-times').addClass('fa fa-check');
            $('#row-' + model.PalestraId).children().children().children().text("Cadastrar")
            $('#row-' + model.PalestraId).children().children().attr('name', 'btnAddPalestra');
        }
    });
}

