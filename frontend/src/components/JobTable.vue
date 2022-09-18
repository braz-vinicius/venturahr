<script setup>
/* eslint-disable */
import { storeToRefs } from 'pinia'
import { useJobStore, useAuthStore } from '@/stores'
import { toRaw, onMounted, onBeforeMount, computed } from 'vue'

const jobStore = useJobStore()

const authStore = useAuthStore()
const { user: authUser } = storeToRefs(authStore)

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
      hover: false,
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
    <template #options="{ item, index }">
      <div>
        <td class="p-1">
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
        <td class="p-1" v-if="authUser?.tipo == 4">
          <CButton
            color="primary"
            variant="outline"
            square
            size="sm"
            @click="toggleRespostas(item, index)"
          >
            {{ Boolean(item._toggled) ? 'Hide' : 'Respostas' }}
          </CButton>
        </td>
        <td class="p-1" v-if="authUser?.tipo == 3">
          <RouterLink :to="{ name: 'Resposta',params: {id: item.id}}" class="nav-item nav-link">
            <CButton
              color="primary"
              variant="outline"
              square
              size="sm"
            >
              {{ Boolean(item._toggled) ? 'Hide' : 'Responder' }}
            </CButton>
          </RouterLink>
        </td>
      </div>
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
                <CTableHeaderCell scope="row">{{ index + 1 }}</CTableHeaderCell>
                <CTableDataCell>{{ criterio.descricao }}</CTableDataCell>
                <CTableDataCell>{{ criterio.perfil }}</CTableDataCell>
                <CTableDataCell>{{ criterio.peso }}</CTableDataCell>
              </CTableRow>
            </CTableBody>
          </CTable>
        </CCardBody>
      </CCollapse>
      <CCollapse :visible="this.respostas.includes(item._id)">
        <CCardBody>
          <CTable striped>
            <CTableHead>
              <CTableRow>
                <CTableHeaderCell scope="col">#</CTableHeaderCell>
                <CTableHeaderCell scope="col">Nome</CTableHeaderCell>
                <CTableHeaderCell scope="col">Data de Resposta</CTableHeaderCell>
                <CTableHeaderCell scope="col">Perfil</CTableHeaderCell>
              </CTableRow>
            </CTableHead>
            <CTableBody>
              <CTableRow v-for="(criterio, index) in item.respostas">
                <CTableHeaderCell scope="row">{{ index + 1 }}</CTableHeaderCell>
                <CTableDataCell>{{ criterio.candidato.nome }}</CTableDataCell>
                <CTableDataCell>{{ criterio.dataResposta }}</CTableDataCell>
                <CTableDataCell>{{ criterio.perfil }}</CTableDataCell>
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
        {
          key: 'dataCriacao',
          label: 'Data de Criação',
          _style: { width: '20%' },
        },
        {
          key: 'cidade',
          filter: true,
          sorter: true,
          _style: { width: '20%' },
        },
        {
          key: 'formaContratacao',
          label: 'Contratação',
          _style: { width: '10%' },
        },
        {
          key: 'dataExpiracao',
          label: 'Data de Expiração',
          _style: { width: '20%' },
        },
        {
          key: 'options',
          label: '',
          _style: { width: '20%' },
          filter: false,
          sorter: false,
        },
      ],
      details: [],
      respostas: [],
      items: [],
    }
  },
  methods: {
    toggleDetails(item) {
      if (this.details.includes(item._id)) {
        this.details = this.details.filter((_item) => _item !== item._id)
        return
      }
      this.respostas = this.respostas.filter((_item) => _item !== item._id)
      this.details.push(item._id)

      console.log(this.details)
    },
    toggleRespostas(item) {
      if (this.respostas.includes(item._id)) {
        this.respostas = this.respostas.filter((_item) => _item !== item._id)
        return
      }
      this.details = this.details.filter((_item) => _item !== item._id)
      this.respostas.push(item._id)

      console.log(this.respostas)
    },    
  },
  async mounted() {
    // console.log(this.items)
    // this.items = JSON.parse(JSON.stringify(this.fullUser));
    const jobStore = useJobStore()
    await jobStore.getAll()
    this.items = toRaw(jobStore.jobs)
    console.log(toRaw(jobStore.jobs))
  },
}
</script>
