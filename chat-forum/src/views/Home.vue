<template>
  <div class="home">
    <h1>欢迎来到聊天论坛</h1>
    <p>在这里你可以与其他用户交流和讨论各种话题。</p>
    <router-link to="/forum">进入论坛</router-link>
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped>
.home {
  text-align: center;
  margin-top: 50px;
}
</style>