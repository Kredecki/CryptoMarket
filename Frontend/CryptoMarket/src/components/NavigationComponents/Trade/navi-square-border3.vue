<template>
    <div id="navi-square-border3" class="navi-square-border">
        <div id="navi-square2" class="navi-square">
            <div>
            <p>Margin Trading</p>
            <a>Invest with borrowed funds to boost returns</a>
            </div>
            <ol>
            <li>
                <div id="navi-box20" class="navi-box" :style="{'background-color': '#393A3F', 'height': height + 'px'}">
                <div id="navi-square20" class="navi-square" style="background-color: #393A3F;">
                    <img class="coin" src="../../public/btc.svg">
                    <div>
                    <p>BTC/USDT <img class="hot" src="../../public/hot.svg"> </p>
                    <a>Bitcoin</a>
                    </div>
                </div>
                </div>
            </li>
            </ol>
        </div>
    </div>
</template>

<script lang="ts">
  import { defineComponent, defineAsyncComponent } from 'vue';

  // height = square.count() * 90
  let height = 270

  export default defineComponent({
    name: 'navi-square-border3',
    setup(){
      return{
        height
      }
    },
  });
</script>