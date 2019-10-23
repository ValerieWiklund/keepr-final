<template>
  <div class="vault card border-primary" style="width: 100%;">
    <div class="card-body">
      <h5 class="card-title">
        {{vaultProp.name}}
        <span class="btn btn-sm" @click="deleteVault(vaultProp)">
          <i class="far fa-times-circle fa-2x"></i>
        </span>
      </h5>
      <p class="card-text">{{vaultProp.description}}</p>
      <button class="btn btn-primary" @click="viewVault(vaultProp)">View Vault</button>
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
      debugger;
      let vaultId = vault.id;
      this.$router.push({ name: "vault", params: { vaultId } });
    }
  },
  components: {}
};
</script>
<style scoped>
</style>