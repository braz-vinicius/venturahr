<template>
  <CSidebar
    position="fixed"
    :unfoldable="sidebarUnfoldable"
    :visible="sidebarVisible"
    @visible-change="
      (event) =>
        $store.commit({
          type: 'updateSidebarVisible',
          value: event,
        })
    "
  >
    <CSidebarBrand>
      <a :href="urlBase">
        <CIcon
          custom-class-name="sidebar-brand-full"
          :icon="logoNegative"
          :height="35"
      /></a>
    </CSidebarBrand>
    <AppSidebarNav />
  </CSidebar>
</template>

<script>
import { computed } from 'vue'
import { useStore } from 'vuex'
import { AppSidebarNav } from './AppSidebarNav'
import { logoNegative } from '@/assets/brand/logo-negative'
export default {
  name: 'AppSidebar',
  data: () => {
    return {
      urlBase: window.location.origin,
    }
  },
  components: {
    AppSidebarNav,
  },

  setup() {
    const store = useStore()
    return {
      logoNegative,
      sidebarUnfoldable: computed(() => store.state.sidebarUnfoldable),
      sidebarVisible: computed(() => store.state.sidebarVisible),
    }
  },
}
</script>
