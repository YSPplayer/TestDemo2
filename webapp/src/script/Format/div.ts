import Phaser from 'phaser';
import Util from '@/script/util';
import { Rect } from '@/script/geometry';
import { XmlNode,filterKeys } from './xmldata';
export default class Div {
    scene: Phaser.Scene;
    container: any;
    obj:any;
    x:number;
    y:number;
    width:number;
    height:number;
    backgroundColor:string;
    constructor(scene:Phaser.Scene) {
        this.scene = scene;
        this.x = 0;
        this.y = 0;
        this.width = 0;
        this.height = 0;
        this.backgroundColor = '#bda1a1ff';
    }
    setRect(rect:Rect) {
        this.x = rect.x;
        this.y = rect.y;
        this.width = rect.width;
        this.height = rect.height;
    }
    static createFromNode(scene:Phaser.Scene,node:XmlNode) {
        const div = new Div(scene);
        const data = node.data;
        div.setRect({
            x:data?.x || 0,
            y:data?.y || 0,
            width:data?.width || 0,
            height:data?.height || 0
        });
        return div;
    }
    build() {
        const scene = this.scene;
        this.container = scene.add.container(this.x, this.y);
        const color = Util.ToColor(this.backgroundColor);
        this.obj = scene.add.rectangle(0, 0, this.width, this.height, color);
        this.container.add(this.obj);
        return this.container;
    }

}