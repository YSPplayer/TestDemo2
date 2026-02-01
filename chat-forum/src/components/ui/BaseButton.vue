<template>
  <el-button
    :type="type"
    :size="size"
    :plain="plain"
    class="base-button"
    @click="$emit('click', $event)">
    <slot />
  </el-button>
</template>

<script>
export default {
  name: 'BaseButton',
  props: {
    type: { type: String, default: 'primary' },
    size: { type: String, default: 'small' },
    plain: { type: Boolean, default: false }
  }
}
</script>

<style scoped>
.base-button{border-radius:6px;font-size:var(--fs-sm);padding:6px 12px}
</style>
