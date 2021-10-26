function ValidaRazaoSocial() {
    var razaoSocial = $("#RazaoSocial").val();
    var contador = 0;

    if (razaoSocial == "") {
        $("#erroValidacaoRazaoSocial").html("A razão social deve ser informada.");
        contador += 1;
    }
    else if (razaoSocial.length < 3 || razaoSocial.length > 100) {
        $("#erroValidacaoRazaoSocial").html("A razão social deve conter entre 3 e 100 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoRazaoSocial").html("");
        return true;
    }
    return false;
}

function ValidaNomeFantasia() {
    var nomeFantasia = $("#NomeFantasia").val();
    var contador = 0;

    if (nomeFantasia == "") {
        $("#erroValidacaoNomeFantasia").html("O nome fantasia deve ser informado.");
        contador += 1;
    }
    else if (nomeFantasia.length < 3 || nomeFantasia.length > 100) {
        $("#erroValidacaoNomeFantasia").html("O nome fantasia deve conter entre 3 e 100 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoNomeFantasia").html("");
        return true;
    }
    return false;
}

function ValidaCNPJ() {
    var cnpj = $("#CNPJ").val();
    var contador = 0;

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') {
        $("#erroValidacaoCNPJ").html("O CNPJ é inválido.");
        contador += 1;
        return false;
    }
    if (cnpj.length != 14) {
        $("#erroValidacaoCNPJ").html("O CNPJ é inválido.");
        contador += 1;
        return false;
    }
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999") {
        $("#erroValidacaoCNPJ").html("O CNPJ é inválido.");
        contador += 1;
        return false;
    }
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0)) {
        $("#erroValidacaoCNPJ").html("O CNPJ é inválido.");
        contador += 1;
        return false;
    }
    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1)) {
        $("#erroValidacaoCNPJ").html("O CNPJ é inválido.");
        contador += 1;
        return false;
    }
    if (contador == 0) {
        $("#erroValidacaoCNPJ").html("");
        return true;
    }
    return false;
}

