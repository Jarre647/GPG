<template>
    <div style="transform-origin: center top 0px;">
        <div data-app="true" class="v-application v-application--is-ltr theme--light" id="inspire" file="wireframes/inbox">
            <div class="v-application--wrap">
                <div class="v-system-bar v-system-bar--fixed theme--light" style="height: 24px;">
                    <div class="spacer">
                    </div>
                    <i aria-hidden="true" class="v-icon notranslate mdi mdi-square theme--light">
                    </i>
                    <i aria-hidden="true" class="v-icon notranslate mdi mdi-circle theme--light">
                    </i>
                    <i aria-hidden="true" class="v-icon notranslate mdi mdi-triangle theme--light">
                    </i>
                </div>
                <nav-menu/>

            </div>
        </div>
    </div>
</template>

<script>
    import Main from "./Components/Main.vue"
    import NavMenu from "./Components/NavMenu.vue"
    export default {
        data: () => ({
            cards: ['Today', 'Yesterday'],
            drawer: null,
            links: [
                ['mdi-inbox-arrow-down', 'Inbox'],
                ['mdi-send', 'Send'],
                ['mdi-delete', 'Trash'],
                ['mdi-alert-octagon', 'Spam'],
            ],
        }),
        components: {
            "nav-menu": NavMenu
        }
    }
</script>