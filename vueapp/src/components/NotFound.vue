<template> 

<div class="index">
    
    <header>
        a
    </header>

    <aside class="nav-menu"> 
        x
    </aside>
    
    <section>
        <h2>404 Not Found</h2>
    </section>
    
    <footer>
        e 
        <nav class="footer-nav">
            <a href="index.html">Home</a>&emsp;
            <a href="#/game">Games</a>&emsp;
            <a href="mailto:admin@kemcowiki.com">Contact</a>&emsp;
            <a href="http://www.rpginsanity.com" target="_blank">RPG Insanity</a>            
        </nav>
    </footer>
</div>

</template>

<style scoped>
h2 { 
    text-align: center;
    text-decoration: none;
    font-size: 200%;
}
</style>

<script> 
//import axios from "axios";
//import URLs from "../definitions/URLs.vue";

export default { 
    name: "NotFound",
    methods: {
        async loadPage() {
            return 0;
        }            
    },
    created: function() {
        let p = this.loadPage() // returns P<Game>
            .then( async function(resp) {
                return resp;
            });
        Promise.all([p]).then(function(r) { 
            console.log(r[0]);
            
        });
    },
    mounted() {

    }
}


</script>