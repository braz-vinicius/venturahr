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
          <strong>Perfil</strong>
        </CCardHeader>
        <CCardBody>
          <CForm
            class="row g-3"
            @submit.prevent="editUser"
            :validated="validatedForm"
            novalidate
          >
            <CCol :md="6">
              <CFormLabel for="inputEmail4">Nome</CFormLabel>
              <CFormInput v-model="fullUser.nome" required />
            </CCol>
            <CCol :md="6">
              <CFormLabel for="inputPassword4">CPF</CFormLabel>
              <CFormInput v-model="fullUser.cpf" disabled />
            </CCol>
            <CCol :md="6">
              <CFormLabel for="inputEmail4">Email</CFormLabel>
              <CFormInput v-model="fullUser.email" required />
            </CCol>
            <CCol :md="6">
              <CFormLabel for="inputPassword4">Senha</CFormLabel>
              <CFormInput type="password" v-model="fullUser.senha" required />
            </CCol>
            <CCol :xs="6">
              <CFormLabel for="inputAddress">Telefone</CFormLabel>
              <CFormInput id="inputAddress" v-model="fullUser.telefone" />
            </CCol>
            <CCol :xs="6">
              <CFormLabel for="inputAddress2">Endereço</CFormLabel>
              <CFormInput id="inputAddress2" v-model="fullUser.endereco" />
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
  name: 'Profile',
  data: () => {
    return {
      isLoading: false,
      showErrors: '',
      showSuccess: false,
      validatedForm: null,
      form: {
        nome: '',
        email: '',
        senha: '',
        cpf: '',
        cnpj: '',
        telefone: '',
        endereco: '',
      },
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
  },
}
</script>
