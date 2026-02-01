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
.base-button{border-radius:var(--btn-radius);font-size:var(--fs-md);padding:var(--btn-padding-regular);box-shadow:var(--btn-shadow);transition:all .18s ease;display:inline-flex;align-items:center;justify-content:center;min-width:var(--btn-min-width);font-weight:600;line-height:1.2;height:40px}
.base-button:hover{cursor:pointer;transform:translateY(-1px)}

/* focus/active accessibility */
.base-button:focus{outline:none;box-shadow:0 0 0 6px rgba(17,17,17,0.06)}

/* size adjustments rely on Element Plus size classes */
.base-button.el-button--small{padding:var(--btn-padding-small);min-width:120px;font-size:var(--fs-sm);height:36px}
.base-button.el-button--medium{padding:var(--btn-padding-regular);height:40px}
.base-button.el-button--large{padding:var(--btn-padding-large);font-size:var(--fs-lg);min-width:200px;height:48px}
</style>
