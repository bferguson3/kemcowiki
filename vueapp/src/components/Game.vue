<template> 
<div class="columns base-column">
  <div class="column">
    <p class="teensytext">KEMCO WIKI TEST</p>
    <div class="columns is-mobile">
      <div class="column is-1">
        <p class="box is-info">X</p>
      </div>
      <div class="column is-11">
        <div class="box is-full-card">
            <!--div class="box is-card-image is-loading"-->
            <div class="button is-card-image is-loading">You should never see this text ever ever ever.
                <div class="game-image"><img src="franeheader.jpg"></div>
                <div class="box is-game-details">
                    <div class="teensytext">GAME TITLE</div>
                        <div class="game-name-text">?</div>
                    <div class="teensytext">ROMANIZATION</div>
                        <div class="game-name-text">?</div>
                    <div class="teensytext">SERIES</div>
                        <div class="smallertext"><a>?</a></div>
                    <div class="teensytext">SHARED MECHANICS</div>
                        <div class="smallertext"><a href="">?</a>, <a href="">?</a>
                        </div> 
                    <div class="teensytext">AVG PLAY LENGTH</div>
                    ?
                </div>
                a
            </div>
            b
        </div>
        <div class="box is-full-card">
            <div class="box is-info-box"><h2>General Summary</h2>Frane is a game about giving an angel too much food until she kills everything.</div>
        </div>
      </div>
      d
    </div>
    e
  </div>
</div>
</template>

<script> 
    import axios from "axios";
    import URLs from "../definitions/URLs.vue";
    //let endpoint = 'https://localhost:7128/Game/0fe5685a-4171-7141-41b9-a8313d252268';

    let endpoint = null;
    let response = JSON.stringify("");
    let searchId = "";
    let found = true;


    export default { 
        name: "GameCard",
        methods: {
            loadCard() {
                const urlParams = new URLSearchParams(window.location.search);
                
                searchId = urlParams.get("id");
                if(searchId == null)
                    searchId = urlParams.get("name");

                endpoint = URLs.LOCALROOT + URLs.GAME + searchId;

                axios
                    .get(endpoint)
                    .then(function(resp)
                    { 
                        response = resp;
                        console.log(response);
                        if (response.status == 204)
                            found = false;
                    })
                    .then(function(resp){
                        console.log(resp);
                        if(!found){
                            console.log("Searching stubs by name...");
                            endpoint = URLs.LOCALROOT + URLs.DATASTUB + searchId;
                            axios 
                                .get(endpoint)
                                .then(function (resp){
                                    console.log(resp);
                                })
                                .catch(function(err) { 
                                    console.log(err);
                            });
                            console.log(endpoint);
                            
                        }
                    })
                    .catch(function(err)
                    { 
                        alert(err); 
                });
                console.log("fall");
                
            }
        },
        created: function() {
            this.loadCard();
        },
        mounted() {

        }
    }
</script> 

<style> 
h2{
    font-size:120%;
    font-weight: bold;
    text-align: left;
    text-decoration: underline;
    padding-bottom:2%;
}
/* images */
.game-image{
    margin-bottom:-50%;
}
/* text */
.teensytext{
    font-size: 60%;
}
.smallertext{
    font-size:80%;
    font-family:serif;
}
.game-name-text{
    font-size:150%;
    font-weight: bold;
}
/* spacers */
.block.has-left-border{
    margin-left:5%;
    width:100%;
}
.columns.base-column{
    margin-top:-7%;
}
/* boxes */
.button.is-card-image{
    width:40%;
    padding-top:20%;
    padding-bottom:20%;
    
}
.box.is-card-image{
    width:40%;
}
.box.is-full-card{
    margin-left:0%;
    width:100%;
    background-color: cornflowerblue;
    max-width:650px;
    display:flex;
}
.box.is-warning {
    background-color:rgb(248, 255, 122);
}
.box.is-game-details { 
    margin-left:120%;
    width:180%;
    text-align:left;
    margin-top:-5%;
    max-width:350px
}
.box.is-info-box{
    text-align:left;
}
/* buttons */
.button.has-left-border{
    margin-left:5%;
}

</style>