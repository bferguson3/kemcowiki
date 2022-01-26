<template>
  <div id="app">
    <GameCard />
  </div>
</template>

<script>
import GameCard from './components/Game.vue'

//require("./new.scss");

export default {
  name: 'App',
  components: {
    GameCard
  }
}
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
