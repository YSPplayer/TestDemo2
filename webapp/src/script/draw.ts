import Phaser from 'phaser';
import Util from './util';
export interface Rect {
    x: number;
    y: number;
    width: number;
    height: number;
}
export default class DrawManager {
    scene: Phaser.Scene;
     constructor(scene:Phaser.Scene) {
        this.scene = scene;
    }
    drawLine(height:number, x1:number,y1:number,x2:number,y2:number,color:string) {
        const graphics = this.scene.add.graphics();
        // 使用填充矩形而不是线条，确保完全覆盖，不留间隙
        graphics.fillStyle(Util.ToColor(color));
        graphics.fillRect(x1, y1 - height / 2, x2 - x1, height);
    }
    //场地中每一行的组件
    drawFieldLine(rect:Rect) {
        const scene = this.scene;
        const fieldLineBox = scene.add.rectangle(rect.x, rect.y, rect.width, rect.height,
                 Util.ToColor('#8acfe6'));
        fieldLineBox.setOrigin(0, 0);
    }
    //最右侧区域
    drawRight(rect:Rect) {
        const scene = this.scene;
        const width = scene.scale.width;
        const height = scene.scale.height;
        const rightWidth = width - rect.x - rect.width;
        const rightX = rect.x + rect.width;
        const rightHeight = height - rect.y;
        const rightBox = scene.add.rectangle(rightX, rect.y, rightWidth, rightHeight,
              Util.ToColor('#54b985'));
         rightBox.setOrigin(0, 0);
         
         // 计算第3条分隔线的y位置（与drawField中的第3条分隔线对齐）
         // drawField中的分隔线计算：lineY = y + i * (lineHeight + midlineheight)
         // 第3条分隔线（i=2）的位置：separatorY = lineY + lineHeight = y + 2 * (lineHeight + midlineheight) + lineHeight
         const fieldHeight = rightHeight;
         const midlineheight = 2;
         const numLines = 6;
         const numSeparators = numLines - 1; // 5条分隔线
         const lineHeight = (fieldHeight - numSeparators * midlineheight) / numLines;
         // 第3条分隔线的y位置（索引为2）
         const thirdSeparatorY = rect.y + 2 * (lineHeight + midlineheight) + lineHeight;
         
         // 绘制分割线（2px宽，白色）
         const separatorLine = scene.add.rectangle(
             rightX,
             thirdSeparatorY,
             rightWidth,
             midlineheight,
             Util.ToColor('#ffffff')
         );
         separatorLine.setOrigin(0, 0);
         
         // 计算上下两个区域
         const topAreaHeight = thirdSeparatorY - rect.y;
         const bottomAreaHeight = rightHeight - topAreaHeight - midlineheight;
         
         // 矩形长宽比为1.45:1，即 height = width * 1.45（长度比宽度大）
         // 计算矩形尺寸，确保在容器内部
         const aspectRatio = 1.45;
         
         // 上区域矩形
         const topRectWidth = Math.min(rightWidth * 0.8, topAreaHeight / aspectRatio * 0.9);
         const topRectHeight = topRectWidth * aspectRatio;
         const topRectX = rightX + (rightWidth - topRectWidth) / 2;
         const topRectY = rect.y + (topAreaHeight - topRectHeight) / 2;
         const topRect = scene.add.rectangle(
             topRectX,
             topRectY,
             topRectWidth,
             topRectHeight,
             Util.ToColor('#ffffff')
         );
         topRect.setOrigin(0, 0);
         
         // 下区域矩形
         const bottomRectWidth = Math.min(rightWidth * 0.8, bottomAreaHeight / aspectRatio * 0.9);
         const bottomRectHeight = bottomRectWidth * aspectRatio;
         const bottomRectX = rightX + (rightWidth - bottomRectWidth) / 2;
         const bottomRectY = thirdSeparatorY + midlineheight + (bottomAreaHeight - bottomRectHeight) / 2;
         const bottomRect = scene.add.rectangle(
             bottomRectX,
             bottomRectY,
             bottomRectWidth,
             bottomRectHeight,
             Util.ToColor('#ffffff')
         );
         bottomRect.setOrigin(0, 0);
         
         return {
            x: rightX,
            y: rect.y,
            width: rightWidth,
            height: rightHeight
         }
    }
    drawField(rect:Rect):Rect  {
        const scene = this.scene;
        const width = scene.scale.width;
        const height = scene.scale.height;
        const fieldWidth = width * 0.6;
        const fieldHeight = height - rect.y;
        const x =  rect.x + rect.width;
        const y = rect.y;
        const fieldWidthBox = scene.add.rectangle(x, y, fieldWidth, fieldHeight,
              Util.ToColor('#e85939'));
         fieldWidthBox.setOrigin(0, 0);
         const midlineheight = 2;
         const numLines = 6;
         const numSeparators = numLines - 1; // 5条分隔线
         // 计算每个区域的高度，确保总高度正好等于 fieldHeight
         const lineHeight = (fieldHeight - numSeparators * midlineheight) / numLines;
         const lineWidth = fieldWidth;
         for(let i = 0; i < numLines; i++) {
            const lineX = x;
            // 每个区域的 y 坐标：i * (lineHeight + midlineheight)
            const lineY = y + i * (lineHeight + midlineheight);
            this.drawFieldLine({ x: lineX, y: lineY, width: lineWidth, height: lineHeight });
            
            // 中间的4个矩形（索引1-4）添加纵向分割线，平分为5个部分
            if (i >= 1 && i <= 4) {
                const numVerticalLines = 4; // 4条线平分为5个部分
                const verticalLineWidth = midlineheight; // 线宽2
                // 计算每条纵向线的x位置
                for (let j = 0; j < numVerticalLines; j++) {
                    const verticalLineX = lineX + (lineWidth / 5) * (j + 1);
                    const verticalLineRect = scene.add.rectangle(
                        verticalLineX,
                        lineY,
                        verticalLineWidth,
                        lineHeight,
                        Util.ToColor('#ffffff')
                    );
                    verticalLineRect.setOrigin(0, 0);
                }
            }
            
            // 分隔线：只在非最后一个区域下方绘制，使用矩形确保完全覆盖
            if (i < numSeparators) {
                const separatorY = lineY + lineHeight;
                const separatorRect = scene.add.rectangle(
                    lineX, 
                    separatorY, 
                    lineWidth, 
                    midlineheight, 
                    Util.ToColor('#ffffff')
                );
                separatorRect.setOrigin(0, 0);
            }
        }
        return {
            x: x,
            y: y,
            width: fieldWidth,
            height: fieldHeight
        }
    }
    drawPanelBox(rect:Rect):Rect {   
        const scene = this.scene;
        const width = scene.scale.width;
        const height = scene.scale.height;
        const x = rect.x + rect.width;
        const y = rect.y;
        const panelWidth = width * 0.2;
        const panelHeight = height - rect.y;
        const characterBox = scene.add.rectangle(x, y, panelWidth, panelHeight,
              Util.ToColor('#cca7d7'));
        characterBox.setOrigin(0, 0);
        return {
            x: x,
            y: y,
            width: panelWidth,
            height: panelHeight
        }
    }
    //标头ui
    drawHeader():Rect {
        const scene = this.scene;
        const width = scene.scale.width;
        const height = scene.scale.height;
        const x = 0;
        const y = 0;
        const headerWidth = width;
        const headerHeight = height * 0.1;
        const headerBox = scene.add.rectangle(x, y, headerWidth, headerHeight,
              Util.ToColor('#ce6bb5ff'));
        headerBox.setOrigin(0, 0);
        
        // 左侧矩形
        const rectSize = headerHeight * 0.8;
        const leftRectX = headerHeight * 0.1;
        const leftRectY = headerHeight * 0.1;
        const leftRect = scene.add.rectangle(leftRectX, leftRectY, rectSize, rectSize,
              Util.ToColor('#ffffff'));
        leftRect.setOrigin(0, 0);
        
        // 右侧矩形
        const rightRectX = headerWidth - headerHeight * 0.1 - rectSize;
        const rightRectY = headerHeight * 0.1;
        const rightRect = scene.add.rectangle(rightRectX, rightRectY, rectSize, rectSize,
              Util.ToColor('#ffffff'));
        rightRect.setOrigin(0, 0);
        
        return {
            x: x,
            y: y,
            width: headerWidth,
            height: headerHeight
        }
    } 
    //左侧多人物框
    drawCharacterSBox(rect:Rect):Rect {
        const scene = this.scene;
        const width = scene.scale.width;
        const height = scene.scale.height;
        const containerWidth = width * 0.1;
        const containerHeight = height - rect.y - rect.height;
        const x = 0;
        const y = rect.y + rect.height;
        // 外框容器（可视区域）
        const container = scene.add.rectangle(x, y, containerWidth, containerHeight,
             Util.ToColor('#477496'));
        container.setOrigin(0, 0);
        container.setStrokeStyle(2, Util.ToColor('#e2e4bc'));
        
        // 创建可滚动的内容容器
        const scrollContentContainer = scene.add.container(x, y);
        
        const characterWidth = container.width * 0.8;
        const characterHeight = characterWidth;
        const margin = (container.width - characterWidth) / 2;
        
        // 将所有矩形添加到内容容器中
        for(let i = 0; i < 6; i++) {
            const boxX = margin;
            const boxY = margin + i * (characterHeight + margin);
            const characterBox = scene.add.rectangle(boxX, boxY, characterWidth, characterHeight,
                 Util.ToColor('#72ca4d'));
            characterBox.setOrigin(0, 0);
            scrollContentContainer.add(characterBox);
        }
        
        // 创建遮罩，限制可视区域为 container 的大小
        const maskGraphics = scene.make.graphics();
        maskGraphics.fillStyle(0xffffff);
        maskGraphics.fillRect(x, y, containerWidth, containerHeight);
        const mask = new Phaser.Display.Masks.GeometryMask(scene, maskGraphics);
        scrollContentContainer.setMask(mask);
        
        // 计算总内容高度和最大滚动距离
        const totalContentHeight = margin + 6 * (characterHeight + margin);
        let scrollY = 0;
        const maxScroll = Math.max(0, totalContentHeight - containerHeight);
        
        // 添加鼠标滚轮事件
        scene.input.on('wheel', (pointer: Phaser.Input.Pointer, gameObjects: any[], deltaX: number, deltaY: number) => {
            // 检查鼠标是否在滚动区域内
            if (pointer.x >= x && pointer.x <= x + containerWidth && 
                pointer.y >= y && pointer.y <= y + containerHeight) {
                scrollY += deltaY * 0.1; // 滚动速度
                scrollY = Phaser.Math.Clamp(scrollY, 0, maxScroll);
                scrollContentContainer.y = y - scrollY;
            }
        });
        return {
            x:x,
            y:y,
            width:containerWidth,
            height:containerHeight
        }
    }
    //清空场景
    clearScene() {
        const scene = this.scene;
        // 移除并销毁所有子对象（包括矩形、容器、图形等）
        scene.children.removeAll(true);
        // 移除所有输入事件监听器
        scene.input.removeAllListeners();
    }
    //绘制场景
    drawScene() {
        let rect:Rect = this.drawHeader();
        rect = this.drawCharacterSBox(rect);
        rect = this.drawPanelBox(rect);
        //rect = this.drawCharacterBox(rect);
        rect = this.drawField(rect);
        this.drawRight(rect);
    }
}