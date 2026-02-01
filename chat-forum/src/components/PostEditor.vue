<template>
  <div>
    <base-input type="textarea" rows="4" placeholder="写下你的回复..." />
    <div class="flex flex-between mt-sm justify-end">
      <div></div>
      <div class="flex gap-sm">
        <base-button>取消</base-button>
        <base-button type="primary">提交</base-button>
      </div>
    </div>
  </div>
</template>

<script>
import BaseInput from './ui/BaseInput.vue'
import BaseButton from './ui/BaseButton.vue'

export default {
  name: 'PostEditor',
  components: { BaseInput, BaseButton }
}
</script>

<style scoped>
</style>
