<template>
  <div class="keepDetail">
    <div class="row p-5"></div>
    <div class="row">
      <div class="col-12">
        <img :src="keep.img" />
        <h1 class="text-white">{{keep.name}}</h1>
        <h5 class="text-white">{{keep.description}}</h5>
        <span class="badge badge-pill badge-success mr-1">
          <i class="far fa-eye"></i>
          {{keep.views}}
        </span>
        <span class="badge badge-pill badge-success ml-1">
          <i class="fas fa-lock"></i>
          {{keep.keeps}}
        </span>
        <div v-if="user.id">
          <select v-model="newVaultId" @change="addToVault(keep)">
            <option disabled value>Add to Vault</option>
            <option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{vault.name}}</option>
          </select>
        </div>
        <button class="btn btn-danger mt-5" v-if="user.id" @click="addKeep(keep)">Add to my Keeps</button>
        <div class="row justify-content-center">
          <button class="btn btn-warning mt-5" v-if="user.id" @click="goDashboard">Dashboard</button>
          <button class="btn btn-warning mt-5" v-if="!user.id" @click="goHome">Back</button>
        </div>
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

    addKeep(keep) {
      this.$store.dispatch("addKeep", keep);
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