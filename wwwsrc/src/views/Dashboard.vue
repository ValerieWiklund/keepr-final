<template>
  <div class="dashboard">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <div class="row">
      <div class="col-4">
        <h4>Your Keeps</h4>
        <CreateKeepModal />
        <button
          class="btn btn-primary"
          data-toggle="modal"
          data-target="#create-keep-modal"
        >Create Keep</button>
        <keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
      </div>
      <div class="offset-2 col-4">
        <h4>Your Vaults</h4>
        <CreateVaultModal />
        <button
          class="btn btn-primary"
          data-toggle="modal"
          data-target="#create-vault-modal"
        >Create vault</button>
        <vault v-for="vault in vaults" :vaultProp="vault" :key="vault.id" />
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/KeepComp";
import Vault from "../components/VaultComp";
import CreateKeepModal from "../components/CreateKeepModal";
import CreateVaultModal from "../components/CreateVaultModal";
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getKeepsByUser");
    this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: { Keep, Vault, CreateKeepModal, CreateVaultModal }
};
</script>