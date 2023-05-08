<template>
  <div style="background-color: #171B26;">

  <Ticker style="padding-bottom: 5px;"
    :options="{
      symbols:[
        {
          proName: 'BITSTAMP:BTCUSD',
          Title: 'Bitcoin'
        },
        {
          proName: 'BITSTAMP:ETHUSD',
          Title: 'Ethereum'
        },
        {
          proName: 'CRYPTOCAP:XMR',
          Title: 'Monero'
        },
        {
          proName: 'BITGET:HEXUSDT',
          Title: 'HEX'
        },
        {
          proName: 'BINANCE:XRPUSDT',
          Title: 'Ripple'
        },
      ],
      colorTheme: 'dark',
      isTransparent: false,
      showSymbolLogo: true,
      locale: 'en'
    }"
  />
  <Chart style="height: 60vh; padding-bottom: 10px; width: 60%;"
    :options="{
      autosize: true,
      symbol: 'BINANCE:BTCUSDT',
      interval: 'D',
      timezone: 'Etc/UTC',
      theme: 'dark',
      style: '1',
      locale: 'en',
      toolbar_bg: '#f1f3f6',
      enable_publishing: false,
      allow_symbol_change: true,
      container_id: 'tradingview-chart'
    }"
  />


  </div>
</template>

<script lang="ts">
  import { defineComponent } from 'vue';
  import { Chart, Ticker } from 'vue-tradingview-widgets';

  export default defineComponent({
    components: {
      Chart,
      Ticker
    },
    setup(){
      return {
        
      };
    },
  });
</script>