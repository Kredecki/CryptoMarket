<template>
  <navigation />
    <div id="Login-panel">
        <form @submit.prevent="submitForm" method="post">
            <label for="Name" class="control-label">Username</label>
            <input v-model="Username" id="username"  class="form-control" />

            <label for="Password" class="control-label">Password</label>
            <input v-model="Password" id="password" class="form-control" type="password" />

            <input type="submit" value="Login" class="btn btn-primary">
        </form>
    </div>
</template>

<script lang="ts">
  import { defineComponent, ref, defineAsyncComponent } from 'vue';
  import axios from 'axios';

  const Navigation = defineAsyncComponent(() => import('./Navigation.vue'))

  export default defineComponent({
    components: {
      Navigation
    },
    setup(){
        const Username = ref();
        const Password = ref();
        var isLoggedIn = ref('');

        const submitForm = () => {
        axios
            .post('api/Login', {
                Username: Username.value,
                Password: Password.value
            }, {
              headers: {
                'accept': '*/*',
                'Content-Type': 'multipart/form-data'
              }
            })
            .then((response) => {
              isLoggedIn.value = "true";
              window.location.reload();
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
