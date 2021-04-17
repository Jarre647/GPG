<template>
    <div>
        <h3>Register</h3>
        <label>Email</label>
        <input v-model="email" />
        <label>Password</label>
        <input v-model="password" />
        <label>Confirm password</label>
        <input v-model="confirmPassword" />
        <label>Nick Name</label>
        <input v-model="nickName" />
        <label>Phone number</label>
        <input v-model="phoneNumber" />
        <button v-on:click="send">Register</button>
    </div>
</template>
<script>
    import axios from 'axios'
    export default {
        name: "Register",
        data() {
            return {
                email: "",
                password: "",
                confirmPassword: "",
                nickName: "",
                phoneNumber: ""
            }
        },
        methods: {
            send: async function () {
                await axios
                    .post("/api/account/register", {
                        Email: this.email,
                        Password: this.password,
                        ConfirmPassword: this.confirmPassword,
                        NickName: this.nickName,
                        PhoneNumber: this.phoneNumber
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