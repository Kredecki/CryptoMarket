<template>
    <navigation />
Exchange
</template>

<script lang="ts">
  import { defineComponent, ref, onMounted, defineAsyncComponent } from 'vue';
  import axios from 'axios';

  const Navigation = defineAsyncComponent(() => import('./Navigation.vue'))

  export default defineComponent({
    components: {
      Navigation
    },
    setup(){

      const availableBalance = ref('');
      var isLoggedIn = ref('');

      function checkAuthenticationStatus() {
      axios.get('/api/CheckAuthentication')
        .then(response => {
          isLoggedIn.value = "true";
        })
        .catch(error => {
          isLoggedIn.value = "false";
        });
      }
      
      onMounted(async () =>{

        checkAuthenticationStatus();

        const response = await axios.get('api/GetAvailableBalance', {
          params: {
            currency: "USDT"
          }
        });
        availableBalance.value = response.data;
        console.log("balance: " + availableBalance.value)
      })

      return {
        availableBalance,
        isLoggedIn
      };
    },
  });
</script>

<style>
@import '../styles/SpotTradingStyle.scss';
</style>