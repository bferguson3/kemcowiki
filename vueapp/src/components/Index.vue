<template> 

<div class="index">
    
    <header>
        a
    </header>

    <aside class="nav-menu"> 
        x
    </aside>
    
    <section>
        b
        Search for a <span id="green-text">Kemco</span> game by name: <br>
        <span class="search-bar" >asdf</span><a class="search-btn">Search</a>
        <article>
            c 
        </article>
    </section>
    
    <footer>
        <center>
        <Footer class="footer" />
        </center>
    </footer>
</div>

</template>

<script> 
import Footer from "/src/components/Footer.vue"

export default { 
    name: "Index",
    components: { 
        Footer
    },
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
            document.title = "KemcoWiki - Under Construction"
        });
    },
    mounted() {

    }
}


</script>