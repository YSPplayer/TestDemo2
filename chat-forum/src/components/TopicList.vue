<template>
  <div class="topic-list">
    <h2>话题列表</h2>
    <ul>
      <li v-for="topic in topics" :key="topic.id">
        {{ topic.name }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'TopicList',
  data() {
    return {
      topics: [
        { id: 1, name: 'Vue.js' },
        { id: 2, name: 'JavaScript' },
        { id: 3, name: '前端开发' },
        { id: 4, name: '后端开发' },
        { id: 5, name: '全栈开发' }
      ]
    };
  }
};
</script>

<style scoped>
.topic-list {
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #f9f9f9;
}

.topic-list h2 {
  margin-bottom: 10px;
}

.topic-list ul {
  list-style-type: none;
  padding: 0;
}

.topic-list li {
  padding: 5px 0;
  cursor: pointer;
}

.topic-list li:hover {
  text-decoration: underline;
}
</style>