<template>
  <div class="dashboard">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <div class="row">
      <div class="col-5">
        <keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/KeepComp";
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getKeepsByUser");
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