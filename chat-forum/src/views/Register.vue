<template>
  <div class="centered-container mt-xl">
    <base-card>
      <h2 class="mt-0">注册</h2>
      <el-form label-position="top">
        <el-form-item label="用户名">
          <base-input placeholder="用户名"></base-input>
        </el-form-item>
        <el-form-item label="邮箱">
          <base-input placeholder="邮箱"></base-input>
        </el-form-item>
        <el-form-item label="密码">
          <base-input type="password" placeholder="密码"></base-input>
        </el-form-item>
        <div class="flex justify-end">
          <base-button type="primary">注册</base-button>
        </div>
      </el-form>
    </base-card>
  </div>
</template>

<script>
import BaseCard from '../components/ui/BaseCard.vue'
import BaseInput from '../components/ui/BaseInput.vue'
import BaseButton from '../components/ui/BaseButton.vue'

export default { name: 'Register', components: { BaseCard, BaseInput, BaseButton } }
</script>

<style scoped>
</style>
