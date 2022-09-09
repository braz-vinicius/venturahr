import { defineStore } from 'pinia'
import { fetchWrapper } from '@/helpers'

const baseUrl = `${process.env.VUE_APP_VENTURA_API_URL}/stats`

export const useStatsStore = defineStore({
  id: 'stats',
  state: () => ({
    stats: {},
  }),
  actions: {
    async getAll() {
      await fetchWrapper
        .get(baseUrl)
        .then((stats) => (this.stats = stats))
        .catch((error) => (this.stats = { error }))
    },
  },
})
