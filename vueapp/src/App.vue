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
      let np = new String(window.location.pathname);
      np = np.toLowerCase();
      
      if (np.includes('game'))
        return GameCard;
      
      for(var i=0; i < routes.length; i++){ 
          if (routes[i].path == undefined)
            return Index;

          if (new String('/' + routes[i].path).toLowerCase() == np)
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
