<script setup>
import { storeToRefs } from 'pinia'
import { useAuthStore, useUsersStore } from '@/stores'
import { onMounted, computed } from 'vue'

const authStore = useAuthStore()
const { user: authUser } = storeToRefs(authStore)

const userStore = useUsersStore()

const fullUser = computed(() => {
  return userStore.user
})

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
            @submit.prevent="editUser"
            :validated="validatedForm"
            novalidate
          >
            <CCol :md="6">
              <CFormLabel for="inputEmail4">Cargo</CFormLabel>
              <CFormInput v-model="fullUser.nome" required />
            </CCol>
            <CCol :md="6">
              <CFormLabel for="inputPassword4">Empresa</CFormLabel>
              <CFormInput v-model="fullUser.cpf" disabled />
            </CCol>
            <CCol :md="6">
              <CFormLabel for="inputEmail4">Cidade</CFormLabel>
              <CFormInput v-model="fullUser.email" required />
            </CCol>
            <CCol :md="6">
              <CFormLabel for="inputPassword4">Forma de Contratação</CFormLabel>
              <CFormInput v-model="fullUser.senha" required />
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
                      <CFormInput v-model="criterio.nome" required />
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
                            color="primary"
                            variant="outline"
                            square
                            size="sm"
                            @click="toggleDetails(item, index)"
                          >
                            {{ Boolean(item._toggled) ? 'Hide' : 'Show' }}
                          </CButton>
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
                Atualizar Perfil</CButton
              >
            </CCol>
          </CForm>
          <CRow class="mt-3">
            <CCol>
              <CAlert color="success" v-if="showSuccess"
                >As atualizações de perfil foram salvas com sucesso.</CAlert
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
export default {
  name: 'Vaga',
  data: () => {
    return {
      isLoading: false,
      showErrors: '',
      showSuccess: false,
      validatedForm: null,
      criterio: {
        nome: '',
        descricao: '',
        perfil: '1',
        peso: '1',
      },
      form: {
        nome: '',
        email: '',
        senha: '',
        cpf: '',
        cnpj: '',
        telefone: '',
        endereco: '',
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
      items: [
        {
          nome: 'Desenvolvimento C#',
          descricao: 'Conhecimentos de desenvolvimento em C#',
          perfil: '4',
          peso: '5',
        },
      ],
    }
  },
  methods: {
    async editUser(event) {
      const form = event.currentTarget

      if (form.checkValidity() === true) {
        this.isLoading = true
        await this.userStore.updateUser(this.fullUser).catch((error) => {
          this.showErrors = error
        })

        if (this.showErrors == '') this.showSuccess = true
      }

      this.isLoading = false
      this.validatedForm = true
    },
    addCriterio(event) {
      this.items.push({
        nome: this.criterio.nome,
        descricao: this.criterio.descricao,
        perfil: this.criterio.perfil,
        peso: this.criterio.peso,
      })
      this.items = []
      console.log(event)
      console.log(this.items)
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
