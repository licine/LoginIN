// 加载 (时间会在页面加载完成后触发)
var down_x;
window.onload = function () {

    (function () {
        // 获取滑动控件容器 ,灰色背景
        var dragContainer = document.getElementById("dragContainer");
        var isVertifySucc = document.getElementById("Vertify_hidd");
        // 获取滑块左边部分,绿色背景
        var dragBg = document.getElementById("dragBg");
        // 获取滑动验证容器文本
        var dragText = document.getElementById("dragText");
        //获取滑块
        var dragHandler = document.getElementById("dragHandler");
        // 滑块的最大偏移量  =  滑块验证容器文本长度  -  滑块长度
        var maxHandleOffset = dragContainer.clientWidth -  dragHandler.clientWidth;

        // 是否验证成功的标记
        isVertifySucc.value = false;

        initDrag();

        function initDrag(){
            
            // 在滑动验证容器文本中写入  “拖动滑块验证”
            dragText.textContent = "请按住滑块，拖动到最右边";
            // 给滑块添加鼠标按下监听
            dragHandler.addEventListener("mousedown", onDragHandlerMouseDown);
        }
        // 选中滑块
        function onDragHandlerMouseDown(){
			down_x=event.clientX;
            // 鼠标移动监听
            document.addEventListener("mousemove", onDragHandlerMouseMove);
            // 鼠标松开监听
            document.addEventListener("mouseup", onDragHandlerMouseUp);
        }

        //滑块移动
        function onDragHandlerMouseMove () {
            // html 不存在width属性  只有clientWidth
            // offsetX 是相对当前元素  clientX 和  PageX是相对于其父元素的
            // 滑块移动量
			
            var left = event.clientX - down_x;
            // /
            if(left < 0){
                left = 0;
                // 如果 滑块移动量 > 滑块的最大量  ,则调用 验证成功函数
            }else if(left > maxHandleOffset ){
                left = maxHandleOffset;
				verifySucc();
            }
            // 滑块移动量
            dragHandler.style.left = left + "px";
            // 绿色背景长度
            dragBg.style.width = dragHandler.style.left;
        }
        // 松开滑块函数
        function onDragHandlerMouseUp () {
            //移除鼠标移动监听
            document.removeEventListener("mousemove", onDragHandlerMouseMove);
            // 移除鼠标松开监听
            document.removeEventListener("mouseup", onDragHandlerMouseUp);
			dragHandler.style.left = 0;
			dragBg.style.width = 0;
        }

        function getIsVertifySucc() {
            return isVertifySucc.value;
        }

        // 验证成功
        function verifySucc(){
            // 成功标记 不可回弹
            isVertifySucc.value = true;
            //容器文本的文字改为白色“验证通过”字体
            dragText.textContent = "验证通过";
            dragText.style.color = "white";
            // 验证通过的滑块背景
            dragHandler.setAttribute("class","dragHandlerOkBg");
            //移除鼠标按下监听
            dragHandler.removeEventListener("mousedown", onDragHandlerMouseDown);
            //移除鼠标移动监听
            document.removeEventListener("mousemove", onDragHandlerMouseMove);
            // 移除鼠标松开监听
            document.removeEventListener("mouseup", onDragHandlerMouseUp);
            // 匹配成功进行跳转
            // window.location.href="成功页面.html";

        }
    // })
    })()
}