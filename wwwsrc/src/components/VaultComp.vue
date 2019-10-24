<template>
  <div class="vault card border-primary" style="width: 100%;">
    <div class="card-body">
      <h5 class="card-title">{{vaultProp.name}}</h5>
      <p class="card-text">{{vaultProp.description}}</p>
      <button class="btn btn-primary btn-sm mx-1" @click="viewVault(vaultProp)">View Vault</button>
      <button class="btn btn-primary btn-sm mx-1" @click="deleteVault(vaultProp)">Delete Vault</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "vault",
  props: ["vaultProp"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteVault(vault) {
      this.$store.dispatch("deleteVault", vault);
    },

    viewVault(vault) {
      let vaultId = vault.id;
      this.$router.push({ name: "vault", params: { vaultId } });
    }
  },
  components: {}
};
</script>
<style scoped>
</style>