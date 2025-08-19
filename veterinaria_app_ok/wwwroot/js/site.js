window.addEventListener("load", () => {
    const slider = document.querySelector("#sliderInicio");
    let slides = document.querySelectorAll(".img-inicio");
    const slideWidth = slides[0].clientWidth;

    // Clonar el primer y último slide
    const firstClone = slides[0].cloneNode(true);
    const lastClone = slides[slides.length - 1].cloneNode(true);

    firstClone.classList.add("clone");
    lastClone.classList.add("clone");

    slider.appendChild(firstClone);
    slider.insertBefore(lastClone, slides[0]);

    slides = document.querySelectorAll(".img-inicio");

    let currentIndex = 1;
    let isTransitioning = false;

    slider.style.transform = `translateX(-${slideWidth * currentIndex}px)`;

    const avanzar = () => {
        if (isTransitioning) return;
        isTransitioning = true;

        currentIndex++;
        slider.style.transition = "transform 0.5s ease-in-out";
        slider.style.transform = `translateX(-${slideWidth * currentIndex}px)`;
    };

    slider.addEventListener("transitionend", () => {
        if (slides[currentIndex].classList.contains("clone")) {
            slider.style.transition = "none";
            currentIndex = currentIndex === slides.length - 1 ? 1 : slides.length - 2;
            slider.style.transform = `translateX(-${slideWidth * currentIndex}px)`;
        }
        isTransitioning = false;
    });

    setInterval(avanzar, 3000);
});
