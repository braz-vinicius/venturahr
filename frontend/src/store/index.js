import { createStore } from 'vuex'

export default createStore({
  state: {
    sidebarVisible: '',
    sidebarUnfoldable: false,
    theme: 'default',
  },
  mutations: {
    toggleSidebar(state) {
      state.sidebarVisible = !state.sidebarVisible
    },
    toggleTheme(state, payload) {
      state.theme = payload.value
    },
    toggleUnfoldable(state) {
      state.sidebarUnfoldable = !state.sidebarUnfoldable
    },
    updateSidebarVisible(state, payload) {
      state.sidebarVisible = payload.value
    },
  },
  actions: {},
  modules: {},
})
