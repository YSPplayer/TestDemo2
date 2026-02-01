<template>
  <el-avatar :size="size" :src="src">{{ fallback }}</el-avatar>
</template>

<script>
export default {
  name: 'BaseAvatar',
  props: { src: String, size: { type: [Number, String], default: 'medium' }, fallback: { type: String, default: '' } }
}
</script>

<style scoped>
</style>
