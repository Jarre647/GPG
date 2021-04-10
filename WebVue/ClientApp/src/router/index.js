import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Report from "@/components/Report.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
        props: true 
    },
    {
        path: "/report",
        name: "Report",
        component: Report
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;