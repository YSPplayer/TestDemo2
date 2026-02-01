<template>
  <div class="container">
    <el-container>
      <el-row>
        <el-col :span="18" class="left-col">
          <div class="card">
              <div class="flex flex-between">
                <h2 class="title-reset">论坛</h2>
                <base-button type="primary">发新帖</base-button>
              </div>
            <post-list class="list-gap" />
          </div>
        </el-col>
        <el-col :span="6" class="right-col">
          <div class="card">
            <h3 class="mt-0">话题</h3>
            <topic-list />
          </div>
          <div class="card card--mt">
            <h3 class="mt-0">在线用户</h3>
            <user-list />
          </div>
        </el-col>
      </el-row>
    </el-container>
  </div>
</template>

<script>
import TopicList from '../components/TopicList.vue';
import UserList from '../components/UserList.vue';
import PostList from '../components/PostList.vue';
import BaseButton from '../components/ui/BaseButton.vue';

export default {
  components: {
    TopicList,
    UserList,
    PostList,
    BaseButton
  }
}
</script>

<style scoped>
.container{padding:12px}
.left-col{padding-right:12px}
.right-col{padding-left:12px}
</style>