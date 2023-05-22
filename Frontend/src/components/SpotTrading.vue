<template>
  <div style="background-color: #171B26;">

    <div class="STcenter">

      <div id="" class="STorder-book">
      </div>

      <div class="STtrading-panel">
        <div class="trading-panel">
          <form @submit.prevent="submitOrder(OrderDirection, 'Market')" method="post">
            <div class="btns">
              <button id="BuyBtn" class="STbuy-btn" type="button" @click="changeDirection('#20B26C')">Buy</button>
              <button id="SellBtn" class="STsell-btn" type="button" @click="changeDirection('#EF454A')">Sell</button>
            </div>

            <div class="STbalance">
              <p>Available Balance</p> <p class="Balance">{{ availableBalance }}</p>
            </div>

            <div class="orderPrice">
              <label for="OrderPrice">Order Price</label>
              <input v-model="orderPrice" type="textbox" class="STorder-price-tb"/>
              <label class="OrderPriceLabel">BTC</label>
            </div>

            <div class="qty">
              <label for="QtyValue">Qty</label>
              <input v-model="qty" type="textbox" class="STqty-tb"/>
              <label class="QtyValueLabel">BTC</label>
            </div>
                
            <div class="orderValue">
              <label for="OrderValue">Order Value</label>
              <input v-model="orderValue" type="textbox" class="STorder-value-tb" />
              <label class="OrderValueLabel">USDT</label>
            </div>

            <div v-if="isLoggedIn == 'true'" class="OrderBtnDiv">
              <button id="OrderBtn" class="OrderBtn" type="submit">{{ OrderDirection }}</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
  import { defineComponent, ref, onMounted } from 'vue';
  import axios from 'axios';

  export default defineComponent({
    components: {

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

      const orderPrice = ref();
      const qty = ref();
      const orderValue = ref();

      let OrderDirection = ref("Buy");

      function changeDirection(color: string){
        var SellBtn = document.getElementById("SellBtn");
        var BuyBtn = document.getElementById("BuyBtn");
        var OrderBtn = document.getElementById("OrderBtn");

        var green = "";
        var red = "";
        var buyText = "";
        var sellText = "";

        if(SellBtn && BuyBtn && OrderBtn) {

          if(color == "#20B26C") {
            green = "#20B26C"; 
            red="#2F333E"; 
            OrderDirection.value = "Buy";
            buyText = "white";
            sellText = "rgb(190, 190, 190)";
          } else {
            green = "#2F333E"; 
            red = "#EF454A";
            OrderDirection.value = "Sell"
            buyText = "rgb(190, 190, 190)";
            sellText = "white";
          }

          SellBtn.style.backgroundColor = red;
          SellBtn.style.color = sellText;

          BuyBtn.style.backgroundColor = green;
          BuyBtn.style.color = buyText;

          OrderBtn.style.background = color;
          console.log(color)
        }
      }

      function submitOrder(OrderDirection: string, orderType: string){
        axios
        .post('api/CreateOrder', {
                OrderDirection: OrderDirection,
                OrderType: orderType,
                OrderPrice: orderPrice.value,
                Qty: qty.value,
                OrderValue: orderValue.value
            }, {
              headers: {
                'accept': '*/*',
                'Content-Type': 'multipart/form-data'
              }
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
        orderPrice,
        qty,
        orderValue,
        changeDirection,
        OrderDirection,
        submitOrder,
        availableBalance,
        isLoggedIn
      };
    },
  });
</script>

<style>
@import '../styles/SpotTradingStyle.scss';
</style>