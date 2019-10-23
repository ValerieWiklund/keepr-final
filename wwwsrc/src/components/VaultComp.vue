<template>
  <div class="vault card border-primary" style="width: 100%;">
    <div class="card-body">
      <h5 class="card-title">{{vaultProp.name}}</h5>
      <p class="card-text">{{vaultProp.description}}</p>
      <!-- <a href="#" class="btn btn-primary">Go somewhere</a> -->
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
  methods: {},
  components: {}
};
</script>
<style scoped>
</style>