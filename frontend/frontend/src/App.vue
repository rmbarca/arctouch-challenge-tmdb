<template>
  <div id="app">
    <img src="./assets/logo.svg" width="30%">
    <router-view/>
    <hr> 
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.search-container{
  position:relative;
    left: 50%;
    width:30em;
    margin-left: -15em; /*set to a negative number 1/2 of your width*/
}
.container {
  width:80%;
  position: relative;
  display: block;
  align-items: center;
  margin-bottom: 10px;
}
.container>img{
  width:100%;
}
.text-block {
  position: absolute;
  bottom: 0px;
  right: 20px;
  left: 20px;
  padding-top: 1em;
  padding-bottom: 1em;
  background-color: black;
  color: white;
  opacity: 0.9;
}
.container-detail {
  width:100%;
  position: relative;
  display: block;
  align-items: center;
}
.text-block-detail {
  position: relative;
  width:100%;
  padding: 1em;
  background-color: white;
  color: black;
  opacity: 0.9;
}
@media only screen and (min-width: 768px) {
  .container {
    width:30%;
  }
  .container>span{
    font-size: 4vw;
  }
}
</style>
