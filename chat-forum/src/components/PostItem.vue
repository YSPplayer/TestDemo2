<template>
  <base-card class="post-item">
    <div class="flex gap-md">
      <div class="flex flex-start fixed-64">
        <base-avatar size="48" fallback="U" />
      </div>
      <div class="flex-1">
        <router-link :to="{ name: 'PostDetail', params: { id: 1 } }" class="no-decoration">
          <h3 class="title-reset mt-sm">示例帖子标题 — 这是一个演示标题</h3>
        </router-link>
        <div class="text-muted small">作者 • 主题 • 2026-02-01</div>
        <p class="mt-sm">帖子内容摘要：这是一个用于展示布局的简短描述。这里不会有真实数据，仅用于 UI 预览。</p>
      </div>
      <div class="text-right w-100px no-shrink">
        <div class="small text-muted">回复 12</div>
      </div>
    </div>
  </base-card>
</template>

<script>
import BaseCard from './ui/BaseCard.vue'
import BaseAvatar from './ui/BaseAvatar.vue'

export default {
  name: 'PostItem',
  components: { BaseCard, BaseAvatar }
}
</script>

<style scoped>
.post-item{margin-top:12px}
</style>
