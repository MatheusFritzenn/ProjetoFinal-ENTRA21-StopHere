function ValidaCEP() {
    var cep = $("#CEP").val();
    var contador = 0;

    if (cep == "") {
        $("#erroValidacaoCep").html("O CEP deve ser informado.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoCep").html("");
        return true;
    }
    return false;
}
function ValidaUF() {
    var uf = $("#UF").val();
    var contador = 0;

    if (uf == 0) {
        $("#erroValidacaoUf").html("O estado deve ser selecionado.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoUf").html("");
        return true;
    }
    return false;
}

function ValidaCidade() {
    var cidade = $("#Cidade").val();
    var contador = 0;
    //Valida Cidade
    if (cidade == "") {
        $("#erroValidacaoCidade").html("A cidade deve ser informada.");
        contador += 1;
    }
    else if (cidade.length < 3 || cidade.length > 70) {
        $("#erroValidacaoCidade").html("A cidade deve conter entre 3 e 70 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoCidade").html("");
        return true;
    }
    return false;
}

function ValidaBairro() {
    var bairro = $("#Bairro").val();
    var contador = 0;
    //Valida Bairro
    if (bairro == "") {
        $("#erroValidacaoBairro").html("O bairro deve ser informado.");
        contador += 1;
    }
    else if (bairro.length < 3 || bairro.length > 70) {
        $("#erroValidacaoBairro").html("O bairro deve conter entre 3 e 70 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoBairro").html("");
        return true;
    }
    return false;
}

function ValidaRua() {
    var rua = $("#Rua").val();
    var contador = 0;
    //Valida Rua
    if (rua == "") {
        $("#erroValidacaoRua").html("O endereço deve ser informado.");
        contador += 1;
    }
    else if (rua.length < 3 || rua.length > 70) {
        $("#erroValidacaoRua").html("O endereço deve conter entre 3 e 70 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoRua").html("");
        return true;
    }
    return false;
}
function ValidaComplemento() {
    var complemento = $("#Complemento").val();
    var contador = 0;

    if (complemento.length > 100) {
        $("#erroValidacaoComplemento").html("O complemento pode conter até 100 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoComplemento").html("");
        return true;
    }
    return false;
}
function ValidaNumero() {
    var numero = $("#Numero").val();
    var contador = 0;

    if (numero == "") {
        $("#erroValidacaoNumero").html("O número deve ser informado.");
        contador += 1;
    }
    else if (numero < 0 || numero > 99999) {
        $("#erroValidacaoNumero").html("O número deve conter de 1 até 6 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoNumero").html("");
        return true;
    }
    return false;
}

function ValidaAbre() {
    var abre = $("#Abre").val();
    if (abre == "") {
        $("#erroValidacaoAbre").html("O horário de abertura deve ser informado.");
        contador += 1;
        return false;
    }
    return true;
}

function ValidaFecha() {
    var fecha = $("#Fecha").val();
    if (fecha == "") {
        $("#erroValidacaoFecha").html("O horário de encerramento deve ser informado.");
        contador += 1;
        return false;
    }
    return true;
}

function ValidaDiasDisponiveis() {
    var diasDisponiveis = $("#DiasDisponiveis").val();

    if (diasDisponiveis == 0) {
        $("#erroValidacaoDiasDisponiveis").html("Ao menos um dia deve ser selecionado.");
        return false;
    }
    $("#erroValidacaoDiasDisponiveis").html("");
    return true;
}

function ValidaValor() {
    var valor = $("#Valor").val();
    if (valor == "") {
        $("#erroValidacaoValor").html("O valor deve ser informado.");
        contador += 1;
        return false;
    }
    return true;
}
function ValidaQuantidade() {
    var qtd = $("#Quantidade").val();
    if (qtd == "" || qtd == 0) {
        $("#erroValidacaoQuantidade").html("Ao menos uma vaga deve ser criada.");
        return false;
    }
    $("#erroValidacaoQuantidade").html("");
    return true;
}

function ValidaFormulario() {
    var contador = 0;

    if (!ValidaCEP()) {
        contador += 1;
    }
    if (!ValidaUF()) {
        contador += 1;
    }
    if (!ValidaCidade()) {
        contador += 1;
    }
    if (!ValidaBairro()) {
        contador += 1;
    }
    if (!ValidaRua()) {
        contador += 1;
    }
    if (!ValidaComplemento()) {
        contador += 1;
    }
    if (!ValidaNumero()) {
        contador += 1;
    }
    if (!ValidaAbre()) {
        contador += 1;
    }
    if (!ValidaFecha()) {
        contador += 1;
    }
    if (!ValidaDiasDisponiveis()) {
        contador += 1;
    }
    if (!ValidaValor()) {
        contador += 1;
    }
    if (!ValidaQuantidade) {
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
