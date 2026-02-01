<template>
  <div class="base-layout">
    <div class="layout-inner">
      <slot />
    </div>
  </div>
</template>

<script>
export default { name: 'BaseLayout' }
</script>

<style scoped>
.base-layout{padding:var(--space-md)}
.layout-inner{max-width:1100px;margin:0 auto}
</style>
