<template> 
<div class="columns is-mobile">
  <div class="column is-1">
      <div class="box" style="height: 1024px" align="left">[X]</div>
  </div>
  <div class="column is-11">
      <button class="button" @click="test">Get Games List</button>
  </div>
</div>
</template>

<script> 
    import axios from "axios";

    let endpoint = 'https://localhost:7128/Game';

    export default { 
        name: "Users",
        methods: {
            test() {
                axios
                .get(endpoint)
                .then(function(resp)
                { 
                    console.log(resp); 
                })
                .catch(function(err)
                { 
                    alert(err); 
                });
            }
        }
    }
</script> 

<style> 
h3 {
    margin-bottom: 5%
}
</style>