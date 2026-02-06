<template>
  <div class="hello">
    <h2>{{ msg }}</h2>
    <p class="read-the-docs">
      点击下方链接开始开发你的卡牌游戏
    </p>
    <div class="links">
      <a href="https://vuejs.org/" target="_blank">Vue 3 文档</a>
      <a href="https://vitejs.dev/" target="_blank">Vite 文档</a>
    </div>
  </div>
</template>

<script setup>
defineProps({
  msg: String
})
</script>

<style scoped>
.hello {
  padding: 2rem;
  border: 1px solid #e0e0e0;
  border-radius: 8px;
  background: #f9f9f9;
  margin: 2rem auto;
  max-width: 500px;
}

h2 {
  color: #333;
  margin: 0 0 1rem 0;
}

.read-the-docs {
  color: #666;
  margin: 1rem 0;
}

.links {
  display: flex;
  gap: 1rem;
  justify-content: center;
  margin-top: 1rem;
}

a {
  color: #0084ff;
  text-decoration: none;
  font-weight: 500;
  padding: 0.5rem 1rem;
  border: 1px solid #0084ff;
  border-radius: 4px;
  transition: all 0.3s;
}

a:hover {
  background-color: #0084ff;
  color: white;
}
</style>