function ValidaInscricaoEstadual() {
    var inscricaoEstadual = $("#InscricaoEstadual").val();
    var contador = 0;

    inscricaoEstadual = inscricaoEstadual.replace(/\./g, "");
    inscricaoEstadual = inscricaoEstadual.replace(/\\/g, "");
    inscricaoEstadual = inscricaoEstadual.replace(/\-/g, "");
    inscricaoEstadual = inscricaoEstadual.replace(/\//g, "");


    inscricaoEstadual = inscricaoEstadual.trim();

    if (inscricaoEstadual == "") {
        $("#erroValidacaoInscricaoEstadual").html("A inscrição estadual deve ser informada.");
        contador += 1;
    }
    else if (inscricaoEstadual.length < 9 || inscricaoEstadual.length > 15) {
        $("#erroValidacaoInscricaoEstadual").html("A inscrição estadual deve conter entre 9 e 15 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoInscricaoEstadual").html("");
        return true;
    }
    return false;
}

function ValidaEmail() {
    var email = $("#Email").val();
    var contador = 0;
    var usuario = email.substring(0, email.indexOf("@"));
    var dominio = email.substring(email.indexOf("@") + 1, email.length);
    if ((usuario.length >= 1) &&
        (dominio.length >= 3) &&
        (usuario.search("@") == -1) &&
        (dominio.search("@") == -1) &&
        (usuario.search(" ") == -1) &&
        (dominio.search(" ") == -1) &&
        (dominio.search(".") != -1) &&
        (dominio.indexOf(".") >= 1) &&
        (dominio.lastIndexOf(".") < dominio.length - 1) &&
        (dominio.endsWith(".com") || dominio.endsWith(".com.br"))) {
    }
    else {
        $("#erroValidacaoEmail").html("O e-mail é inválido.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoEmail").html("");
        return true;
    }
    return false;
}

function ValidaTelefone() {
    var telefone = $("#Telefone").val();
    var contador = 0;

    if (telefone == "") {
        $("#erroValidacaoTelefone").html("O celular deve ser informado.");
        contador += 1;
    }
    else if (telefone.length < 8 || telefone.length > 15) {
        $("#erroValidacaoTelefone").html("O celular deve conter entre 8 e 15 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoTelefone").html("");
        return true;
    }
    return false;
}



function ValidaCEP() {
    var cep = $("#CEP").val();
    var contador = 0;

    if (cep == "") {
        $("#erroValidacaoCEP").html("O CEP deve ser informado.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoCEP").html("");
        return true;
    }
    return false;
}

function ValidaUF() {
    var uf = $("#UF").val();
    var contador = 0;

    if (uf == 0) {
        $("#erroValidacaoUF").html("O estado deve ser selecionado.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoUF").html("");
        return true;
    }
    return false;
}

function ValidaCidade() {
    var cidade = $("#Cidade").val();
    var contador = 0;

    if (cidade == "") {
        $("#erroValidacaoCidade").html("A cidade deve ser informada.");
        contador += 1;
    }
    else if (cidade.length < 3 || cidade.length > 100) {
        $("#erroValidacaoCidade").html("A cidade deve conter de 3 até 100 caracteres.");
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

    if (bairro == "") {
        $("#erroValidacaoBairro").html("O bairro deve ser informado.");
        contador += 1;
    }
    else if (bairro.length < 3 || bairro.length > 100) {
        $("#erroValidacaoBairro").html("O bairro deve conter de 3 até 100 caracteres.");
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

    if (rua == "") {
        $("#erroValidacaoRua").html("O endereço deve ser informado.");
        contador += 1;
    }
    else if (rua.length < 3 || rua.length > 100) {
        $("#erroValidacaoRua").html("O endereço deve conter de 3 até 100 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoRua").html("");
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
    else if (numero < 0 || numero > 999999) {
        $("#erroValidacaoNumero").html("O número deve conter de 1 até 6 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoNumero").html("");
        return true;
    }
    return false;
}
function ValidaSenha(isCreateMethod) {
    var senha = $("#Senha").val();
    var contador = 0;

    if (isCreateMethod) {
        if (senha == "") {
            $("#erroValidacaoSenha").html("A senha deve ser informada.");
            contador += 1;
        }
        else if (senha.length < 6) {
            $("#erroValidacaoSenha").html("A senha deve conter no mínimo 6 caracteres.");
            contador += 1;
        }
    }
    
    if (contador == 0) {
        $("#erroValidacaoSenha").html("");
        return true;
    }
    return false;
}

function ValidaSenhaConfirmacao(isCreateMethod) {
    var senhaConfirmacao = $("#SenhaConfirmacao").val();
    var senha = $("#Senha").val();
    var contador = 0;

    if (isCreateMethod) {
        if (senhaConfirmacao == "") {
            $("#erroValidacaoSenhaConfirmacao").html("A confirmação de senha é inválida.");
            contador += 1;
        }
    }
    if (senhaConfirmacao != senha) {
        $("#erroValidacaoSenhaConfirmacao").html("A confirmação de senha é inválida.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoSenhaConfirmacao").html("");
        return true;
    }
    return false;
}

function ValidaFormulario(isCreateMethod) {
    var contador = 0;

    if (!ValidaRazaoSocial()) {
        contador += 1;
    }
    if (!ValidaNomeFantasia()) {
        contador += 1;
    }
    if (!ValidaCNPJ()) {
        contador += 1;
    }
    if (!ValidaInscricaoEstadual()) {
        contador += 1;
    }
    if (!ValidaEmail()) {
        contador += 1;
    }
    if (!ValidaTelefone()) {
        contador += 1;
    }
    if (!ValidaSenha(isCreateMethod)) {
        contador += 1;
    }
    if (!ValidaSenhaConfirmacao(isCreateMethod)) {
        contador += 1;
    }
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
    if (!ValidaNumero()) {
        contador += 1;
    }
    if (contador != 0) {
        return;
    }
    if (contador == 0) {
        $("#formulario").submit();
        return true;
        // Chamar modal e informar que "cadastro foi realizado com sucesso".
    }
    return false;
}

