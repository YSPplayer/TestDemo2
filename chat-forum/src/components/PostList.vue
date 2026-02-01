<template>
  <div class="list-gap">
    <post-item v-for="i in 6" :key="i" />
  </div>
</template>

<script>
import PostItem from './PostItem.vue'

export default {
  name: 'PostList',
  components: { PostItem }
}
</script>

<style scoped>
.list-gap > * + * { margin-top: 12px }
</style>
