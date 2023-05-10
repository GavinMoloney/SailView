window.carouselInterop = {
    nextSlide: (carousel) => {
        const items = carousel.children;
        const activeIndex = Array.from(items).findIndex((item) => item.classList.contains("active"));

        items[activeIndex].classList.remove("active");
        const nextIndex = (activeIndex + 1) % items.length;
        items[nextIndex].classList.add("active");
    },

    prevSlide: (carousel) => {
        const items = carousel.children;
        const activeIndex = Array.from(items).findIndex((item) => item.classList.contains("active"));

        items[activeIndex].classList.remove("active");
        const prevIndex = (activeIndex - 1 + items.length) % items.length;
        items[prevIndex].classList.add("active");
    }
};