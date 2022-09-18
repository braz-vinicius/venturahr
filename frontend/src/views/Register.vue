<script setup>
import { useUsersStore, useAuthStore } from '@/stores'
</script>

<template>
  <div class="bg-light min-vh-100 d-flex flex-row align-items-center">
    <CContainer>
      <CRow class="justify-content-center">
        <CCol :md="9" :lg="7" :xl="6">
          <CCard class="mx-4">
            <CCardBody class="p-4">
              <CForm
                novalidate
                :validated="validatedForm"
                @submit.prevent="onSubmit"
              >
                <h1>Registrar</h1>
                <p class="text-medium-emphasis">Crie sua conta</p>
                <CInputGroup class="mb-3">
                  <CInputGroupText>
                    <CIcon icon="cil-user" />
                  </CInputGroupText>
                  <CFormInput
                    v-model="form.nome"
                    placeholder="Nome"
                    name="nome"
                    autocomplete="nome"
                    required
                  />
                  <CFormFeedback invalid>
                    Por favor digite seu nome.
                  </CFormFeedback>
                </CInputGroup>
                <CInputGroup class="mb-3">
                  <CInputGroupText>@</CInputGroupText>
                  <CFormInput
                    v-model="form.email"
                    placeholder="Email"
                    name="email"
                    autocomplete="email"
                    required
                  />
                </CInputGroup>
                <CFormFeedback invalid>
                  Por favor digite seu email.
                </CFormFeedback>
                <CInputGroup class="mb-3">
                  <CInputGroupText>
                    <CIcon icon="cil-lock-locked" />
                  </CInputGroupText>
                  <CFormInput
                    v-model="form.senha"
                    type="password"
                    placeholder="Senha"
                    name="senha"
                    autocomplete="senha"
                    required
                  />
                </CInputGroup>
                <CFormFeedback invalid>
                  Por favor digite sua senha.
                </CFormFeedback>
                <p class="text-medium-emphasis">Você é:</p>
                <CInputGroup class="mb-4">
                  <CInputGroupText>
                    <CIcon icon="cil-group" />
                  </CInputGroupText>
                  <CFormCheck
                    :button="{ color: 'secondary', variant: 'outline' }"
                    type="radio"
                    name="tipo"
                    id="usuario-candidato"
                    label="Candidato"
                    value="3"
                    @change="changeUserTipo"
                    checked
                  />
                  <CFormCheck
                    :button="{ color: 'secondary', variant: 'outline' }"
                    type="radio"
                    name="tipo"
                    id="usuario-empresa"
                    label="Empresa"
                    value="4"
                    @change="changeUserTipo"
                  />
                </CInputGroup>

                <CInputGroup class="mb-4" v-show="this.form.tipo == 3">
                  <CInputGroupText>
                    <CIcon icon="cil-lock-locked" />
                  </CInputGroupText>
                  <CFormInput
                    v-model="form.cpf"
                    placeholder="CPF"
                    :required="this.form.tipo == 3 ? true : null"
                  />
                </CInputGroup>
                <CInputGroup class="mb-4" v-show="this.form.tipo == 4">
                  <CInputGroupText>
                    <CIcon icon="cil-lock-locked" />
                  </CInputGroupText>
                  <CFormInput
                    v-model="form.cnpj"
                    placeholder="CNPJ"
                    :required="this.form.tipo == 4 ? true : null"
                  />
                </CInputGroup>
                <div class="d-grid">
                  <CButton
                    color="primary"
                    type="submit"
                    :disabled="this.isLoading"
                  >
                    <CSpinner
                      component="span"
                      size="sm"
                      aria-hidden="true"
                      v-show="this.isLoading"
                    />
                    Criar Conta</CButton
                  >
                </div>
                <CRow class="mt-3">
                  <CCol>
                    <CAlert v-if="showErrors" color="danger">{{
                      showErrors
                    }}</CAlert>
                  </CCol>
                </CRow>
              </CForm>
            </CCardBody>
          </CCard>
        </CCol>
      </CRow>
    </CContainer>
  </div>
</template>

<script>
export default {
  name: 'Register',
  data: () => {
    return {
      isLoading: false,
      username: null,
      password: null,
      showErrors: null,
      validatedForm: null,
      form: {
        nome: '',
        email: '',
        senha: '',
        cpf: '',
        cnpj: '',
        tipo: 3,
      },
    }
  },
  methods: {
    async onSubmit() {
      const form = event.currentTarget

      if (form.checkValidity() === true) {
        this.isLoading = true

        const userStore = useUsersStore()
        const authStore = useAuthStore()

        await userStore
          .register(this.form)
          .catch((error) => {
            this.showErrors = error
          })
          .then((resp) => {
            if (resp != undefined) {
              return authStore
                .login(this.form.email, this.form.senha)
                .catch((error) => {
                  this.showErrors = error
                })
            }
          })

        this.isLoading = false
      }

      this.validatedForm = true
    },
    changeUserTipo(ev) {
      if (ev.target.value == 3) this.form.cnpj = null
      else this.form.cpf = null

      this.form.tipo = parseInt(ev.target.value)
    },
  },
}
</script>
