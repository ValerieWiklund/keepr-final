<template>
  <div>
    <div class="home">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
    </div>

    <h3>This is all possible keeps</h3>
    <keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
  </div>
</template>

<script>
import Keep from "../components/KeepComp";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: { Keep }
};
</script>