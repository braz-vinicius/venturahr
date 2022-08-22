<script setup>
import { useAuthStore } from '@/stores'
const authStore = useAuthStore()

const styleVars = {
  'box-shadow': '0px 0px 0px 0px',
}
</script>

<template>
  <CDropdown style="styleVars">
    <CDropdownToggle
      placement="bottom-end"
      class="py-0"
      :style="styleVars"
      :caret="false"
    >
      <CIcon icon="cil-applications-settings" size="lg" />
    </CDropdownToggle>
    <CDropdownMenu class="pt-0">
      <CDropdownHeader component="h6" class="bg-light fw-semibold py-2">
        Conta
      </CDropdownHeader>
      <CDropdownItem>
        <RouterLink to="/profile" class="nav-item nav-link">
          <CIcon icon="cil-user" /> Perfil
        </RouterLink></CDropdownItem
      >
      <a @click="authStore.logout()" class="nav-item nav-link"
        ><CDropdownItem>
          <CIcon icon="cil-lock-locked" /> Sair
        </CDropdownItem></a
      >
    </CDropdownMenu>
  </CDropdown>
</template>

<script>
export default {
  name: 'AppHeaderDropdownAccnt',
  setup() {
    return {
      itemsCount: 42,
    }
  },
}
</script>
