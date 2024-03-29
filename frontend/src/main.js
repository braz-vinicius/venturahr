import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'
import store from './store'

import CoreuiVue from '@coreui/vue-pro'
import { CIcon } from '@coreui/icons-vue'
import { iconsSet as icons } from '@/assets/icons'

const pinia = createPinia()
const app = createApp(App)
app.use(pinia)
app.use(store)
app.use(router)
app.use(CoreuiVue)
app.provide('icons', icons)
app.component('CIcon', CIcon)

app.mount('#app')
