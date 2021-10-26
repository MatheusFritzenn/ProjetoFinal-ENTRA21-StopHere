function ValidaPlaca() {
    var placa = $("#Placa").val();

    var contador = 0;

    let regex = new RegExp("^[a-zA-Z]{3}[0-9]{4}$|[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{3}$");

    /*const regexPlaca = ^[a-zA-Z]{3}[0-9]{4}$;*/

    if (placa == "") {
        $("#erroValidacaoPlaca").html("A placa deve ser informada.");
        contador += 1;
    }
    if (!regex.test(placa)) {
        $("#erroValidacaoPlaca").html("Placa inválida.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoPlaca").html("");
        return true;
    }
    return false;
}

function ValidaMarca() {
    var marca = $("#Marca").val();
    var contador = 0;

    if (marca == 0) {
        $("#erroValidacaoMarca").html("A marca deve ser informada.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoMarca").html("");
        return true;
    }
    return false;
}

function ValidaModelo() {
    var modelo = $("#Modelo").val();
    var contador = 0;
    if (modelo == "") {
        $("#erroValidacaoModelo").html("O modelo deve ser informado.");
        contador += 1;
    }
    else if (modelo.length < 2 || modelo.length > 70) {
        $("#erroValidacaoModelo").html("O modelo deve conter entre 2 e 70 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoModelo").html("");
        return true;
    }
    return false;
}

function ValidaCor() {
    var cor = $("#Cor").val();
    var contador = 0;

    if (cor == 0) {
        $("#erroValidacaoCor").html("A cor deve ser informada.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoCor").html("");
        return true;
    }
    return false;
}

function ValidaObservacao() {
    var observacao = $("#Observacao").val();
    var contador = 0;

    if (observacao == null) {
        return true;
    }
    if (observacao.length > 100) {
        $("#erroValidacaoObservacao").html("A observação pode conter até 100 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoObservacao").html("");
        return true;
    }
    return false;
}

function ValidaTamanhoVeiculo() {
    var tamanho = $("#TamanhoVeiculo").val();
    var contador = 0;

    if (tamanho == 0) {
        $("#erroValidacaoTamanho").html("O tamanho do veículo deve ser informado.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoTamanho").html("");
        return true;
    }
    return false;
}

function ValidaTipoVeiculo() {
    var tipo = $("#TipoVeiculo").val();
    var contador = 0;

    if (tipo == 0) {
        $("#erroValidacaoTipo").html("O tipo do veículo deve ser informado.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoTipo").html("");
        return true;
    }
    return false;
}

function ValidaFormulario() {
    var contador = 0;

    if (!ValidaPlaca()) {
        contador += 1;
    }
    if (!ValidaMarca()) {
        contador += 1;
    }
    if (!ValidaModelo()) {
        contador += 1;
    }
    if (!ValidaCor()) {
        contador += 1;
    }
    if (!ValidaObservacao()) {
        contador += 1;
    }
    if (!ValidaTamanhoVeiculo()) {
        contador += 1;
    }
    if (!ValidaTipoVeiculo()) {
        contador += 1;
    }
    if (contador != 0) {
        removeEventListener("click");
    }
    if (contador == 0) {
        $("#formulario").submit();
        // Chamar modal e informar que "cadastro foi realizado com sucesso".
    }
    else {
        return false;
    }
}


