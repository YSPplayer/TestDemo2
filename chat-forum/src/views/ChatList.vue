<template>
  <div>
    <el-row gutter="16">
      <el-col :span="8">
        <base-card class="card">
            <h3 class="mt-0">聊天室</h3>
          <div class="flex-col gap-sm">
            <base-button type="text">通用聊天室</base-button>
            <base-button type="text">前端讨论组</base-button>
            <base-button type="text">随机闲聊</base-button>
          </div>
        </base-card>
      </el-col>
      <el-col :span="16">
        <base-card class="card">
            <h3 class="mt-0">选中房间预览</h3>
          <p>聊天内容占位，消息输入框位于底部。</p>
        </base-card>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import BaseCard from '../components/ui/BaseCard.vue'
import BaseButton from '../components/ui/BaseButton.vue'

export default { name: 'ChatList', components: { BaseCard, BaseButton } }
</script>

<style scoped>
</style>
