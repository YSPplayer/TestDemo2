<template>
  <div class="forum">
    <h1>论坛</h1>
    <topic-list />
    <user-list />
    <chat-room />
  </div>
</template>

<script>
import TopicList from '../components/TopicList.vue';
import UserList from '../components/UserList.vue';
import ChatRoom from '../components/ChatRoom.vue';

export default {
  components: {
    TopicList,
    UserList,
    ChatRoom
  }
}
</script>

<style scoped>
.forum {
  padding: 20px;
}
</style>