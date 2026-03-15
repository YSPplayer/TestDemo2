<template>
  <div class="app">
    <header>
      <h1>🎴 集换式卡牌游戏</h1>
      <p>欢迎来到卡牌游戏世界</p>
    </header>
    <main>
      <HelloWorld msg="Vue 3 + Vite" />
    </main>
  </div>
</template>

<script setup>
import HelloWorld from './components/HelloWorld.vue'
</script>

<style scoped>
.app {
  text-align: center;
  padding: 20px;
}

header {
  margin-bottom: 2rem;
}

h1 {
  color: #333;
  font-size: 2.5rem;
  margin: 0;
}

p {
  color: #666;
  margin: 0.5rem 0 0 0;
}

main {
  min-height: 400px;
}
</style>
