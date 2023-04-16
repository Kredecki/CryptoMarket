<template>
    <div id="Login-panel">
        <form @submit.prevent="submitForm" method="post">
            <label for="Name" class="control-label">Username</label>
            <input v-model="Username" id="username"  class="form-control" />

            <label for="Password" class="control-label">Password</label>
            <input v-model="Password" id="username" class="form-control" />

            <input type="submit" value="Login" class="btn btn-primary">
        </form>
    </div>
</template>

<script lang="ts">
  import { defineComponent, ref } from 'vue';
  import axios from 'axios';

  export default defineComponent({
    setup(){

        const Username = ref();
        const Password = ref();

        const submitForm = () => {
          console.log(Username.value)
          console.log(Password.value)
        axios
            .post('https://localhost:7139/Login', {
                Username: Username.value,
                Password: Password.value
            }, {
              headers: {
                'accept': '*/*',
                'Content-Type': 'multipart/form-data'
              }
            })
            .then((response) => {
                console.log(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
        };

      return{
        Username,
        Password,
        submitForm
      };
    },
  });
</script>
