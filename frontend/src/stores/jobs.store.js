import { defineStore } from 'pinia'
import { fetchWrapper } from '@/helpers'

const baseUrl = `${process.env.VUE_APP_VENTURA_API_URL}/vaga`

export const useJobStore = defineStore({
  id: 'jobs',
  state: () => ({
    jobs: {},
  }),
  actions: {
    async getAll() {
      //this.jobs = { loading: true }
      await fetchWrapper
        .get(baseUrl)
        .then((jobs) => (this.jobs = jobs))
        .catch((error) => (this.jobs = { error }))
    },
  },
})
