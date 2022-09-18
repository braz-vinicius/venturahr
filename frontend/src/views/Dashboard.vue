<script setup>
import { storeToRefs } from 'pinia'

import { useAuthStore } from '@/stores'

const authStore = useAuthStore()
const { user: authUser } = storeToRefs(authStore)
</script>
<template>
  <div>
    <CAlert color="success" class="d-flex align-items-center">
      <CIcon
        icon="cil-check-circle"
        class="flex-shrink-0 me-2"
        width="24"
        height="24"
      />
      <div>Bem-vindo! {{ authUser?.email }}</div>
    </CAlert>
    <WidgetsStatsA />
    <CRow>
      <CCol :xs="12">
        <CCard class="mb-4">
          <CCardHeader>
            <strong>Painel de Vagas</strong>
          </CCardHeader>
          <CCardBody>
            <CRow v-if="authUser?.tipo == 3">
              <CCol :xs="12">
                <RouterLink to="/vaga" class="nav-item nav-link">
                  <CButton
                    class="mb-3"
                    color="primary"
                    variant="outline"
                    square
                    size="sm"
                  >
                    Cadastrar Vaga
                  </CButton>
                </RouterLink>
              </CCol>
            </CRow>
            <JobTable />
          </CCardBody>
        </CCard>
      </CCol>
    </CRow>
  </div>
</template>

<script>
import WidgetsStatsA from './widgets/WidgetsStatsTypeA.vue'
import JobTable from '@/components/JobTable.vue'
export default {
  name: 'Dashboard',
  components: {
    WidgetsStatsA,
    JobTable,
  },
}
</script>
