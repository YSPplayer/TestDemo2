<template>
  <div class="chat-detail">
    <h1>聊天详情</h1>
    <UserList />
    <TopicList />
    <MessageList />
    <MessageInput />
  </div>
</template>

<script>
import UserList from '../components/UserList.vue';
import TopicList from '../components/TopicList.vue';
import MessageList from '../components/MessageList.vue';
import MessageInput from '../components/MessageInput.vue';

export default {
  components: {
    UserList,
    TopicList,
    MessageList,
    MessageInput
  }
}
</script>

<style scoped>
.chat-detail {
  padding: 20px;
}
</style>