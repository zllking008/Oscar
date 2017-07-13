var GGLCanvas = {};
//var defaultW = 270;
//var defaultH = 100;
GGLCanvas.defaultW = 270;
GGLCanvas.defaultH = 100;
GGLCanvas.Config = {};
GGLCanvas.Init = function (id, imgSrc, callback, text, isPlay, cwidth, cheight) {
    GGLCanvas.Config.Callback = callback == undefined ? null : callback;//回调函数
    GGLCanvas.Config.IsPlay = isPlay;//是否正常显示，如果为false，触摸或者按下的时候则触发回调函数
    canvas = document.getElementById(id);
    var img = new Image();
    w = cwidth == undefined ? this.defaultW : cwidth;
    h = cheight == undefined ? this.defaultH : cheight;
    if (imgSrc != "") {
        img.addEventListener('load', function (e) {
            //img.src = imgSrc;
            w = w > 0 ? w : img.width;
            h = h > 0 ? h : img.height;
        });
        img.src = imgSrc;
        canvas.style.backgroundImage = 'url(' + img.src + ')';
    }
    canvas.style.backgroundColor = "#ccc";
    canvas.style.position = 'absolute';
    canvas.width = w;
    canvas.height = h;

    mousedown = false;
    offsetX = canvas.offsetLeft,
    offsetY = canvas.offsetTop;


    ctx = canvas.getContext('2d');
    //canvas.style.backgroundImage = 'url(http://localhost:40003/activity/GetCode?r=' + Math.random() + ')';
    //画蒙层
    ctx.fillStyle = 'gray';
    ctx.fillRect(0, 0, w, h);
    if (text.length > 0) {
        //蒙层上写字
        var fontSize = Math.min(parseInt(w / (text.length + 1)), parseInt(h * 0.6));
        //ctx.font = "60px 黑体";//设置蒙层字体
        ctx.font = fontSize + "px 黑体";//设置蒙层字体
        ctx.textBaseline = "middle";
        ctx.textAlign = "center";//字体居中
        ctx.fillStyle = '#fff';
        ctx.fillText(text, canvas.width / 2, canvas.height / 2);
        ctx.beginPath();
    }

    ctx.globalCompositeOperation = 'destination-out';

    canvas.addEventListener('touchstart', GGLCanvas.eventDown);
    canvas.addEventListener('touchend', GGLCanvas.eventUp);
    canvas.addEventListener('touchmove', GGLCanvas.eventMove);
    canvas.addEventListener('mousedown', GGLCanvas.eventDown);
    canvas.addEventListener('mouseup', GGLCanvas.eventUp);
    canvas.addEventListener('mousemove', GGLCanvas.eventMove);

}

GGLCanvas.eventDown = function (e) {
    /*取消事件的默认动作
    该方法将通知 Web 浏览器不要执行与事件关联的默认动作（如果存在这样的动作）。
    例如，如果 type 属性是 "submit"，在事件传播的任意阶段可以调用任意的事件句柄，
    通过调用该方法，可以阻止提交表单。注意，如果 Event 对象的 cancelable 属性是 fasle，
    那么就没有默认动作，或者不能阻止默认动作。无论哪种情况，调用该方法都没有作用。*/
    if (!GGLCanvas.Config.IsPlay) {
        if (GGLCanvas.Config.Callback != null)
            GGLCanvas.Config.Callback();
        return;
    }
    e.preventDefault();
    mousedown = true;

}

GGLCanvas.eventUp = function (e) {

    e.preventDefault();
    mousedown = false;
    var data = ctx.getImageData(0, 0, w, h).data;
    for (var i = 0, j = 0; i < data.length; i += 4) {
        if (data[i] && data[i + 1] && data[i + 2] && data[i + 3]) {
            j++;
        }
    }
    if (j <= w * h * 0.4) {
        //阴影部分小于40%就自动展开
        //ctx = canvas.getContext('2d');
        /*重绘canvas使其达到完全展示*/
        //                    ctx.save();
        //                    ctx.drawImage(img, 0, 0);
        //                    ctx.restore();

        /*擦除蒙层*/
        ctx.clearRect(0, 0, w, h);
        ctx.save();

        canvas.removeEventListener('touchstart', GGLCanvas.eventDown);
        canvas.removeEventListener('touchend', GGLCanvas.eventUp);
        canvas.removeEventListener('touchmove', GGLCanvas.eventMove);
        canvas.removeEventListener('mousedown', GGLCanvas.eventDown);
        canvas.removeEventListener('mouseup', GGLCanvas.eventUp);
        canvas.removeEventListener('mousemove', GGLCanvas.eventMove);
        if (GGLCanvas.Config.Callback != null) GGLCanvas.Config.Callback();
    }
}

GGLCanvas.eventMove = function (e) {

    e.preventDefault();
    if (mousedown) {
        if (e.changedTouches) {
            e = e.changedTouches[e.changedTouches.length - 1];
        }
        var x = (e.clientX + document.body.scrollLeft || e.pageX) - offsetX || 0,
            y = (e.clientY + document.body.scrollTop || e.pageY) - offsetY || 0;
        with (ctx) {
            beginPath();
            arc(x, y, 25, 0, Math.PI * 2);
            fill();
        }
    }
}