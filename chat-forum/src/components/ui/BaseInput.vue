<template>
  <el-input v-bind="$attrs" v-on="$listeners" class="base-input">
    <slot />
  </el-input>
</template>

<script>
export default {
  name: 'BaseInput'
}
</script>

<style scoped>
.base-input ::v-deep .el-input__inner{border-radius:6px;font-size:var(--fs-md);padding:10px}
</style>
