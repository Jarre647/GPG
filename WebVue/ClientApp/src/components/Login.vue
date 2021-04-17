<template>
    <div>
        <h3>Login</h3>
        <label>Email</label>
        <input v-model="email" />
        <label>Password</label>
        <input v-model="password" />
        <label>Remember me?</label>
        <input v-model="rememberMe" type="checkbox" />
        <button v-on:click="send">Login</button>
    </div>
</template>
<script>
    import axios from 'axios'
    export default {
        name: "Login",
        data() {
            return {
                email: "",
                password: "",
                rememberMe: false
            }
        },
        methods: {
            send: async function () {
                await axios
                    .post("/api/account/login", {
                        Email: this.email,
                        Password: this.password,
                        RememberMe: this.rememberMe
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