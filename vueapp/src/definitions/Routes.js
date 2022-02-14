import GameCard from '/src/components/Game.vue'
import Index from "/src/components/Index.vue"
import NotFound from '/src/components/NotFound.vue'
import URLs from '/src/definitions/URLs'
import NewGame from '/src/components/NewGame'

const routes = [
    { path: URLs.INDEX, component: Index },
    { path: URLs.GAME, component: GameCard },
    { path: URLs.NOTFOUND, component: NotFound },
    { path: URLs.NEWGAME, component: NewGame },
]

export default routes;