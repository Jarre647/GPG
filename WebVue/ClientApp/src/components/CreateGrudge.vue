<template>
    <div>
        <h3>Name abuser</h3>
        <input v-model="name" />
        <h3>Reason</h3>
        <input v-model="reason" />
        <button v-on:click="send">
            Send
        </button>
    </div>
</template>
<script>
    import axios from 'axios'
    export default {
        name: "CreateGrudge",
        data() {
            return {
                name: "",
                reason: ""
            }
        },
        methods: {
            send: async function () {
                await axios
                    .post("/api/grudges", {
                        AbuserName: this.name,
                        Reason: this.reason
                    })
                    .then(response => {
                        console.log(response)
                    })
                    .catch(function (error) {
                        console.log(error)
                    });
            }
        }
    }
</script>