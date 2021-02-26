<template>
    <div> <!--тут можно тоже использовать фрагмент, но надо его импортировать-->
        <p>Поиск по имени</p>
        <input />
        <list-grudge v-for="item in grudge"
                     :abuserName="item.abuserName"
                     :reason="item.reason">

        </list-grudge>
    </div>
</template>

<script>
    import createGrudge from "./Components/CreateGrudge.vue"
    import listGrudge from "./Components/ListGrudge.vue"

    export default {
        data: function () {
            return {
                grudges: Object
            }
        },
        components: {
            "create-grudge": createGrudge,
            "list-grudge": listGrudge
        },
        beforeCreate: async function () {
            await axios
                .get("http://localhost:44369/api/grudges")
                .then(response => {
                    this.grudges = response.data
                });
        }
    }
</script>