<template>
  <CFooter>
    <div>
      <a :href="urlBase">VenturaHR</a>
      <span class="ms-1">&copy; {{ new Date().getFullYear() }} Infnet</span>
    </div>
  </CFooter>
</template>

<script>
export default {
  name: 'AppFooter',
  data: () => {
    return {
      urlBase: window.location.origin,
    }
  },
}
</script>
