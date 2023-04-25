<template>
  <div id="navigation">
    <div id="navigation-left">
      <p class="crypto">Crypto</p>
      <p class="market">Market</p>
    </div>
    <div id="navigation-center">
      <ol >
        <component v-for="n in arrLength" :is="components[arr[n]]"></component>
      </ol>
    </div>
    <div id="navigation-right">
      <RouterLink to="/login">

      </RouterLink>
      <button class="LogInBtn" @click="sendView(NavigationItem.login)">Log In</button>
      <button class="SignInBtn">Sign Up</button>
    </div>
  </div>
</template>

<script lang="ts">
  import { defineComponent, defineAsyncComponent, ref } from 'vue';
  import { NavigationItem } from '../types/enums/NavigationEnum'

  //Symulacja danych z BE
  let arr: string[] = ['', 'Markets', 'Trade', 'BuyCrypto']
  let arrLength = arr.length

  const components: {[key: string]: any} = {};

  for(let x = 0; x < arrLength; x++){
    components[arr[x]] = defineAsyncComponent(() => import(`./NavigationComponents/${arr[x]}.vue`))
  }
  
  export default defineComponent({
    components: {
      components
    },
    setup(props, { emit }){

      const viewName = 'view'

      function sendView(value: NavigationItem){
        emit(viewName, value)
      }

      return{
        arr,
        components,
        arrLength,
        NavigationItem,
        sendView
      };
    },
  });
</script>