<template>
<div>
  <component :is="currentView" id="app"/>
</div>
</template>

<script>
import Routes from '/src/definitions/Routes.js'
import Index from "/src/components/Index.vue"

export default {
  name: 'App',

  data() {
    return { currentPath: window.location.pathname }
  },

  computed: {
    currentView() {
      console.log(window.location);
      for (let i = 0; i < Routes.length; i++){
          if (Routes[i].path == this.currentPath){
              return Routes[i].component;
          }
      }
      //return NotFound;
      return Index;
      }
  },

  methods: {

  },

  mounted() {

    window.addEventListener('hashchange', ()=> { 
        this.currentPath = window.location.pathname;
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
  margin-top: 8%;
}
</style>
