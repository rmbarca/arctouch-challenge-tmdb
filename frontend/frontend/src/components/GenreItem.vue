<template>
    <span :key="genre.id">{{ genre.name }}</span>
</template>

<script>
export default {
  name: "GenreItem",
  props: ["genre"]
};
</script>