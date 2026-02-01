<template>
  <div class="message-list">
    <h2>聊天记录</h2>
    <ul>
      <li v-for="message in messages" :key="message.id">
        <strong>{{ message.user }}:</strong> {{ message.text }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'MessageList',
  props: {
    messages: {
      type: Array,
      required: true
    }
  }
}
</script>

<style scoped>
.message-list {
  border: 1px solid #ccc;
  padding: 10px;
  max-height: 400px;
  overflow-y: auto;
}
</style>