<template>
  <div class="app">
   <div id="game-container"></div>
  </div>
</template>

<script setup>
import Phaser from 'phaser';
import { onMounted } from 'vue';
import Scene from '@/script/scene';
onMounted(() => {
  const config = {
    type: Phaser.AUTO,
    width: '100%',
    height: '100%',
    parent: 'game-container',
    scene: Scene,
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

