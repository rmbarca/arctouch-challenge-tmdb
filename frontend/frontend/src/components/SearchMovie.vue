<template>
  <!--<form @submit="submit">-->
  <form>
    <fieldset>
      <input type="text" placeholder="Search movie" v-model="search_field">
    </fieldset>
    <input class="button-primary" type="submit" value="Send">
  </form>
</template>

<script>
export default {
  name: "SearchMovie",
  data() {
    return {
      search_field: ""
    };
  }
};
</script>