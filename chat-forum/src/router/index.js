import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import Forum from '../views/Forum.vue';
import ChatDetail from '../views/ChatDetail.vue';
import PostDetail from '../views/PostDetail.vue';
import Login from '../views/Login.vue';
import Register from '../views/Register.vue';
import Profile from '../views/Profile.vue';
import ChatList from '../views/ChatList.vue';

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
    path: '/forum/:id',
    name: 'PostDetail',
    component: PostDetail,
    props: true
  },
  {
    path: '/post/new',
    name: 'PostNew',
    component: () => import('../views/PostDetail.vue')
  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  {
    path: '/register',
    name: 'Register',
    component: Register
  },
  {
    path: '/profile/:id',
    name: 'Profile',
    component: Profile,
    props: true
  },
  {
    path: '/chat',
    name: 'ChatList',
    component: ChatList
  },
  {
    path: '/chat/:id',
    name: 'ChatDetail',
    component: ChatDetail,
    props: true
  }
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
});

export default router;