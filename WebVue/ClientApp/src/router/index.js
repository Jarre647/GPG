import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Report from "@/components/Report.vue";
import Login from "@/components/Login.vue";
import Register from "@/components/Register.vue"

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
    },
    {
        path: "/login",
        name: "Login",
        component: Login
    },
    {
        path: "/register",
        name: "Register",
        component: Register
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;