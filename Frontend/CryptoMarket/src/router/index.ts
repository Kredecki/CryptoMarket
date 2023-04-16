import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import { RouterNameEnum, RouterUrlEnum } from '../types/enums';

import Dashboard from '../components/Dashboard.vue'
import Login from '../components/Login.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: RouterUrlEnum.Default,
    name: RouterNameEnum.Default,
    component: Dashboard,
  },
  {
    path: RouterUrlEnum.Login,
    name: RouterNameEnum.Login,
    component: Login,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
