<template>
  <el-card :shadow="shadow" class="base-card">
    <slot />
  </el-card>
</template>

<script>
export default {
  name: 'BaseCard',
  props: { shadow: { type: String, default: 'never' } }
}
</script>

<style scoped>
.base-card{padding:var(--space-md);border-radius:var(--radius);font-size:var(--fs-md)}
</style>
