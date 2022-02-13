import { createRouter, createWebHistory } from "vue-router";
import { createApp } from "vue";

import App from './App.vue'

//Vue.config.productionTip = false

import routes from '/src/definitions/Routes.js'

const router = createRouter({
    history: createWebHistory(),
    routes
});

const app = createApp(App);
app.use(router);
app.mount("#app");