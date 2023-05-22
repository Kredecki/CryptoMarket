<template>
  <div>
    <navigation />
  </div>
dashboard
</template>

<script lang="ts">
  import { defineComponent, defineAsyncComponent, ref  } from 'vue';
  import { NavigationItem } from '../types/enums/NavigationEnum'
  import Login from '../components/Login.vue'
  import Register from '../components/Register.vue'

  const Navigation = defineAsyncComponent(() => import('./Navigation.vue'))

  export default defineComponent({
    components: {
      Navigation,
      Login,
      Register,
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