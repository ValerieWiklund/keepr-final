<template>
  <div class="keep card border-primary" style="width: 12rem;">
    <img v-bind:src="`${keepProp.img}`" class="card-img-top" alt="..." />
    <div class="card-body">
      <h5>
        {{keepProp.name}}
        <span class="btn btn-sm" @click="deleteKeep(keepProp)">
          <i class="far fa-times-circle fa-2x"></i>
        </span>
      </h5>
      <p class="card-text">{{keepProp.description}}</p>
      <!-- create drowpdown for adding to vault -->
      <select v-model="newVaultId" @change="addToVault">
        <option disabled value>Add to Vault</option>
        <option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{vault.name}}</option>
      </select>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepProp"],
  data() {
    return {
      newVaultId: ""
    };
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    deleteKeep(keep) {
      this.$store.dispatch("deleteKeep", keep);
    },

    addToVault() {
      debugger;
      let data = {
        vaultId: this.newVaultId,
        keepId: this.keepProp.id
      };
      this.$store.dispatch("createVaultKeep", data);
    }
  },
  components: {}
};
</script>
<style scoped>
</style>