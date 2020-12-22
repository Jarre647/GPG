import axios from 'axios'
export const actions = {
    async fetchGrudges({ commit }) {
        await axios
            .get("/grudges")
            .then(response => {
                commit("updateGrudges", response);
            });
    }
}