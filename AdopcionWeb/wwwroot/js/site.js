// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Inicialización del carrusel usando jQuery y Bootstrap

const textContainer = document.querySelector('.adoption-text');
const text = textContainer.querySelector('p');
const textWidth = text.offsetWidth;
let currentPosition = textWidth;
const animationSpeed = 50; // Velocidad de desplazamiento (en milisegundos)

function slide() {
    currentPosition--;
    text.style.transform = `translateX(${currentPosition}px)`;

    if (currentPosition === -textWidth) {
        currentPosition = textWidth;
        setTimeout(() => {
            requestAnimationFrame(slide);
        }, 1000); // Pausa al llegar al final del texto (1 segundo)
    } else {
        requestAnimationFrame(slide);
    }
}

slide();
