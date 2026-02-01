<template>
  <div class="user-list">
    <h2>在线用户</h2>
    <ul>
      <li v-for="user in users" :key="user.id">{{ user.name }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'UserList',
  data() {
    return {
      users: []
    };
  },
  mounted() {
    // 这里可以添加获取用户列表的逻辑
    this.fetchUsers();
  },
  methods: {
    fetchUsers() {
      // 模拟获取用户数据
      this.users = [
        { id: 1, name: '用户1' },
        { id: 2, name: '用户2' },
        { id: 3, name: '用户3' }
      ];
    }
  }
};
</script>

<style scoped>
.user-list {
  border: 1px solid #ccc;
  padding: 10px;
  border-radius: 5px;
  background-color: #f9f9f9;
}
.user-list h2 {
  margin: 0 0 10px;
}
.user-list ul {
  list-style-type: none;
  padding: 0;
}
.user-list li {
  padding: 5px 0;
}
</style>