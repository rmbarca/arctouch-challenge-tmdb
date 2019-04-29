<template>
  <div class="search-container"> 
    <input id="search-input2" type="text" :placeholder="hintText" v-model="searchText">
  </div>
</template>

<script>
export default {
  name: "SearchMovie",
  data() {
    return {
      searchText: "",
      hintText: "Search for an upcoming movie"
    };
  }
};
</script>