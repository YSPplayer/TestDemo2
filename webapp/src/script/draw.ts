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
        graphics.lineStyle(height, Util.ToColor(color)); 
        graphics.moveTo(x1, y1);  // 起点
        graphics.lineTo(x2, y2);  // 终点
        graphics.strokePath();    // 绘制
    }
    //场地中每一行的组件
    drawFieldLine(rect:Rect) {
        const scene = this.scene;
        const fieldLineBox = scene.add.rectangle(rect.x, rect.y, rect.width, rect.height,
                 Util.ToColor('#8acfe6'));
        fieldLineBox.setOrigin(0, 0);
    }
    drawField(rect:Rect)  {
         const scene = this.scene;
        const width = scene.scale.width;
        const height = scene.scale.height;
        const fieldWidth = width * 0.65;
        const fieldHeight = height;
        const margin = width * 0.01;
        const x =  rect.x + rect.width + margin;
        const y = 0;
        const fieldWidthBox = scene.add.rectangle(x, y, fieldWidth, fieldHeight,
              Util.ToColor('#e85939'));
         fieldWidthBox.setOrigin(0, 0);
         const midlineheight = 2;
         const lineHeight = fieldHeight / 6 - 5 * midlineheight;
         const lineWidth = fieldWidth;
         for(let i = 0; i < 6; i++) {
            const lineX = x;
            const lineY = y + i * lineHeight + i * midlineheight;
            this.drawFieldLine({ x: lineX, y: lineY, width: lineWidth, height: lineHeight });
            this.drawLine(midlineheight, lineX, lineY + lineHeight, lineX + lineWidth, lineY + lineHeight, '#ffffff');
        }
    }
     //单人物框
    drawCharacterBox(rect:Rect) {
        const scene = this.scene;
        const width = scene.scale.width;
        const height = scene.scale.height;
         const characterWidth = width * 0.1;
         const margin = width * 0.01;
         const characterHeight = characterWidth;
         const x = rect.x + rect.width + margin;
         const y = margin;
         const characterBox = scene.add.rectangle(x, y, characterWidth, characterHeight,
              Util.ToColor('#c2d370'));
         characterBox.setOrigin(0, 0);
         const endx = x;
         const endy = height - y * 2 - characterHeight;
         const endcharacterBox = scene.add.rectangle(endx, endy, characterWidth, characterHeight,
              Util.ToColor('#c2d370'));
         endcharacterBox.setOrigin(0, 0);
         return {
            x: x,
            y: y,
            width: characterWidth,
            height: characterHeight
         }
        }
    //左侧多人物框
    drawCharacterSBox() {
        const scene = this.scene;
        const width = scene.scale.width;
        const height = scene.scale.height;
        const containerWidth = width * 0.1;
        const containerHeight = height;
        
        // 外框容器（可视区域）
        const container = scene.add.rectangle(0, 0, containerWidth, containerHeight,
             Util.ToColor('#477496'));
        container.setOrigin(0, 0);
        container.setStrokeStyle(2, Util.ToColor('#e2e4bc'));
        
        // 创建可滚动的内容容器
        const scrollContentContainer = scene.add.container(0, 0);
        
        const characterWidth = container.width * 0.8;
        const characterHeight = characterWidth;
        const margin = (container.width - characterWidth) / 2;
        
        // 将所有矩形添加到内容容器中
        for(let i = 0; i < 6; i++) {
            const x = margin;
            const y = margin + i * (characterHeight + margin);
            const characterBox = scene.add.rectangle(x, y, characterWidth, characterHeight,
                 Util.ToColor('#72ca4d'));
            characterBox.setOrigin(0, 0);
            scrollContentContainer.add(characterBox);
        }
        
        // 创建遮罩，限制可视区域为 container 的大小
        const maskGraphics = scene.make.graphics();
        maskGraphics.fillStyle(0xffffff);
        maskGraphics.fillRect(0, 0, containerWidth, containerHeight);
        const mask = new Phaser.Display.Masks.GeometryMask(scene, maskGraphics);
        scrollContentContainer.setMask(mask);
        
        // 计算总内容高度和最大滚动距离
        const totalContentHeight = margin + 6 * (characterHeight + margin);
        let scrollY = 0;
        const maxScroll = Math.max(0, totalContentHeight - containerHeight);
        
        // 添加鼠标滚轮事件
        scene.input.on('wheel', (pointer: Phaser.Input.Pointer, gameObjects: any[], deltaX: number, deltaY: number) => {
            // 检查鼠标是否在滚动区域内
            if (pointer.x >= 0 && pointer.x <= containerWidth && 
                pointer.y >= 0 && pointer.y <= containerHeight) {
                scrollY += deltaY * 0.1; // 滚动速度
                scrollY = Phaser.Math.Clamp(scrollY, 0, maxScroll);
                scrollContentContainer.y = -scrollY;
            }
        });
        return {
            x:0,
            y:0,
            width:containerWidth,
            height:containerHeight
        }
    }
    //绘制场景
    drawScene() {
        let rect:Rect = this.drawCharacterSBox();
        rect = this.drawCharacterBox(rect);
        this.drawField(rect);
    }
}