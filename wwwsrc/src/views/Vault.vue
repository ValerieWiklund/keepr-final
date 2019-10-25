<template>
  <div>
    <div class="vault">
      <h3 class="text-white">Keeps in This Vault</h3>
      <div class="row justify-content-center">
        <button class="btn btn-primary" @click="goDashboard">Dashboard</button>
      </div>
      <div class="row">
        <keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/KeepComp";
export default {
  name: "vault",
  mounted() {
    this.$store.dispatch("getKeepsByVault", this.$route.params.vaultId);
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
    },

    goDashboard() {
      let data = {};
      this.$store.commit("setKeeps", data);
      this.$router.push({ name: "dashboard" });
    }
  },
  components: { Keep }
};
</script>

<style scoped>
.vault {
  align-content: center;
}
</style>