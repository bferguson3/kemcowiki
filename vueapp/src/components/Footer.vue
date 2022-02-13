
<template>
<div>
    <center>
        <!-- TODO: Change these URLs to global constants-->
        <nav class="footer-nav">
            <a id="home-nav">Home</a>&emsp;|&emsp;
            <a id="game-nav">Games</a>&emsp;|&emsp;
            <a href="https://discord.gg/JDa7GrpuHC" target="_blank">Discord</a>&emsp;|&emsp;
            <a href="http://www.rpginsanity.com" target="_blank">RPGInsanity</a>&emsp;|&emsp;
            <a id="contact-nav">Contact</a>&emsp;
        </nav>
    </center>
</div>
</template>

<script> 
import URLs from '/src/definitions/URLs.vue'

export default { 
    name: "Footer",

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
            document.getElementById("home-nav").setAttribute('href', URLs.INDEX);
            document.getElementById("game-nav").setAttribute('href', URLs.GAME);
            document.getElementById("contact-nav").setAttribute('href', URLs.NOTFOUND);
            
            console.log(r[0]);
            
        });
    },

    mounted() {

    }
}
</script>
<style>
    .footer-nav {
        text-align: center;
        background-color: rgb(223, 234, 255);
        margin: 0 0 0 0;
        padding: 1% 8% 1% 8%;
        border-width: 5px;
        border-style: outset;
        border-color: rgb(233, 114, 159);
        border-radius: 8px 4px 6px 12px;
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        font-size: small;
    }
    
    .footer-nav a {
        color: rgb(74, 71, 173);
        font-weight: bold;
        text-decoration: none;
    }
</style>
