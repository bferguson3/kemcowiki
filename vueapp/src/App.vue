<template>
<div>
  <component :is="currentView" id="app"/>
</div>
</template>

<script>
import Index from "/src/components/Index.vue"
import GameCard from '/src/components/Game.vue'
import NotFound from '/src/components/NotFound.vue'
import URLs from '/src/definitions/URLs'

const routes = [
  { path: URLs.INDEX, component: Index },
  { path: URLs.GAME, component: GameCard },
  { path: URLs.NOTFOUND, component: NotFound },
]

export default {
  name: 'App',

  data() {
    return { currentPath: window.location.hash }
  },

  computed: {
    currentView() {
      for (let i = 0; i < routes.length; i++){
          if (routes[i].path == this.currentPath){
              return routes[i].component;
          }
      }
      return NotFound;
    }
  },

  methods: {

  },

  mounted() {
    window.addEventListener('hashchange', ()=> { 
        this.currentPath = window.location.hash;
    });
    
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
