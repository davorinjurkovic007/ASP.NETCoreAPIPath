console.log("Hello World");

const theForm = document.getElementById("theForm");
if (theForm) {
    theForm.hidden = true;
}

const showButtton = document.getElementById("showButton");

showButtton.addEventListener("click", function () {
    if (theForm.hidden) {
        theForm.hidden = false;
        showButtton.innerText = "Hide Button";
    }
    else {
        theForm.hidden = true;
        showButtton.innerText = "Show Button";
    }
});
