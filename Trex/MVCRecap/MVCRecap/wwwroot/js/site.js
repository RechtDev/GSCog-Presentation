window.addEventListener("load", onLoaded);

function onLoaded() {
    let priceInput = document.getElementById("money");

    priceInput.addEventListener("blur", () => {
        let value = priceInput.value;

        if (value.length >= 3) {
            priceInput.value = separator(value);
        }

    });
}

function separator(numb) {
    var str = numb.toString().split(".");
    str[0] = str[0].replace(/\B(?=(\d{3})+(?!\d))/g, ","); return str.join(".");
}