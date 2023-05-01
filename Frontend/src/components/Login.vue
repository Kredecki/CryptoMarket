<template>
    <div id="Login-panel">
        <form @submit.prevent="submitForm" method="post">
            <label for="Name" class="control-label">Username</label>
            <input v-model="Username" id="username"  class="form-control" />

            <label for="Password" class="control-label">Password</label>
            <input v-model="Password" id="password" class="form-control" type="password" />

            <input type="submit" value="Login" class="btn btn-primary">
        </form>

        <button v-if="loggedIn" @click="logout" class="btn btn-primary">Sign out</button>
    </div>
</template>

<script lang="ts">
  import { defineComponent, ref } from 'vue';
  import axios from 'axios';

  export default defineComponent({
    setup(){
        const Username = ref();
        const Password = ref();
        const loggedIn = ref(false);

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
                console.log(response.data);
                loggedIn.value = true; 
            })
            .catch((error) => {
                console.log(error);
            });
        };

        const logout = () => {
          axios.post('api/Logout')
          .then((response) => {
            console.log(response.data)
          })
          loggedIn.value = false;
        };

      return{
        Username,
        Password,
        submitForm,
        loggedIn,
        logout,
      };
    },
  });
</script>
