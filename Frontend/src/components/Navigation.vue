<template>
  <div id="navigation">
    <div id="navigation-left" @click="go(NavigationItem.dashboard)">
      <p class="crypto">Crypto</p>
      <p class="market">Market</p>
    </div>
    <div id="navigation-center">
      <ol>

        <li><button>Trade<i class="arrow-down"></i></button>
          <ul>
            <li>
              <div id="navi-box0" class="navi-box" :style="{ 'height': height + 'px'}">
                
                <div id="navi-square-border1" class="navi-square-border">
                  <div id="navi-square0" class="navi-square">
                    <div @click="go(NavigationItem.exchange)">
                        <p>Exchange</p>
                        <a>Swap your crypto</a>
                    </div>
                    <ol>
                        <li>
                          <div id="navi-box00" class="navi-box" :style="{'background-color': '#393A3F', 'height': height2 + 'px'}">
                              <div id="navi-square01" class="sub-navi-square" style="background-color: #393A3F;">
                                <img class="coin" src="@/../public/btc.svg">
                                <div>
                                    <p>BTC/USDT <img class="hot" src="@/../public/hot.svg"> </p>
                                    <a>Bitcoin</a>
                                </div>
                              </div>
                              <div id="navi-square01" class="sub-navi-square" style="background-color: #393A3F;">
                                <img class="coin" src="@/../public/eth.svg">
                                <div>
                                    <p>ETH/USDT <img class="hot" src="@/../public/hot.svg" > </p>
                                    <a>Ethereum</a>
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

    <div id="navigation-right" v-if="isLoggedIn == 'true'">
      <button class="SignInBtn" @click="logout">Sign out</button>
    </div>

    <div id="navigation-right" v-if="isLoggedIn == 'false'">
      <button class="LogInBtn" @click="go(NavigationItem.login)">Log In</button>
      <button class="SignInBtn" @click="go(NavigationItem.register)">Sign Up</button>
    </div>
  </div>
</template>

<script lang="ts">
  import { defineComponent, ref, onMounted } from 'vue';
  import { NavigationItem } from '../types/enums/NavigationEnum'
  import axios from 'axios';
  import router from '../router/index';

  let height = 90
  let height2 = 180

  const components: {[key: string]: any} = {};

  export default defineComponent({
    components: {
      components
    },
    setup(props, { emit }){

      const viewName = 'view'
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
      
      const logout = () => {
          axios.post('api/Logout')
          .then((response) => {
            isLoggedIn.value = "false";
            window.location.reload();
            console.log(response.data)
          })
        };

      function go(value: NavigationItem){
        router.push(value)
      }
      
      onMounted(async () =>{
        checkAuthenticationStatus();
        })

      return{
        components,
        NavigationItem,
        height,
        height2,
        logout,
        isLoggedIn,
        go
      };
    },
  });
</script>