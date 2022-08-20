<script setup>
import { useAuthStore } from '@/stores'
</script>

<template>
  <div class="bg-light min-vh-100 d-flex flex-row align-items-center">
    <CContainer>
      <CRow class="justify-content-center">
        <CCol :md="8">
          <CCardGroup>
            <CCard class="p-4">
              <CCardBody>
                <CForm
                  :validated="validatedCustom01"
                  @submit.prevent="onSubmit"
                  novalidate
                >
                  <h1>Login</h1>
                  <p class="text-medium-emphasis">Entre na sua conta</p>
                  <CInputGroup class="mb-3">
                    <CInputGroupText>
                      <CIcon icon="cil-user" />
                    </CInputGroupText>
                    <CFormInput
                      v-model="username"
                      placeholder="Email"
                      autocomplete="email"
                      required
                    />
                    <CFormFeedback invalid>
                      Por favor digite seu email.
                    </CFormFeedback>
                  </CInputGroup>
                  <CInputGroup class="mb-4">
                    <CInputGroupText>
                      <CIcon icon="cil-lock-locked" />
                    </CInputGroupText>
                    <CFormInput
                      v-model="password"
                      type="password"
                      placeholder="Senha"
                      autocomplete="senha"
                      required
                    />
                    <CFormFeedback invalid>
                      Por favor digite sua senha.
                    </CFormFeedback>
                  </CInputGroup>
                  <CRow>
                    <CCol :xs="6">
                      <CButton
                        color="primary"
                        class="px-4"
                        type="submit"
                        :disabled="this.isLoading"
                      >
                        <CSpinner
                          component="span"
                          size="sm"
                          aria-hidden="true"
                          v-show="this.isLoading"
                        />
                        Entrar
                      </CButton>
                    </CCol>
                  </CRow>
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
            <CCard class="text-white bg-primary py-5" style="width: 44%">
              <CCardBody class="text-center">
                <div>
                  <h2>VenturaHR</h2>
                  <p>Não possui conta?</p>
                  <RouterLink to="/register" class="nav-item nav-link">
                    <CButton color="light" variant="outline" class="mt-3">
                      Registre-se agora!
                    </CButton></RouterLink
                  >
                </div>
              </CCardBody>
            </CCard>
          </CCardGroup>
        </CCol>
      </CRow>
    </CContainer>
  </div>
</template>

<script>
export default {
  name: 'Login',
  data: () => {
    return {
      username: null,
      password: null,
      showErrors: null,
      validatedCustom01: null,
      isLoading: false,
    }
  },
  methods: {
    async onSubmit(event) {
      const form = event.currentTarget

      if (form.checkValidity() === false) {
        event.preventDefault()
        event.stopPropagation()
      } else {
        const authStore = useAuthStore()
        this.isLoading = true
        await authStore.login(this.username, this.password).catch((error) => {
          this.showErrors = error
        })
        this.isLoading = false
      }

      this.validatedCustom01 = true
    },
  },
}
</script>
