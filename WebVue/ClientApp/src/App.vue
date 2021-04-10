<template>
    <nav-menu></nav-menu>
    <router-view :grudges ="grudges"/>
</template>

<script>
    import NavMenu from './components/NavMenu.vue'
    import axios from 'axios'

    export default {
        name: 'App',
        components: {
            NavMenu
        },
        data() {
            return {
                grudges: []
            }
        },
        beforeCreate: async function () {
            await axios
                .get("/api/grudges")
                .then(response => {
                    this.grudges = response.data;
                })
                .catch(function (error) {
                    console.log(error)
                });
        }
    }
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>
