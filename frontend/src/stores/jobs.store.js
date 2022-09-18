import { defineStore } from 'pinia'
import { fetchWrapper } from '@/helpers'

const baseUrl = `${process.env.VUE_APP_VENTURA_API_URL}/vaga`
const respostaUrl = `${process.env.VUE_APP_VENTURA_API_URL}/resposta`

export const useJobStore = defineStore({
  id: 'jobs',
  state: () => ({
    jobs: {},
    job: {},
  }),
  actions: {
    async getAll() {
      //this.jobs = { loading: true }
      await fetchWrapper
        .get(baseUrl)
        .then((jobs) => (this.jobs = jobs))
        .catch((error) => (this.jobs = { error }))
    },
    async postVaga(vaga) {
      return await fetchWrapper.post(baseUrl, vaga)
    },
    async getVaga(id) {
      return await fetchWrapper
        .get(`${baseUrl}/${id}`)
        .then((job) => (this.job = job))
        .catch((error) => (this.job = { error }))
    },
    async postResposta(resposta) {
      return await fetchWrapper.post(respostaUrl, resposta)
    },
  },
})
