var slideIndex = 1;
showDivs(slideIndex);

function plusDivs(n) {
    showDivs(slideIndex += n);
}

function currentDiv(n) {
    showDivs(slideIndex = n);
}

function showDivs(n) {
    var i;
    var x = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("demo");
    if (n > x.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = x.length }
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" w3-white", "");
    }
    x[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " w3-white";
}

let photo = document.getElementById('PreviewFotoVaga1');
let file = document.getElementById('FotoVaga1');

photo.addEventListener('click', () => {
    file.click();
});

file.addEventListener('change', () => {

    if (file.files.length <= 0) {
        return;
    }

    let reader = new FileReader();

    reader.onload = () => {
        photo.src = reader.result;
    }

    reader.readAsDataURL(file.files[0]);
});

let photo2 = document.getElementById('PreviewFotoVaga2');
let file2 = document.getElementById('FotoVaga2');

photo2.addEventListener('click', () => {
    file2.click();
});

file2.addEventListener('change', () => {

    if (file2.files.length <= 0) {
        return;
    }

    let reader = new FileReader();

    reader.onload = () => {
        photo2.src = reader.result;
    }

    reader.readAsDataURL(file2.files[0]);
});

let photo3 = document.getElementById('PreviewFotoVaga3');
let file3 = document.getElementById('FotoVaga3');

photo3.addEventListener('click', () => {
    file3.click();
});

file3.addEventListener('change', () => {

    if (file3.files.length <= 0) {
        return;
    }

    let reader = new FileReader();

    reader.onload = () => {
        photo3.src = reader.result;
    }

    reader.readAsDataURL(file3.files[0]);
});
