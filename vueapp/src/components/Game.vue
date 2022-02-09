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
                <div class="button is-card-image is-loading" id="card-loader">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <div class="game-image"><img id="game-image-src" src=""></div>
                    <div class="box is-game-details">
                        <div class="teensytext">GAME TITLE</div>
                            <div class="game-name-text" id="game-title-text">?</div>
                        <div class="teensytext">ROMANIZATION</div>
                            <div class="game-name-text" id="romanized-title">?</div>
                        <div class="teensytext">SERIES</div>
                            <div class="smallertext" id="series-name"><a>?</a></div>
                        <div class="teensytext">SHARED MECHANICS</div>
                            <div class="smallertext" id="shared-mechanics-list">?</div> 
                        <div class="teensytext">AVG PLAY LENGTH</div>
                        <div id="avg-play-length">?</div>
                    </div>
                    a
                </div>
                b
            </div>
            <div class="box is-full-card">
                <div class="box is-info-box"><h2>General Summary</h2>Summary goes here</div>
            </div>
        </div>
        d
        </div>
        e
    </div>
    </div>
</div>

</template>

<script> 
    import axios from "axios";
    import URLs from "../definitions/URLs.vue";
    import GameCardContainer from "./GameCardContainer.vue";
    
    //let endpoint = 'https://localhost:7128/Game/0fe5685a-4171-7141-41b9-a8313d252268';

    let endpoint = null;
    let gcc = new GameCardContainer();
    //let response = JSON.stringify("");
    let searchId = "";
    //let found = true;

    export default { 
        name: "GameCard",
        methods: {
            async loadCard() {
                const urlParams = new URLSearchParams(window.location.search);
                searchId = urlParams.get("id");
                if(searchId == null)
                    searchId = urlParams.get("name");

                endpoint = URLs.LOCALROOT + URLs.GAME + searchId;
                endpoint = endpoint.toLowerCase();

                return axios.get(endpoint);
            }            
        },
        created: function() {
            let p = this.loadCard() // returns P<Game>
                .then( async function(resp) {
                    gcc.romanizedTitle = resp.data.romanizedTitle;
                    gcc.gameTitle = resp.data.title;
                    gcc.series = resp.data.series;
                    gcc.sharedMechanics = resp.data.sharedMechanics;
                    gcc.avgPlayLength = resp.data.averagePlayLength;
                    gcc.boxArtURL = resp.data.boxArtURL;
                    return resp;
                });
            Promise.all([p]).then(function(r) { 
                console.log(r[0]);
                if(r[0].status == 204)
                {
                    alert("ID not found.");
                    return;
                }
                // Fill out card
                const gameTitle = document.getElementById("game-title-text");
                gameTitle.textContent = gcc.gameTitle;

                const rom = document.getElementById("romanized-title");
                rom.textContent = gcc.romanizedTitle;

                const series = document.getElementById("series-name");
                series.textContent = gcc.series.name;

                const mechs = document.getElementById("shared-mechanics-list");
                let newstr = "";
                for (let j=0; j < gcc.sharedMechanics.length; j++)
                {
                    newstr += gcc.sharedMechanics[j].name + ", ";
                }
                mechs.textContent = newstr;

                const apl = document.getElementById("avg-play-length");
                apl.textContent = gcc.avgPlayLength;

                const cl = document.getElementById("game-image-src");
                cl.src = gcc.boxArtURL;
                
                const ldr = document.getElementById("card-loader");
                ldr.className = "box is-card-image";
                //
                // Load data points
                // TODO 
                
            });
        },
        mounted() {

        }
    }
</script> 
