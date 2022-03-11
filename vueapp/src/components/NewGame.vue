<template> 
<div>
    <div class="columns base-column">
    <div class="column">
        <p class="teensytext">KEMCO WIKI TEST</p>
        <div class="columns is-mobile">
        <div class="column is-1">
            <p class="box is-info">X</p>
        </div>
        <div class="column is-11">
            <div class="box is-full-card">
                <div class="button is-card-image " id="card-loader"></div>
                    <div class="game-image"><img id="game-image-src" src=""></div>
                    <div class="box is-game-details">
                        <div class="teensytext">GAME TITLE <a class="help-button">&nbsp;?&nbsp; </a></div>
                            <input class="game-name-text" id="game-title-text">
                        <div class="teensytext">ROMANIZATION<a class="help-button">&nbsp;?&nbsp; </a></div>
                            <input class="game-name-text" style="font-size:80%" id="romanized-title">
                        <div class="teensytext">SERIES<a class="help-button">&nbsp;?&nbsp; </a></div>
                            <input class="smallertext" id="series-name">
                        <div class="teensytext">SHARED MECHANICS<a class="help-button">&nbsp;?&nbsp; </a></div>
                            <input class="smallertext" id="shared-mechanics-list"> 
                        <div class="teensytext">YOUR PLAY LENGTH<a class="help-button">&nbsp;?&nbsp; </a></div>
                        <div id="avg-play-length">?</div>
                    
                    a<br>
                    <div class="button" ref="submit-new-game" v-on:click="submitNew">Submit</div>
                </div>
                b
            </div>
            <div class="box is-full-card">
                <div class="box is-info-box"><h2>y</h2>e</div>
            </div>
        </div>
        d
        </div>
        e
    </div>
    </div>
    <footer>
        <Footer />
    </footer>
</div>

</template>

<script> 
    import Footer from "/src/components/Footer.vue";    
    import URLs from "/src/definitions/URLs.vue";
    import axios from "axios";

    export default { 
        name: "NewGame",

        components:{
            Footer
        },
        
        methods: {
            async loadCard() {
                /*
                const urlParams = new URLSearchParams(window.location.search);
                
                searchId = urlParams.get("id");
                if(searchId == null)
                    searchId = urlParams.get("name");

                endpoint = URLs.LOCALROOT + URLs.GAMEAPI + searchId;
                endpoint = endpoint.toLowerCase();

                return axios.get(endpoint);
                */
            },
            async submitNew() 
            { 
                console.log("OK");

                let endpoint = URLs.LOCALROOT + URLs.GAMEAPI;
                console.log(endpoint);

                return axios.post(endpoint, {
                    Id: '0000',
                    Title: 'New Game'
                }, 
                { 
                    headers: {
                        'Access-Control-Allow-Origin':['http://localhost:1024','https://localhost:5001/api/Game/']
                    }
                });
                /*.then(function (r){
                    console.log(r);
                })
                .catch(function (e){
                    console.log('exception' + e);
                });
                */
            }
        },

        created: function() {
            let p = this.loadCard() // returns P<Game>
                .then( async function(resp) {

                    return resp;
                }
            );
            Promise.all([p])
                .then(function(r) { 
                    console.log(r[0]);
                }
            );
            
        },

        mounted() {

        }
    }
</script> 