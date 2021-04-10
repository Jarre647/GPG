<template>
    <div class="hello">
        Abusers<br />
        <tb>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    Reason
                </td>
            </tr>
            <tr v-for="item in grudges" :key="item.id">
                <td>
                    {{item.abuserName}}
                </td>
                <td>
                    {{item.reason}}
                </td>
            </tr>
        </tb>
    </div>
</template>

<script>
    export default {
        name: 'Home',
        props: {
            grudges: Array
        }
    }
</script>

<style scoped>
</style>
