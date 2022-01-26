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
            <div class="box is-card-image">
                <div class="game-image"><img src="franeheader.jpg"></div>
                <div class="box is-game-details">
                    <div class="teensytext">GAME TITLE</div>
                        <div class="game-name-text">フラン</div>
                    <div class="teensytext">ROMANIZATION</div>
                        <div class="game-name-text">Lost Memory of Angel ~ Frane</div>
                    <div class="teensytext">SERIES</div>
                        <div class="smallertext"><a>Frane</a></div>
                    <div class="teensytext">SHARED MECHANICS</div>
                        <div class="smallertext"><a href="">Heroine feeding</a>,<a href="">bump combat</a>
                        </div> 
                    <div class="teensytext">AVG PLAY LENGTH</div>
                    07:45:00
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

    let endpoint = 'https://localhost:7128/Game/Frane';

    export default { 
        name: "GameCard",
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
        },
        created: function() {
            this.test();
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