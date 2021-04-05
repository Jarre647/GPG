import grudgesModule from "./modules/grudges/grudges-module"

export const store = new Vuex.Store({
    modules: {
        grudges: grudgesModule
    }
});