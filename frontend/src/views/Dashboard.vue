<script setup>
import { storeToRefs } from 'pinia'

import { useAuthStore } from '@/stores'

const authStore = useAuthStore()
const { user: authUser } = storeToRefs(authStore)
</script>
<template>Bem-vindo! {{ authUser?.email }}</template>

<script>
export default {
  name: 'Dashboard',
}
</script>
