<template> 

<div class="index">
    <header>
        a
    </header>

    <section>
        b
        Search for a <span id="green-text">Kemco</span> game by name:
        <article>
            c 
        </article>
    </section>
    
    <aside> 
        d 
    </aside>
    
    <footer>
        e 
        <nav class="footer-nav">
            <a href="index.html">Home</a>&emsp;
            <a href="mailto:admin@kemcowiki.com">Contact</a>&emsp;
            <a href="http://www.rpginsanity.com" target="_blank">RPG Insanity</a>            
        </nav>
    </footer>
</div>

</template>

<script> 
//import axios from "axios";
//import URLs from "../definitions/URLs.vue";

export default { 
    name: "Index",
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