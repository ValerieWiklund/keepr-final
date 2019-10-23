<template>
  <div>
    <div class="keepDetail"></div>
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
      this.$router.push({ name: "dashboard" });
    }
  },
  components: { Keep }
};
</script>