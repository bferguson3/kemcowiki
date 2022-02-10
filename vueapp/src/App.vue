<template>
  <component :is="currentView" id="app"/>
</template>

<script>
import Index from "/src/components/Index.vue"
import GameCard from '/src/components/Game.vue'
import NotFound from '/src/components/NotFound.vue'

const routes = {
  '/': Index,
  '/game': GameCard,
  '/404': NotFound,
}

export default {
  name: 'App',
  data() {
    return { currentPath: window.location.hash }
  },
  computed: {
    currentView() {
      return routes[this.currentPath.slice(1) || '/'] || NotFound
    }
  },
  mounted() {
    window.addEventListener('hashchange', () => {
		this.currentPath = window.location.hash
	})
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
