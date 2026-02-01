<template>
  <el-header class="app-header">
    <div class="inner-header">
      <div class="left-group">
        <base-avatar size="40" fallback="CF" class="rounded-sm" />
        <router-link to="/" class="no-decoration"><h3 class="title-reset">ChatForum</h3></router-link>
      </div>
      <div class="right-group">
        <base-input placeholder="搜索帖子或话题" class="w-260"></base-input>
        <base-button type="primary" @click="$router.push('/post/new')">发帖</base-button>
        <base-button plain @click="$router.push('/login')">登录</base-button>
      </div>
    </div>
  </el-header>
</template>

<script>
import BaseButton from './ui/BaseButton.vue'
import BaseInput from './ui/BaseInput.vue'
import BaseAvatar from './ui/BaseAvatar.vue'

export default {
  name: 'HeaderNav',
  components: { BaseButton, BaseInput, BaseAvatar }
}
</script>

<style scoped>
h3{font-weight:600}
</style>
