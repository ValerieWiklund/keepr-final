<template>
  <div class="card-deck p-3">
    <div class="keep card border-primary" style="width: 15rem;">
      <img v-bind:src="`${keepProp.img}`" class="card-img-top" alt="..." />
      <div class="card-body" @click="viewKeep(keepProp)">
        <h5>{{keepProp.name}}</h5>
        <p class="card-text">{{keepProp.description}}</p>
        <p>Keeps: {{keepProp.keeps}}</p>
        <p>Views: {{keepProp.views}}</p>
      </div>
      <div class="card-footer">
        <button
          class="btn btn-primary btn-sm m-2"
          v-if="$route.name ==='vault'"
          @click="removeVaultKeep"
        >Remove from Vault</button>
        <button
          class="btn btn-primary btn-sm m-2"
          v-if="$route.name ==='dashboard'"
          @click="deleteKeep(keepProp)"
        >Delete Keep</button>
      </div>
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
    deleteKeep(keepProp) {
      if (!keepProp.isPrivate) {
        alert("you cannot delete a public keep");
      } else {
        let data = this.keepProp.id;
        this.$store.dispatch("deleteKeep", data);
      }
    },

    addToVault() {
      let data = {
        vaultId: this.$route.params.vaultId,
        keepId: this.keepProp.id
      };
      this.$store.dispatch("createVaultKeep", data);
    },

    viewKeep(keepProp) {
      keepProp.views++;
      debugger;
      this.$store.dispatch("editKeep", keepProp);
      this.$router.push({
        name: "keep",
        params: { keepId: this.keepProp.id }
      });
    },

    removeVaultKeep() {
      let data = {
        vaultId: this.$route.params.vaultId,
        keepId: this.keepProp.id
      };

      this.$store.dispatch("removeVaultKeep", data);
    }
  },
  components: {}
};
</script>
<style scoped>
/* .img{
  height: ;
} */
</style>