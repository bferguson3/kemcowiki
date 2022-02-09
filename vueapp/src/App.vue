<template>
  <div id="app">
    <!--GameCard /-->
    <Index />
  </div>
</template>

<script>
import Index from "/src/components/Index.vue"
//import GameCard from './components/Game.vue'

export default {
  name: 'App',
  components: {
    //GameCard,
    Index
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
