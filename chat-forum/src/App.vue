<template>
  <div id="app">
    <header-nav />
    <main class="container">
      <router-view />
    </main>
    <footer-bar />
  </div>
</template>

<script>
import HeaderNav from './components/HeaderNav.vue'
import FooterBar from './components/FooterBar.vue'

export default {
  name: 'App',
  components: { HeaderNav, FooterBar }
}
</script>

<style>
#app{min-height:100vh;display:flex;flex-direction:column}
main.container{flex:1}
</style>