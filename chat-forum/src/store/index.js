import { createStore } from 'vuex';

const store = createStore({
  state: {
    messages: [],
    users: [],
    topics: []
  },
  mutations: {
    addMessage(state, message) {
      state.messages.push(message);
    },
    setUsers(state, users) {
      state.users = users;
    },
    setTopics(state, topics) {
      state.topics = topics;
    }
  },
  actions: {
    sendMessage({ commit }, message) {
      commit('addMessage', message);
    },
    updateUsers({ commit }, users) {
      commit('setUsers', users);
    },
    updateTopics({ commit }, topics) {
      commit('setTopics', topics);
    }
  },
  getters: {
    allMessages: (state) => state.messages,
    onlineUsers: (state) => state.users,
    availableTopics: (state) => state.topics
  }
});

export default store;