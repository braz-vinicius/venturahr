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
                  @submit="onSubmit"
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
                      autocomplete="username"
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
                      autocomplete="current-password"
                      required
                    />
                    <CFormFeedback invalid>
                      Por favor digite sua senha.
                    </CFormFeedback>
                  </CInputGroup>
                  <CRow>
                    <CCol :xs="6">
                      <CButton color="primary" class="px-4" type="submit">
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
      validatedDefault01: null,
      validatedTooltip01: null,
    }
  },
  methods: {
    onSubmit(event) {
      const form = event.currentTarget

      if (form.checkValidity() === false) {
        event.preventDefault()
        event.stopPropagation()
      } else {
        const authStore = useAuthStore()

        return authStore.login(this.username, this.password).catch((error) => {
          this.showErrors = error
        })
      }

      this.validatedCustom01 = true
    },
  },
}
</script>
