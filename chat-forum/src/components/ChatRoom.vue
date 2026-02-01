<template>
  <div class="chat-room">
    <h2>聊天房间</h2>
    <UserList />
    <MessageList />
    <MessageInput />
  </div>
</template>

<script>
import UserList from './UserList.vue';
import MessageList from './MessageList.vue';
import MessageInput from './MessageInput.vue';

export default {
  components: {
    UserList,
    MessageList,
    MessageInput
  }
}
</script>

<style scoped>
.chat-room {
  display: flex;
  flex-direction: column;
  height: 100%;
}
</style>