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
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepProp"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteKeep(keep) {
      this.$store.dispatch("deleteKeep", keep);
    }
  },
  components: {}
};
</script>
<style scoped>
</style>