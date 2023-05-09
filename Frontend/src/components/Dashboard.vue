<template>
  <div>
    <navigation @view="(i) => currentView = i" />
      <component :is="currentView" />
  </div>

</template>

<script lang="ts">
  import { defineComponent, defineAsyncComponent, ref  } from 'vue';
  import { NavigationItem } from '../types/enums/NavigationEnum'
  import Login from '../components/Login.vue'
  import Register from '../components/Register.vue'
  import SpotTrading from './SpotTrading.vue';

  const Navigation = defineAsyncComponent(() => import('./Navigation.vue'))

  export default defineComponent({
    components: {
      Navigation,
      Login,
      Register,
      SpotTrading
    },
    setup(){
      const currentView = ref<NavigationItem>(NavigationItem.dashboard);
      return{
        currentView,
      };
    },
  });
</script>

<style>
@import '../styles/style.scss';
</style>