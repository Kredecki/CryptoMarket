<template>
  <li><button>Trade<i class="arrow-down"></i></button>
    <ul>
      <li>
        <div id="navi-box0" class="navi-box" :style="{ 'height': height + 'px'}">
          
          <component v-for="n in elementsCount" :is="components['navi-square-border' + [n]]"></component>
                
        </div>
      </li>
    </ul>
  </li>
</template>

<script lang="ts">
  import { defineComponent, defineAsyncComponent } from 'vue';

  // height = square.count() * 90
  let height = 270
  let elementsCount = 3

  const components: {[key: string]: any} = {};

  for(let x = 0; x < elementsCount+1; x++){
    components['navi-square-border' + [x]] = defineAsyncComponent(() => import(`./Trade/navi-square-border${[x]}.vue`))
  }

  console.log(components)

  export default defineComponent({
    name: 'Trade',
    setup(){
      return{
        height,
        components,
        elementsCount
      }
    },
  });
</script>