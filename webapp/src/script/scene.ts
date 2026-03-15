import Phaser from 'phaser';
import DrawManager  from './draw';
export default class Scene extends Phaser.Scene {
    drawManager: DrawManager;
    constructor() {
        super({ key: 'Scene' });
        this.drawManager = new DrawManager(this);
    }
   
    preload() {
        // 资源加载
    }

    create() {
        this.drawManager.drawScene();
    }

    update() {
        // 游戏循环
         //this.drawCharacterSBox();
    }
}