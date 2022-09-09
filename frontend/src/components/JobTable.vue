<script setup>
/* eslint-disable */
import { storeToRefs } from 'pinia'
import { useJobStore } from '@/stores'
import { toRaw, onMounted, onBeforeMount, computed } from 'vue'

const jobStore = useJobStore()

const fullUser = computed(async () => {
  await jobStore.getAll()

  return toRaw(jobStore.jobs)
})

onBeforeMount(async () => {
  await jobStore.getAll()
})
</script>
  
<template>
  <CSmartTable
    clickableRows
    :tableProps="{
      striped: true,
      hover: true,
    }"
    :tableHeadProps="{
      color: 'secondary',
    }"
    :activePage="1"
    header
    :items="items"
    :columns="columns"
    columnFilter
    itemsPerPageSelect
    :itemsPerPage="5"
    columnSorter
    :sorterValue="{ column: 'status', state: 'asc' }"
    pagination
  >
    <template #status="{ item }">
      <td>
        <CBadge :color="getBadge(item.status)">{{ item.status }}</CBadge>
      </td>
    </template>
    <template #show_details="{ item, index }">
      <td class="py-2">
        <CButton
          color="primary"
          variant="outline"
          square
          size="sm"
          @click="toggleDetails(item, index)"
        >
          {{ Boolean(item._toggled) ? 'Hide' : 'Critérios' }}
        </CButton>
      </td>
    </template>
    <template #details="{ item }">
      <CCollapse :visible="this.details.includes(item._id)">
        <CCardBody>
          <CTable striped>
            <CTableHead>
              <CTableRow>
                <CTableHeaderCell scope="col">#</CTableHeaderCell>
                <CTableHeaderCell scope="col">Descrição</CTableHeaderCell>
                <CTableHeaderCell scope="col">Perfil</CTableHeaderCell>
                <CTableHeaderCell scope="col">Peso</CTableHeaderCell>
              </CTableRow>
            </CTableHead>
            <CTableBody>
              <CTableRow v-for="(criterio, index) in item.criterios">
                <CTableHeaderCell scope="row">{{index+1}}</CTableHeaderCell>
                <CTableDataCell>{{criterio.descricao}}</CTableDataCell>
                <CTableDataCell>{{criterio.perfil}}</CTableDataCell>
                <CTableDataCell>{{criterio.peso}}</CTableDataCell>
              </CTableRow>
            </CTableBody>
          </CTable>
        </CCardBody>
      </CCollapse>
    </template>
  </CSmartTable>
</template>
<script>
export default {
  name: 'JobTable',
  data: () => {
    return {
      columns: [
        {
          key: 'cargo',
          label: 'Cargo ou Função',
          _style: { width: '40%' },
        },
        { key: 'dataCriacao', label: 'Data de Criação', _style: { width: '20%' } },
        {
          key: 'cidade',
          filter: true,
          sorter: true,
          _style: { width: '20%' },
        },
        { key: 'formaContratacao', label: 'Forma de Contratação', _style: { width: '20%' } },
        { key: 'dataExpiracao', label: 'Data de Expiração', _style: { width: '20%' } },
        {
          key: 'show_details',
          label: '',
          _style: { width: '1%' },
          filter: false,
          sorter: false,
        },
      ],
      details: [],
      items: [
        {
          cargo: 'Arquiteto de Software',
          dataCriacao: '2022/09/07',
          dataExpiracao: '2022/10/30',
          cidade: 'Juiz de Fora',
          formaContratacao: 'CLT',
        },
      ],
    }
  },
  methods: {
    getBadge(status) {
      switch (status) {
        case 'Active':
          return 'success'
        case 'Inactive':
          return 'secondary'
        case 'Pending':
          return 'warning'
        case 'Banned':
          return 'danger'
        default:
          'primary'
      }
    },
    toggleDetails(item) {
      if (this.details.includes(item._id)) {
        this.details = this.details.filter((_item) => _item !== item._id)
        return
      }
      this.details.push(item._id)
    },
  },
  async mounted() {
    // console.log(this.items)
    // this.items = JSON.parse(JSON.stringify(this.fullUser));
    const jobStore = useJobStore()
    await jobStore.getAll()
    this.items = jobStore.jobs
    console.log(toRaw(jobStore.jobs))
  },
}
</script>
