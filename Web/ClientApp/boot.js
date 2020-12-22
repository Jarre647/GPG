import Vue from "vue";
import Boot from "./Boot.vue"


new Vue({
    el: "#app-root",
    components: {
        'boot': Boot
    },
    data: () => ({
        test: "chlen"
    })

});