import Vue from "vue";
import Boot from "./Boot.vue"
import Vuetify from 'vuetify'
Vue.use(Vuetify)
new Vue({
    el: "#app-root",
    components: {
        'boot': Boot
    },
    data: () => ({
        test: "chlen"
    })

});