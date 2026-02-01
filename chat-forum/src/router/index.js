import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import Forum from '../views/Forum.vue';
import ChatDetail from '../views/ChatDetail.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/forum',
    name: 'Forum',
    component: Forum
  },
  {
    path: '/chat/:id',
    name: 'ChatDetail',
    component: ChatDetail,
    props: true
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

export default router;