import Phaser from 'phaser';
import Util from './util';
export default class Scene extends Phaser.Scene {
    constructor() {
        super({ key: 'Scene' });
    }
    //左侧多人物框
    drawCharacterSBox() {
        const width = this.scale.width;
        const height = this.scale.height;
        const container = this.add.rectangle(0, 0, width * 0.1, height,
             Util.ToColor('#477496'));
        container.setOrigin(0, 0);
        container.setStrokeStyle(2,  Util.ToColor('#e2e4bc'));
        const characterWidth = container.width * 0.8;
        const characterHeight = characterWidth;
        const margin = (container.width - characterWidth) / 2;
        for(let i = 0; i < 6; i++) {
            const x = container.x + margin;
            const y = container.y + margin + i * (characterHeight + margin);
            const characterBox = this.add.rectangle(x, y, characterWidth, characterHeight,
                 Util.ToColor('#72ca4d'));
            characterBox.setOrigin(0, 0);
        }
    }
    preload() {
        // 资源加载
    }

    create() {
        this.drawCharacterSBox();
    }

    update() {
        // 游戏循环
         //this.drawCharacterSBox();
    }
}