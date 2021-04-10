import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import CreateGrudge from "@/components/CreateGrudge.vue"

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
        props: true 
    },
    {
        path: "/add",
        name: "CreateGrudge",
        component: CreateGrudge
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;