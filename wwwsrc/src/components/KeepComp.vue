<template>
  <div class="keep card border-primary" style="width: 100%;">
    <img v-bind:src="`${keepProp.img}`" class="card-img-top" alt="..." />
    <div class="card-body">
      <h3>{{keepProp.name}}</h3>
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
  methods: {},
  components: {}
};
</script>
<style scoped>
</style>