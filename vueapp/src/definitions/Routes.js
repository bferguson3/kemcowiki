import GameCard from '/src/components/Game.vue'
import Index from "/src/components/Index.vue"
import NotFound from '/src/components/NotFound.vue'
import URLs from '/src/definitions/URLs'

const routes = [
    { path: URLs.INDEX, component: Index },
    { path: URLs.GAME, component: GameCard },
    { path: URLs.NOTFOUND, component: NotFound },
]

export default routes;