<template> 

<div>
    
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
        <Footer />
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
import Footer from "/src/components/Footer.vue";

export default { 
    name: "NotFound",
    methods: {
        async loadPage() {
            return 0;
        }            
    },
    components: {
        Footer,
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