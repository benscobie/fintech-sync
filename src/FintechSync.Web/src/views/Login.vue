<template>
  <div>
    <h1>Login</h1>
    <form>
      <img
        class="mb-4"
        src="/docs/5.1/assets/brand/bootstrap-logo.svg"
        alt=""
        width="72"
        height="57"
      />
      <h1 class="h3 mb-3 fw-normal">Please sign in</h1>

      <div class="form-floating">
        <input
          type="email"
          class="form-control"
          id="floatingInput"
          placeholder="name@example.com"
        />
        <label for="floatingInput">Email address</label>
      </div>
      <div class="form-floating">
        <input
          type="password"
          class="form-control"
          id="floatingPassword"
          placeholder="Password"
        />
        <label for="floatingPassword">Password</label>
      </div>

      <button class="w-100 btn btn-lg btn-primary" type="button" @click="login">
        Sign in
      </button>
      <p class="mt-5 mb-3 text-muted">&copy; 2017–2021</p>
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Login",
  data() {
    return {
      username: "",
      password: ""
    }
  },
  methods: {
    login() {
      this.$http
      .post('https://localhost:7228/bff/login', {
        client_id: "js",
        username: this.username,
        password: this.password,
        grant_type: "password"
      })
      .then(response => (console.log(response)))
    }
  }
});
</script>

<style scoped></style>
