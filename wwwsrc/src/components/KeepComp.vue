<template>
  <div class="keep" style="width: 18rem;">
    <img v-bind:src="`${keepProp.image}`" class="card-img-top" alt="..." />
    <div class="card-body">
      <h3>{{keepProp.name}}</h3>
      <p class="card-text">{{keepProp.description}}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepProp"]
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