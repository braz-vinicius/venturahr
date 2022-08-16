<template>
  <div class="bg-light min-vh-100 d-flex flex-row align-items-center">
    <CContainer>
      <CRow class="justify-content-center">
        <CCol :md="6">
          <span class="clearfix">
            <h1 class="float-start display-3 me-4">500</h1>
            <h4 class="pt-3">Ops, algo errado aconteceu!</h4>
            <p class="text-medium-emphasis float-start">
              A página que você acessou está temporariamente indisponível.
            </p>
          </span>
        </CCol>
      </CRow>
    </CContainer>
  </div>
</template>

<script>
export default {
  name: 'Page500',
}
</script>
