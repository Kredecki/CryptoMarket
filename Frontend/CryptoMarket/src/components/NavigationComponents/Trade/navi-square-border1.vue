<template>
    <div id="navi-square-border1" class="navi-square-border">
        <div id="navi-square0" class="navi-square">
        <div>
            <p>Spot trading</p>
            <a>Buy & Sell on the Spot</a>
        </div>
        <ol>
            <li>
            <div id="navi-box00" class="navi-box" :style="{'background-color': '#393A3F', 'height': height + 'px'}">
                <div id="navi-square00" class="navi-square" style="background-color: #393A3F;">
                <div>
                    <a id="selected" class="header01">USDT</a>
                    <a class="header01">USDC</a>
                    <a class="header01">BUSD</a>
                    <a class="header01">BTC</a>
                    <a class="header01">DAI</a>
                    <a class="header01">EUR</a>
                </div>
                </div>
                <div id="navi-square01" class="navi-square" style="background-color: #393A3F;">
                <img class="coin" src="../../../../public/btc.svg">
                <div>
                    <p>BTC/USDT <img class="hot" src="../../../../public/hot.svg"> </p>
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
    name: 'navi-square-border1',
    setup(){
      return{
        height
      }
    },
  });
</script>