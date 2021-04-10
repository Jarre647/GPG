<template>
    <tb>
        Abusers<br />
        <tr>
            <th>
                Name
            </th>
            <th>
                Reason
            </th>
        </tr>
        <tbody>
            <tr v-for="item in grudges" :key="item.id">
                <td>
                    {{item.abuserName}}
                </td>
                <td>
                    {{item.reason}}
                </td>
            </tr>
        </tbody>
    </tb>
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
    td{
        padding:5px;
        border-bottom:solid;
    }
</style>
