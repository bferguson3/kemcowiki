<template>
<div>
  <component :is="currentView" id="app"/>
</div>
</template>

<script>
import Index from "/src/components/Index.vue"
import GameCard from '/src/components/Game.vue'
import NotFound from '/src/components/NotFound.vue'

const routes = [
  { path: '', component: Index },
  { path: 'game', component: GameCard },
  { path: '404', component: NotFound },
]

export default {
  name: 'App',
  data() {
    return { currentPath: window.location.hash }
  },
  computed: {
    currentView() {
      if (window.location.pathname.includes('game')){
        return GameCard;
      }

      for(var i=0; i < routes.length; i++){ 
        if ('/' + routes[i].path == window.location.pathname)
            return routes[i].component;
      }
      
      return NotFound;
    }
  },
  methods: {
    changeHash: function() {  
      this.currentPath = window.location.hash;
    }
  },
  mounted() {
    window.addEventListener('hashchange', this.changeHash());
    
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
