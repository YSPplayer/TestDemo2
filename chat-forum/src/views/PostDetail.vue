<template>
  <div>
      <base-card>
        <div class="flex flex-between">
          <div>
            <h2 class="title-reset">示例帖子标题</h2>
            <div class="text-muted small">作者 • 2026-02-01</div>
          </div>
          <div>
            <base-button size="small">收藏</base-button>
          </div>
        </div>
        <div class="mt-md">
          <p>这是帖子正文的占位符。实际内容将支持 Markdown 或 富文本，当前仅用于展示 UI。</p>
        </div>
      </base-card>

      <base-card class="card--mt">
        <h3 class="mt-0">回复</h3>
        <div class="list-gap">
          <base-card shadow="never">
            <div class="font-strong">用户A</div>
            <div class="mt-sm">这是一个回复示例。</div>
          </base-card>
          <base-card shadow="never">
            <div class="font-strong">用户B</div>
            <div class="mt-sm">另一个回复示例。</div>
          </base-card>
        </div>
        <div class="mt-md">
          <post-editor />
        </div>
      </base-card>
  </div>
</template>

<script>
import PostEditor from '../components/PostEditor.vue'
import BaseCard from '../components/ui/BaseCard.vue'
import BaseButton from '../components/ui/BaseButton.vue'

export default {
  name: 'PostDetail',
  components: { PostEditor, BaseCard, BaseButton }
}
</script>

<style scoped>
.card{margin-bottom:12px}
</style>
