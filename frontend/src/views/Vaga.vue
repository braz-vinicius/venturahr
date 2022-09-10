<script setup>
/* eslint-disable */
import { storeToRefs } from 'pinia'
import { useAuthStore, useUsersStore, useJobStore } from '@/stores'
import { onMounted } from 'vue'
import router from '@/router'

const jobStore = useJobStore()
const authStore = useAuthStore()
const { user: authUser } = storeToRefs(authStore)

const userStore = useUsersStore()

// const fullUser = computed(() => {
//   return userStore.user
// })

onMounted(() => {
  userStore.getUser(authUser.value.id)
})
</script>
<template>
  <CRow>
    <CCol :xs="12">
      <CCard class="mb-4">
        <CCardHeader>
          <strong>Vaga</strong>
        </CCardHeader>
        <CCardBody>
          <CForm
            class="row g-3"
            @submit.prevent="postVaga"
            :validated="validatedForm"
            novalidate
          >
            <CCol :md="6">
              <CFormLabel for="inputEmail4">Cargo</CFormLabel>
              <CFormInput v-model="vaga.cargo" required />
            </CCol>
            <CCol :md="6">
              <CFormLabel for="inputPassword4">Empresa</CFormLabel>
              <CFormInput :value="userStore.user.nome" disabled />
            </CCol>
            <CCol :md="6">
              <CFormLabel for="inputEmail4">Cidade</CFormLabel>
              <CFormInput v-model="vaga.cidade" required />
            </CCol>
            <CCol :md="6">
              <CFormLabel for="inputPassword4">Forma de Contratação</CFormLabel>
              <CFormInput v-model="vaga.formaContratacao" required />
            </CCol>
            <CCol :xs="12">
              <CCard class="mb-4">
                <CCardHeader>
                  <strong>Critérios</strong>
                </CCardHeader>
                <CCardBody>
                  <CRow class="mb-2">
                    <CCol :md="3">
                      <CFormLabel for="inputEmail4">Nome</CFormLabel>
                      <CFormInput v-model="criterio.nome" />
                    </CCol>
                    <CCol :md="6">
                      <CFormLabel for="inputPassword4">Descrição</CFormLabel>
                      <CFormInput v-model="criterio.descricao" />
                    </CCol>
                    <CCol :md="1">
                      <CFormLabel for="inputEmail4">Perfil</CFormLabel>
                      <CFormSelect
                        v-model="criterio.perfil"
                        aria-label="Perfil do critério"
                      >
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                      </CFormSelect>
                    </CCol>
                    <CCol :md="1">
                      <CFormLabel for="inputPassword4">Peso</CFormLabel>
                      <CFormSelect
                        v-model="criterio.peso"
                        aria-label="Peso do critério"
                      >
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                      </CFormSelect>
                    </CCol>
                    <CCol :md="1" class="mt-2">
                      <CButton
                        class="mt-4"
                        type="button"
                        color="primary"
                        variant="outline"
                        :disabled="isLoading"
                        @click="addCriterio"
                      >
                        <CSpinner
                          component="span"
                          size="sm"
                          aria-hidden="true"
                          v-show="isLoading" />
                        <CIcon icon="cil-plus"
                      /></CButton>
                    </CCol>
                  </CRow>
                  <CRow>
                    <CSmartTable
                      :tableProps="{
                        striped: true,
                        hover: false,
                      }"
                      :tableHeadProps="{
                        color: 'secondary',
                      }"
                      :activePage="1"
                      header
                      v-model:items="items"
                      :columns="columns"
                      itemsPerPageSelect
                      :itemsPerPage="5"
                      :sorterValue="{ column: 'status', state: 'asc' }"
                      pagination
                    >
                      <template #status="{ item }">
                        <td>
                          <CBadge :color="getBadge(item.status)">{{
                            item.status
                          }}</CBadge>
                        </td>
                      </template>
                      <template #show_details="{ item, index }">
                        <td class="py-2">
                          <CButton
                            type="button"
                            color="primary"
                            variant="outline"
                            size="sm"
                            :disabled="isLoading"
                            @click="delCriterio(item, index)"
                          >
                            <CSpinner
                              component="span"
                              size="sm"
                              aria-hidden="true"
                              v-show="isLoading" />
                            <CIcon icon="cil-trash"
                          /></CButton>
                        </td>
                      </template>
                      <template #details="{ item }">
                        <CCollapse :visible="this.details.includes(item._id)">
                          <CCardBody>
                            <h4>
                              {{ item.username }}
                            </h4>
                            <p class="text-muted">
                              User since: {{ item.registered }}
                            </p>
                            <CButton size="sm" color="info" class="">
                              User Settings
                            </CButton>
                            <CButton size="sm" color="danger" class="ml-1">
                              Delete
                            </CButton>
                          </CCardBody>
                        </CCollapse>
                      </template>
                    </CSmartTable>
                  </CRow>
                </CCardBody>
              </CCard>
            </CCol>
            <CCol :xs="12">
              <CButton type="submit" color="primary" :disabled="isLoading">
                <CSpinner
                  component="span"
                  size="sm"
                  aria-hidden="true"
                  v-show="isLoading"
                />
                Publicar Vaga</CButton
              >
            </CCol>
          </CForm>
          <CRow class="mt-3">
            <CCol>
              <CAlert color="success" v-if="showSuccess"
                >A vaga foi publicada com sucesso. Redirecionando para o painel de vagas...</CAlert
              >
              <CAlert v-if="showErrors" color="danger">{{ showErrors }}</CAlert>
            </CCol>
          </CRow>
        </CCardBody>
      </CCard>
    </CCol>
  </CRow>
