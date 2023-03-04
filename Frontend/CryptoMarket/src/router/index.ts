import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import { RouterNameEnum, RouterUrlEnum } from '../types/enums';

import dashboard from '../components/dashboard.vue';

const routes: Array<RouteRecordRaw> = [
  {
    path: RouterUrlEnum.Default,
    name: RouterNameEnum.Default,
    component: dashboard,
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
