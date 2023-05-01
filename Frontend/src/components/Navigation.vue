<template>
  <div id="navigation">
    <div id="navigation-left">
      <p class="crypto">Crypto</p>
      <p class="market">Market</p>
    </div>
    <div id="navigation-center">
      <ol>
        <li><button>Buy Crypto<i class="arrow-down"></i></button></li>

        
          <li><button>Markets<i class="arrow-down"></i></button>
            <ul>
              <li>
                <div id="navi-box0" class="navi-box">
                        
                </div>
              </li>
            </ul>
          </li>
        

        <li><button>Trade<i class="arrow-down"></i></button>
          <ul>
            <li>
              <div id="navi-box0" class="navi-box" :style="{ 'height': height + 'px'}">
                
                <div id="navi-square-border1" class="navi-square-border">
                  <div id="navi-square0" class="navi-square">
                    <div>
                        <p>Spot Trading</p>
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
                            <img class="coin" src="@/../public/btc.svg">
                            <div>
                                <p>BTC/USDT <img class="hot" src="@/../public/hot.svg"> </p>
                                <a>Bitcoin</a>
                            </div>
                            </div>
                        </div>
                        </li>
                    </ol>
                  </div>     
                </div>

                <div id="navi-square-border2" class="navi-square-border">
                  <div id="navi-square1" class="navi-square">
                      <div>
                      <p>Convert</p>
                      <a>Quick conversion with zero fees and no slippage</a>
                      </div>
                  </div>
                </div>

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
                              <img class="coin" src="@/../public/btc.svg">
                              <div>
                              <p>BTC/USDT <img class="hot" src="@/../public/hot.svg"> </p>
                              <a>Bitcoin</a>
                              </div>
                          </div>
                          </div>
                      </li>
                      </ol>
                  </div>
                </div>
                      
              </div>
            </li>
          </ul>
        </li>
      </ol>

    </div>
    <div id="navigation-right">
      <button class="LogInBtn" @click="sendView(NavigationItem.login)">Log In</button>
      <button class="SignInBtn" @click="sendView(NavigationItem.register)">Sign Up</button>
    </div>
  </div>
</template>

<script lang="ts">
  import { defineComponent, defineAsyncComponent, ref } from 'vue';
  import { NavigationItem } from '../types/enums/NavigationEnum'

  let height = 270

  const components: {[key: string]: any} = {};

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
        components,
        NavigationItem,
        sendView,
        height
      };
    },
  });
</script>