</template>

<script>
/* eslint-disable */
export default {
  name: 'Vaga',
  data: () => {
    return {
      isLoading: false,
      showErrors: '',
      showSuccess: false,
      validatedForm: null,
      vaga: {
        cargo: null,
        empresaId: null,
        formaContratacao: null,
        cidade: null,
        criterios: [],
      },
      criterio: {
        nome: '',
        descricao: '',
        perfil: '1',
        peso: '1',
      },
      columns: [
        {
          key: 'nome',
          filter: false,
          sorter: false,
          _style: { width: '40%' },
          _props: { class: 'fw-semibold' },
        },
        {
          key: 'descricao',
          filter: false,
          sorter: false,
          _style: { width: '20%' },
        },
        {
          key: 'perfil',
          filter: false,
          sorter: false,
          _style: { width: '20%' },
        },
        {
          key: 'peso',
          filter: false,
          sorter: false,
          _style: { width: '20%' },
        },
        {
          key: 'show_details',
          label: '',
          _style: { width: '1%' },
          filter: false,
          sorter: false,
          _props: { class: 'fw-semibold' },
        },
      ],
      details: [],
      items: [],
    }
  },
  methods: {
    async postVaga(event) {
      this.showErrors = ''  
      const form = event.currentTarget

      if (form.checkValidity() === true) {
        this.isLoading = true
        this.vaga.empresaId = this.userStore.user.id
        this.vaga.criterios = this.items
        console.log(this.vaga)
        await this.jobStore.postVaga(this.vaga).catch((error) => {
          this.showErrors = error
        })

        if (this.showErrors == '') {
          this.showSuccess = true
          setTimeout(() => {
            router.push('/')
          }, 2000)
        }
      }

      this.isLoading = false
      this.validatedForm = true
    },
    addCriterio() {
      this.items.push({
        nome: this.criterio.nome,
        descricao: this.criterio.descricao,
        perfil: this.criterio.perfil,
        peso: this.criterio.peso,
      })
      this.items = [...this.items]

      this.criterio.nome = null
      this.criterio.descricao = null
      this.criterio.perfil = 1
      this.criterio.peso = 1
    },
    delCriterio(item, index) {
      this.items.splice(item._id, 1)
      this.items = [...this.items]
    },
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
}
</script>
