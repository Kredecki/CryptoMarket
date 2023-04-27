<template>
    <div id="Registration-panel">
        <form @submit.prevent="submitForm" method="post">
            <label for="Email" class="control-label">Email</label>
            <input v-model="Email" id="email" class="form-control" />

            <label for="Password" class="control-label">Password</label>
            <input v-model="Password" id="username" class="form-control" type="password" />

            <input type="submit" value="Register" class="btn btn-primary">
        </form>
    </div>
</template>

<script lang="ts">
  import { defineComponent, ref } from 'vue';
  import axios from 'axios';

  export default defineComponent({
    setup(){
      const Password = ref();
      const Email = ref();

      const submitForm = () => {
        axios
        .post('https://localhost:7139/Register', {
                Email: Email.value,
                Password: Password.value
            }, {
              headers: {
                'accept': '*/*',
                'Content-Type': 'multipart/form-data'
              }
            })
      }

      return{
        Password,
        Email,
        submitForm
      };
    },

  }); 
</script>