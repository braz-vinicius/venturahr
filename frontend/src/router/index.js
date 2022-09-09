/* eslint-disable */
import { createRouter, createWebHashHistory } from 'vue-router'
import { useAuthStore } from '@/stores'

import DefaultLayout from '@/layouts/DefaultLayout'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: DefaultLayout,
    redirect: '/dashboard',
    children: [
      {
        path: '/dashboard',
        name: 'Dashboard',
        component: () =>
          import(/* webpackChunkName: "dashboard" */ '@/views/Dashboard.vue'),
      },
      {
        path: '/profile',
        name: 'Perfil',
        component: () => import('@/views/Profile')
      },
      {
        path: '/vaga',
        name: 'Vaga',
        component: () => import('@/views/Vaga')
      },      
    ],
  },
  { path: '/login', component: () => import('@/views/Login') },
  { path: '/register', component: () => import('@/views/Register') },
]

const router = createRouter({
  history: createWebHashHistory(process.env.BASE_URL),
  routes,
  scrollBehavior() {
    // always scroll to top
    return { top: 0 }
  },
})

router.beforeEach(async (to) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ['/login', '/register'];
  const authRequired = !publicPages.includes(to.path);
  const auth = useAuthStore();

  if (authRequired && !auth.user) {
    auth.returnUrl = to.fullPath;
    return '/login';
  }
});


export default router
