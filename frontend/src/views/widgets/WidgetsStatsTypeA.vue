<template>
  <CRow>
    <CCol :xs="3">
      <CWidgetStatsA class="mb-2" color="info-gradient">
        <template #value>{{ stats.totalJobs }}</template>
        <template #title><div class="mb-4">Vagas</div></template>
      </CWidgetStatsA>
    </CCol>
    <CCol :xs="3">
      <CWidgetStatsA class="mb-2" color="danger-gradient">
        <template #value>{{ stats.totalJobApplicants }} </template>
        <template #title><div class="mb-4">Vagas Respondidas</div></template>
      </CWidgetStatsA>
    </CCol>
    <CCol :xs="3" v-if="tipo == 1">
      <CWidgetStatsA class="mb-2" color="warning-gradient">
        <template #value>{{ stats.totalJobCriterias }}</template>
        <template #title><div class="mb-4">Critérios de Vaga</div></template>
      </CWidgetStatsA>
    </CCol>
    <CCol :xs="3" v-if="tipo == 1">
      <CWidgetStatsA class="mb-2" color="primary-gradient">
        <template #value>{{ stats.totalRegisteredUsers }}</template>
        <template #title><div class="mb-4">Usuários</div></template>
      </CWidgetStatsA>
    </CCol>
    <CCol :xs="6" v-if="tipo == 4">
      <CCard class="mb-4">
        <CCardHeader>
          <strong>Vagas Publicadas</strong>
        </CCardHeader>
        <CCardBody>
          <CTable striped>
            <CTableHead>
              <CTableRow>
                <CTableHeaderCell scope="col">Cargo ou Função</CTableHeaderCell>
                <CTableHeaderCell scope="col"
                  >Data de Expiração</CTableHeaderCell
                >
              </CTableRow>
            </CTableHead>
            <CTableBody>
              <CTableRow v-bind:key="index" v-for="(criterio, index) in items">
                <CTableHeaderCell scope="row">{{
                  criterio.cargo
                }}</CTableHeaderCell>
                <CTableDataCell>{{ criterio.dataExpiracao }}</CTableDataCell>
              </CTableRow>
            </CTableBody>
          </CTable>
        </CCardBody>
      </CCard>
    </CCol>
    <CCol :xs="6" v-if="tipo == 3">
      <CCard class="mb-4">
        <CCardHeader>
          <strong>Vagas Respondidas</strong>
        </CCardHeader>
        <CCardBody>
          <CTable striped>
            <CTableHead>
              <CTableRow>
                <CTableHeaderCell scope="col">Cargo ou Função</CTableHeaderCell>
                <CTableHeaderCell scope="col"
                  >Data de Expiração</CTableHeaderCell
                >
              </CTableRow>
            </CTableHead>
            <CTableBody>
              <CTableRow v-bind:key="index" v-for="(criterio, index) in items">
                <CTableHeaderCell scope="row">{{
                  criterio.cargo
                }}</CTableHeaderCell>
                <CTableDataCell>{{ criterio.dataExpiracao }}</CTableDataCell>
              </CTableRow>
            </CTableBody>
          </CTable>
        </CCardBody>
      </CCard>
    </CCol>
  </CRow>
</template>

<script>
/* eslint-disable */
import { useJobStore, useStatsStore } from '@/stores'
// eslint-disable-next-line
import { toRaw } from 'vue'

export default {
  name: 'WidgetsStatsA',
  components: {},
  props: {
    tipo: Number,
    id: Number,
    jobs: Object,
  },
  data: () => {
    return {
      items: [],
      stats: '',
    }
  },
  async mounted() {
    const jobStore = useJobStore()
    await jobStore.getAll()

    if (this.tipo == 4) {
      this.items = toRaw(jobStore.jobs).filter(
        (value) => value.empresaId == this.id,
      )
    } else if (this.tipo == 3) {
      this.items = toRaw(jobStore.jobs).filter((value) =>
        value.respostas.some((sub) => sub.candidatoId === this.id),
      )
    }

    //
    console.log(this.items)
    const statsStore = useStatsStore()
    await statsStore.getAll()
    this.stats = statsStore.stats
  },
}
</script>
