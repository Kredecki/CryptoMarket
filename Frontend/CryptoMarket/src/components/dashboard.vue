<template>
  <Navigation></Navigation>

  <button label="Submit" icon="pi pi-check" icon-pos="right" @click="test" >test</button>
  <div>{{ result }}</div>
</template>

<script lang="ts">
  import { defineComponent, defineAsyncComponent, ref  } from 'vue';
  import axios from 'axios';

  const Navigation = defineAsyncComponent(() => import('./Navigation.vue'))

  export default defineComponent({
    components: {
      Navigation
    },
    setup(){

      const result = ref();
      async function test() {
        result.value = await axios.get('https://localhost:7139/WeatherForecast')
      }

      return{
        test,
        result
      };
    },
  });
</script>

<style>
@import '../styles/style.scss';
</style>