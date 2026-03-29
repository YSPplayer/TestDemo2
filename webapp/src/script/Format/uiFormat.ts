import Phaser from 'phaser';
import Div from './div';
import { XmlNode,filterKeys } from './xmldata';
export default class UiFormat {
    scene: Phaser.Scene;
    node:XmlNode;
    constructor(scene:Phaser.Scene,node:XmlNode) {
        this.scene = scene;
        this.node = node;
    }
    formatNode(currentNode:XmlNode) {
        if(!currentNode) return;
        const div = Div.createFromNode(this.scene,currentNode);
        const container = div.build();
        for(const child of currentNode.children) {
            const childContainer = this.formatNode(child);
            container.add(childContainer);
        }
        return container;
    }
    format() {
        if(!this.node) return;
        this.formatNode(this.node);
    }
}