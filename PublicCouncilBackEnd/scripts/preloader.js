function hideLoading() {
    setTimeout(() => {
        document.getElementById("preloader").style.opacity = 0;
        document.getElementById("preloader").style.zIndex = -1;
    }, 200);
}