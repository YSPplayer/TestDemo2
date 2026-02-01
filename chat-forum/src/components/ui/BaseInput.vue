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
.base-input ::v-deep .el-input__inner{border-radius:12px;font-size:var(--fs-md);padding:10px 14px;height:40px}
.base-input ::v-deep .el-textarea__inner{border-radius:12px;font-size:var(--fs-md);padding:10px 14px}
</style>
