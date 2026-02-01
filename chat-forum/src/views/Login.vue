<template>
  <div class="centered-container mt-xl">
    <base-card>
      <h2 class="mt-0">登录</h2>
      <el-form label-position="top">
        <el-form-item label="邮箱">
          <base-input placeholder="请输入邮箱"></base-input>
        </el-form-item>
        <el-form-item label="密码">
          <base-input type="password" placeholder="请输入密码"></base-input>
        </el-form-item>
        <div class="flex flex-between">
          <base-button plain @click="$router.push('/register')">注册</base-button>
          <base-button type="primary">登录</base-button>
        </div>
      </el-form>
    </base-card>
  </div>
</template>

<script>
import BaseCard from '../components/ui/BaseCard.vue'
import BaseInput from '../components/ui/BaseInput.vue'
import BaseButton from '../components/ui/BaseButton.vue'

export default { name: 'Login', components: { BaseCard, BaseInput, BaseButton } }
</script>

<style scoped>
</style>
