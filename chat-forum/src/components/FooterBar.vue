<template>
  <el-footer class="app-footer">
    <base-card class="inline-block p-8-12">
      <div class="text-muted">© 2026 ChatForum — 前端演示 (黑白主题)</div>
    </base-card>
  </el-footer>
</template>

<script>
import BaseCard from './ui/BaseCard.vue'

export default {
  name: 'FooterBar',
  components: { BaseCard }
}
</script>

<style scoped>
.app-footer{background:#ffffff}
</style>
