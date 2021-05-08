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
        props: true,
        meta: { requiresAuth: false }
    },
    {
        path: "/report",
        name: "Report",
        component: Report,
        meta: { requiresAuth: true }
    },
    {
        path: "/login",
        name: "Login",
        component: Login,
        meta: { requiresAuth: false }
    },
    {
        path: "/register",
        name: "Register",
        component: Register,
        meta: { requiresAuth: false }
    }
];


const router = createRouter({
    history: createWebHistory(),
    routes
});

const isAuthenticated = !!(getCookie(".AspNetCore.Identity.Application"));
console.log(document.cookie)
alert(document.cookie); 
router.beforeEach((to, from, next) => {
    if (to.matched.some((route) => route.meta?.requiresAuth)) {
        console.log(getCookie(".AspNetCore.Identity.Application"))
        console.log(isAuthenticated)
        if (isAuthenticated) {
            console.log(1)
            next();
        } else {
            console.log(2)
            next("/login");
        }
    } else {
        next();
    }
});

function getCookie(name) {
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}

export default router;