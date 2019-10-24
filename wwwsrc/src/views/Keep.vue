<template>
  <div>
    <div class="keepDetail">
      <img :src="keep.img" />
      <h1>{{keep.name}}</h1>
      <h5>{{keep.description}}</h5>
      <div v-if="user.id">
        <select v-model="newVaultId" @change="addToVault(keep)">
          <option disabled value>Add to Vault</option>
          <option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{vault.name}}</option>
        </select>
      </div>
      <div class="row">
        <button v-if="user.id" @click="goDashboard">Dashboard</button>
        <button v-if="!user.id" @click="goHome">Back</button>
      </div>
    </div>
  </div>
</template>

    </div>
  </div>
</template>

<script>
export default {
  name: "keepDetail",
  data() {
    return {
      newVaultId: ""
    };
  },
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.keepId);
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    },
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },

    addToVault(keep) {
      keep.keeps++;
      this.$store.dispatch("editKeep", keep);
      let data = {
        vaultId: this.newVaultId,
        keepId: this.keep.id
      };
      this.$store.dispatch("createVaultKeep", data);
    },

    goDashboard() {
      this.$router.push({ name: "dashboard" });
    },

    goHome() {
      this.$router.push({ name: "home" });
    }
  },
  components: {}
};
</script>