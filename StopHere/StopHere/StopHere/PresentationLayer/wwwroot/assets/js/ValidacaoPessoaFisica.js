function ValidaNome() {
    var nome = $("#Nome").val();
    var contador = 0;

    if (nome == "") {
        $("#erroValidacaoNome").html("O nome deve ser informado.");
        contador += 1;
    }
    else if (nome.length < 3 || nome.length > 70) {
        $("#erroValidacaoNome").html("O nome deve conter entre 3 e 70 caracteres.");
        contador += 1;
    }
    if (contador == 0) {
        $("#erroValidacaoNome").html("");
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

function ValidaCPF() {
    var cpf = $("#CPF").val();
    var contador = 0;

    cpf = cpf.replace(/[^\d]+/g, '');
    if (cpf == '') {
        $("#erroValidacaoCPF").html("O CPF é inválido.");
        contador += 1;
        return false;
    }
    if (cpf.length != 11 ||
        cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999") {
        $("#erroValidacaoCPF").html("O CPF é inválido.");
        contador += 1;
        return false;
    }
    add = 0;
    for (i = 0; i < 9; i++) {
        add += parseInt(cpf.charAt(i)) * (10 - i);
        rev = 11 - (add % 11);
    }
    if (rev == 10 || rev == 11) {
        rev = 0;
    }
    if (rev != parseInt(cpf.charAt(9))) {
        $("#erroValidacaoCPF").html("O CPF é inválido.");
        contador += 1;
        return false;
    }
    add = 0;
    for (i = 0; i < 10; i++) {
        add += parseInt(cpf.charAt(i)) * (11 - i);
        rev = 11 - (add % 11);
    }
    if (rev == 10 || rev == 11) {
        rev = 0;
    }
    if (rev != parseInt(cpf.charAt(10))) {
        $("#erroValidacaoCPF").html("O CPF é inválido.");
        contador += 1;
        return false;
    }
    if (contador == 0) {
        $("#erroValidacaoCPF").html("");
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

    if (!ValidaNome()) {
        contador += 1;
    }
    if (!ValidaCPF()) {
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
        // Chamar modal e informar que "cadastro foi realizado com sucesso."
    }
    else {
        return false;
    }
}


