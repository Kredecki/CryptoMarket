import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import { RouterNameEnum, RouterUrlEnum } from '../types/enums';

import Dashboard from '../components/Dashboard.vue'
import Exchange from '../components/Exchange.vue'
import Login from '../components/Login.vue'
import Register from '../components/Register.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: RouterUrlEnum.Default,
    name: RouterNameEnum.Default,
    component: Dashboard,
  },
  {
    path: RouterUrlEnum.Exchange,
    name: RouterNameEnum.Exchange,
    component: Exchange,
  },
  {
    path: RouterUrlEnum.Login,
    name: RouterNameEnum.Login,
    component: Login,
  },
  {
    path: RouterUrlEnum.Register,
    name: RouterNameEnum.Register,
    component: Register,
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
