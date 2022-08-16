<script setup>
import { useAuthStore } from '@/stores'
const authStore = useAuthStore()
</script>

<template>
  <CDropdown variant="nav-item">
    <CDropdownToggle placement="bottom-end" class="py-0" :caret="false">
      <CIcon icon="cil-applications-settings" size="lg" />
    </CDropdownToggle>
    <CDropdownMenu class="pt-0">
      <CDropdownHeader component="h6" class="bg-light fw-semibold py-2">
        Conta
      </CDropdownHeader>
      <a @click="authStore.logout()"
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
