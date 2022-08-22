import { defineStore } from 'pinia'

import { fetchWrapper } from '@/helpers'

const baseUrl = `${process.env.VUE_APP_VENTURA_API_URL}/usuario`

export const useUsersStore = defineStore({
  id: 'users',
  state: () => ({
    users: {},
    user: {},
  }),
  actions: {
    async getAll() {
      this.users = { loading: true }
      fetchWrapper
        .get(baseUrl)
        .then((users) => (this.users = users))
        .catch((error) => (this.users = { error }))
    },
    async register(form) {
      return fetchWrapper.post(`${baseUrl}/register`, {
        nome: form.nome,
        email: form.email,
        senha: form.senha,
        cpf: form.cpf,
        cnpj: form.cnpj,
      })
    },
    async getUser(id) {
      this.user = { loading: true }
      fetchWrapper
        .get(`${baseUrl}/${id}`)
        .then((user) => (this.user = user))
        .catch((error) => (this.user = { error }))
    },
    async updateUser(form) {
      return fetchWrapper.put(`${baseUrl}/${form.id}`, {
        nome: form.nome,
        email: form.email,
        senha: form.senha,
        cpf: form.cpf,
        cnpj: form.cnpj,
        razaoSocial: form.razaoSocial,
        telefone: form.telefone,
        endereco: form.endereco,
      })
    },
  },
})
