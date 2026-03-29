<template>
  <div class="app">
   <div id="game-container"></div>
  </div>
</template>

<script setup>
import Phaser from 'phaser';
import { onMounted } from 'vue';
// import Scene from '@/script/scene';
import Util from '@/script/util';
import XmlFormat from '@/script/Format/xmlFormat';
import UiFormat from '@/script/Format/uiFormat';
onMounted(async () => {
    const xml = await Util.LoadXml('scene.xml');
    const xmlFormat = new XmlFormat(xml);
    xmlFormat.parse();

    // 定义场景配置
    const sceneConfig = {
        create: function() {
            const uiFormat = new UiFormat(this, xmlFormat.node);
            uiFormat.format();
        }
    };

    // 创建游戏实例，场景会自动初始化
    const config = {
        type: Phaser.AUTO,
        width: '100%',
        height: '100%',
        parent: 'game-container',
        scene: sceneConfig,
        scale: {
            mode: Phaser.Scale.RESIZE,
            autoCenter: Phaser.Scale.CENTER_BOTH,
            width: '100%',
            height: '100%'
        }
    };

    new Phaser.Game(config);
});
</script>


<style scoped>

#game-container {
  width: 100vw;
  height: 100vh;
  overflow: hidden;
  margin: 0;
  padding: 0;
}

</style>

