function viewImage(imageID, fileID, customfileID, buttonID) {
    const img = document.getElementById(imageID);
    const fileInput = document.getElementById(fileID);
    const customFile = document.getElementById(customfileID);
    const button = document.getElementById(buttonID);


    fileInput.addEventListener("change", function () {
        let file = this.files[0];
        if (file) {
            customFile.value = fileInput.value.match(/[\/\\]([\w\d\s\.\-\(\)]+)$/);
            const reader = new FileReader();
            reader.addEventListener("load", function () {
                img.setAttribute("src", this.result);
            });
            reader.readAsDataURL(file);
        }
        else {
            customFile.value = "fayl seçilməyib";
            img.src = null;
        }
    });

    button.addEventListener("click", function (e) {
        e.preventDefault();
        fileInput.click();
    });


}