<template>
  <CRow>
    <CCol :xs="3">
      <CWidgetStatsA class="mb-2" color="primary-gradient">
        <template #value>{{ stats.totalRegisteredUsers }}</template>
        <template #title><div class="mb-4">Usuários</div></template>
      </CWidgetStatsA>
    </CCol>
    <CCol :xs="3">
      <CWidgetStatsA class="mb-2" color="info-gradient">
        <template #value>{{ stats.totalJobs }}</template>
        <template #title><div class="mb-4">Vagas</div></template>
      </CWidgetStatsA>
    </CCol>
    <CCol :xs="3">
      <CWidgetStatsA class="mb-2" color="warning-gradient">
        <template #value>{{ stats.totalJobCriterias }}</template>
        <template #title><div class="mb-4">Critérios de Vaga</div></template>
      </CWidgetStatsA>
    </CCol>
    <CCol :xs="3">
      <CWidgetStatsA class="mb-2" color="danger-gradient">
        <template #value>{{ stats.totalJobApplicants }} </template>
        <template #title><div class="mb-4">Vagas Respondidas</div></template>
      </CWidgetStatsA>
    </CCol>
  </CRow>
</template>

<script>
import { useStatsStore } from '@/stores'

export default {
  name: 'WidgetsStatsA',
  components: {},
  data: () => {
    return {
      stats: '',
    }
  },
  async mounted() {
    const statsStore = useStatsStore()
    await statsStore.getAll()
    this.stats = statsStore.stats
  },
}
</script>
