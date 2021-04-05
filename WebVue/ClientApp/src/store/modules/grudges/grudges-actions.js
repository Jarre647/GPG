export const actions = {
    async fetchGrudges({ commit }) {
        await axios
            .get("/api/grudges")
            .then(response => {
                const result = response.data;
                commit("updateGrudges", result);
            });
    }
}