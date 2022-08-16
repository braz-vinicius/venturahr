<template>
  <div class="bg-light min-vh-100 d-flex flex-row align-items-center">
    <CContainer>
      <CRow class="justify-content-center">
        <CCol :md="9" :lg="7" :xl="6">
          <CCard class="mx-4">
            <CCardBody class="p-4">
              <CForm>
                <h1>Registrar</h1>
                <p class="text-medium-emphasis">Crie sua conta</p>
                <CInputGroup class="mb-3">
                  <CInputGroupText>
                    <CIcon icon="cil-user" />
                  </CInputGroupText>
                  <CFormInput
                    v-model="nome"
                    placeholder="Nome"
                    autocomplete="username"
                  />
                </CInputGroup>
                <CInputGroup class="mb-3">
                  <CInputGroupText>@</CInputGroupText>
                  <CFormInput
                    v-model="email"
                    placeholder="Email"
                    autocomplete="email"
                  />
                </CInputGroup>
                <CInputGroup class="mb-3">
                  <CInputGroupText>
                    <CIcon icon="cil-lock-locked" />
                  </CInputGroupText>
                  <CFormInput
                    v-model="senha"
                    type="password"
                    placeholder="Senha"
                    autocomplete="new-password"
                  />
                </CInputGroup>
                <CInputGroup class="mb-4">
                  <CInputGroupText>
                    <CIcon icon="cil-lock-locked" />
                  </CInputGroupText>
                  <CFormInput
                    v-model="repetesenha"
                    type="password"
                    placeholder="Repetir senha"
                    autocomplete="new-password"
                  />
                </CInputGroup>
                <CInputGroup class="mb-4">
                  <CInputGroupText>
                    <CIcon icon="cil-group" />
                  </CInputGroupText>
                  <CFormCheck
                    :button="{ color: 'secondary', variant: 'outline' }"
                    type="radio"
                    name="options-outlined"
                    id="success-outlined"
                    autocomplete="off"
                    label="Candidato"
                    checked
                  />
                  <CFormCheck
                    :button="{ color: 'secondary', variant: 'outline' }"
                    type="radio"
                    name="options-outlined"
                    id="danger-outlined"
                    autocomplete="off"
                    label="Empresa"
                  />
                </CInputGroup>
                <div class="d-grid">
                  <CButton color="success">Criar Conta</CButton>
                </div>
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
}
</script>
