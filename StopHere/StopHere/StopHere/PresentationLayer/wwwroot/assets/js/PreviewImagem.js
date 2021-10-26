//Primeiramente inserimos o input de imagem em uma variável, o que torna possível criar um evento no elemento
//E então adicionamos um evento change, que é ativado quando o usuário insere uma imagem no input
//No evento encapsulamos os arquivos na variável files, e também inicializamos FileReader, uma biblioteca do próprio JavaScript para tratar arquivos
//Por fim, substituímos o src da nossa tag de img, que até então está vazio, por o resultado da imagem enviada

const input1 = document.querySelector('#image1');
input1.addEventListener('change', function (e) {
    const tgt1 = e.target || window.event.srcElement;
    const files1 = tgt1.files;
    const fr1 = new FileReader();
    fr1.onload = function () {
        document.querySelector('#preview-image1').src = fr1.result;
    }
    fr1.readAsDataURL(files1[0]);
});

const input2 = document.querySelector('#image2');
input2.addEventListener('change', function (e) {
    const tgt2 = e.target || window.event.srcElement;
    const files2 = tgt2.files;
    const fr2 = new FileReader();
    fr2.onload = function () {
        document.querySelector('#preview-image2').src = fr2.result;
    }
    fr2.readAsDataURL(files2[0]);
});

const input3 = document.querySelector('#image3');
input3.addEventListener('change', function (e) {
    const tgt3 = e.target || window.event.srcElement;
    const files3 = tgt3.files;
    const fr3 = new FileReader();
    fr3.onload = function () {
        document.querySelector('#preview-image3').src = fr3.result;
    }
    fr3.readAsDataURL(files3[0]);
});

const input4 = document.querySelector('#image4');
input4.addEventListener('change', function (e) {
    const tgt4 = e.target || window.event.srcElement;
    const files4 = tgt4.files;
    const fr4 = new FileReader();
    fr4.onload = function () {
        document.querySelector('#preview-image4').src = fr4.result;
    }
    fr4.readAsDataURL(files4[0]);
});

const input5 = document.querySelector('#image5');
input5.addEventListener('change', function (e) {
    const tgt5 = e.target || window.event.srcElement;
    const files5 = tgt5.files;
    const fr5 = new FileReader();
    fr5.onload = function () {
        document.querySelector('#preview-image5').src = fr5.result;
    }
    fr5.readAsDataURL(files5[0]);
});

const input6 = document.querySelector('#image6');
input6.addEventListener('change', function (e) {
    const tgt6 = e.target || window.event.srcElement;
    const files6 = tgt6.files;
    const fr6 = new FileReader();
    fr6.onload = function () {
        document.querySelector('#preview-image6').src = fr6.result;
    }
    fr6.readAsDataURL(files6[0]);
});