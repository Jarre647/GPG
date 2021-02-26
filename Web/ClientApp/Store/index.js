import Vue from "vue";
import Vuex from 'vuex'
import grudgesModule from "./modules/grudges/grudges-module"

Vue.use(Vuex)

export const store = new Vuex.Store({
    modules: {
        grudges: grudgesModule
    }
});