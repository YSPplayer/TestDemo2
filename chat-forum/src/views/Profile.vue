<template>
  <div class="mx-auto-sm mt-md">
    <base-card class="card">
      <div class="flex gap-md items-center">
        <base-avatar size="large" fallback="U" />
        <div>
          <div class="font-strong">用户名</div>
          <div class="text-muted">个人简介示例</div>
        </div>
      </div>
    </base-card>
    <base-card class="card card--mt">
      <h3 class="mt-0">用户发布的帖子</h3>
      <post-list />
    </base-card>
  </div>
</template>

<script>
import PostList from '../components/PostList.vue'
import BaseCard from '../components/ui/BaseCard.vue'
import BaseAvatar from '../components/ui/BaseAvatar.vue'

export default {
  name: 'Profile',
  components: { PostList, BaseCard, BaseAvatar }
}
</script>

<style scoped>
</style>
