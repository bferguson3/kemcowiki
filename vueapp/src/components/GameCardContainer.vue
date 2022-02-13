<script>

class GameCardContainer {
    // constructor override
    constructor() {
        return self;
    }
    GameCardContainer() {
        
    }
    data() { 
        return { 
            gameTitle: "",
            romanizedTitle: "",
            series: "",
            sharedMechanics: [],
            avgPlayLength: "",
            boxArtURL:""
        }
    }
    
}
export default GameCardContainer;
</script>