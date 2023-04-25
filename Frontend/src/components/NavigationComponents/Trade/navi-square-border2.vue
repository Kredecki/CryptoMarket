<template>
    <div id="navi-square-border2" class="navi-square-border">
        <div id="navi-square1" class="navi-square">
            <div>
            <p>Convert</p>
            <a>Quick conversion with zero fees and no slippage</a>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
  import { defineComponent, defineAsyncComponent } from 'vue';

  // height = square.count() * 90
  let height = 270

  export default defineComponent({
    name: 'navi-square-border2',
    setup(){
      return{
        height
      }
    },
  });
</script>