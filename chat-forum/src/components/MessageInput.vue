<template>
  <div class="message-input">
    <input
      type="text"
      v-model="message"
      @keyup.enter="sendMessage"
      placeholder="输入消息..."
    />
    <button @click="sendMessage">发送</button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      message: ''
    };
  },
  methods: {
    sendMessage() {
      if (this.message.trim()) {
        this.$emit('send', this.message);
        this.message = '';
      }
    }
  }
};
</script>

<style scoped>
.message-input {
  display: flex;
  align-items: center;
  margin-top: 10px;
}

.message-input input {
  flex: 1;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.message-input button {
  margin-left: 10px;
  padding: 10px 15px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.message-input button:hover {
  background-color: #0056b3;
}
</style>