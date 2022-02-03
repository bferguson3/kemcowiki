<script>
import Vue from 'vue'

class GameCardContainer extends Vue {
    // constructor override
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