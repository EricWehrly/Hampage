(function () {
    var lockFrameSize = false;

    var canvasArea = document.getElementById('canvasArea');
    var canvasSelector = document.getElementById("canvasSelector");
    var animationFrameArea = document.getElementById("animationFrameArea");
    var lockAnimationFrameSize = document.getElementById("lockAnimationFrameSize");

// TODO: Load sprites from database ...

    function saveSprite() {
        // TODO: See if it's possible to kick back .json download without server
    }

    canvasArea.ondragover = function() {
        this.className = 'hover';
        return false;
    };

    canvasArea.ondragend = function() {
        this.className = '';
        return false;
    };

    canvasArea.ondrop = function(e) {
        this.className = '';
        e.preventDefault();

        var reader = new FileReader();
        reader.onload = function(event) {

            var image = new Image();

            image.onload = function() {
                canvasArea.style.backgroundImage = "url(" + this.src + ")";
                canvasArea.style.width = this.width + "px";
                canvasArea.style.height = this.height + "px";
                console.log(document.body.width);
                animationFrameArea.style.maxWidth = document.body.clientWidth - this.width;
            }
            image.src = event.target.result;
        }

        reader.readAsDataURL(e.dataTransfer.files[0]);
    }

    canvasArea.onmousedown = function(e) {
        e.preventDefault();

        canvasSelector.style.display = "inline-block";
        canvasSelector.style.left = e.clientX + "px";
        canvasSelector.style.top = e.clientY + "px";
    }

    function canvasMouseMove(e) {
        e.preventDefault();

        if (lockFrameSize) {
            canvasSelector.style.left = e.clientX + "px";
            canvasSelector.style.top = e.clientY + "px";
            return;
        }

        var newWidth, newHeight, newLeft, newTop;
        var currentLeft = parseInt(canvasSelector.style.left);
        var currentTop = parseInt(canvasSelector.style.top);

        if (e.clientX > currentLeft) {
            newWidth = e.clientX - currentLeft;
            newLeft = currentLeft;
        } else {
            newLeft = e.clientX;
            newWidth = newLeft - currentLeft;
        }

        if (e.clientY > currentTop) {
            newHeight = e.clientY - currentTop;
            newTop = currentTop;
        } else {
            newTop = e.clientY;
            newHeight = newTop - currentTop;
        }

        canvasSelector.style.width = newWidth + "px";
        canvasSelector.style.height = newHeight + "px";
        canvasSelector.style.left = newLeft + "px";
        canvasSelector.style.top = newTop + "px";
    }

    canvasArea.onmousemove = canvasMouseMove;
    canvasSelector.onmousemove = canvasMouseMove;

    canvasSelector.onmouseup = function(e) {
        e.preventDefault();
        canvasSelector.style.display = "none";

        if (lockAnimationFrameSize.checked) lockFrameSize = true;

        addFrame();
    }

    function addFrame() {

        var frameX = parseInt(canvasSelector.style.left);
        var frameY = parseInt(canvasSelector.style.top);
        var frameWidth = parseInt(canvasSelector.style.width);
        var frameHeight = parseInt(canvasSelector.style.height);

        var newFrame = document.createElement("div");
        newFrame.className = "animationFrame";
        newFrame.style.backgroundPositionX = -frameX + "px";
        newFrame.style.backgroundPositionY = -frameY + "px";
        newFrame.style.width = frameWidth + "px";
        newFrame.style.height = frameHeight + "px";

        newFrame.style.backgroundImage = canvasArea.style.backgroundImage;

        animationFrameArea.appendChild(newFrame);
    }
})();