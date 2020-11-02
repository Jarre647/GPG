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
                <nav class="v-navigation-drawer v-navigation-drawer--fixed v-navigation-drawer--open theme--light"
                     data-booted="true"
                     style="height: 100vh;
top: 24px; transform: translateX(0%); width: 256px; max-height: calc(100% - 24px);">
                    <div class="v-navigation-drawer__content">
                        <div class="pa-4 v-sheet theme--light grey lighten-4">
                            <div class="v-avatar mb-4 grey darken-1" style="height: 64px; min-width: 64px; width: 64px;">
                            </div>
                            <div>john@vuetifyjs.com</div>
                        </div>
                        <hr role="separator" aria-orientation="horizontal" class="v-divider theme--light">
                        <div class="v-list v-sheet theme--light">
                            <div tabindex="0" class="v-list-item v-list-item--link theme--light">
                                <div class="v-list-item__icon">
                                    <i aria-hidden="true" class="v-icon notranslate mdi mdi-inbox-arrow-down theme--light">
                                    </i>
                                </div>
                                <div class="v-list-item__content">
                                    <div class="v-list-item__title">
                                        Inbox
                                    </div>
                                </div>
                            </div>
                            <div tabindex="0" class="v-list-item v-list-item--link theme--light">
                                <div class="v-list-item__icon">
                                    <i aria-hidden="true" class="v-icon notranslate mdi mdi-send theme--light">
                                    </i>
                                </div>
                                <div class="v-list-item__content">
                                    <div class="v-list-item__title">
                                        Send
                                    </div>
                                </div>
                            </div>
                            <div tabindex="0" class="v-list-item v-list-item--link theme--light">
                                <div class="v-list-item__icon">
                                    <i aria-hidden="true" class="v-icon notranslate mdi mdi-delete theme--light">
                                    </i>
                                </div>
                                <div class="v-list-item__content">
                                    <div class="v-list-item__title">
                                        Trash
                                    </div>
                                </div>
                            </div>
                            <div tabindex="0" class="v-list-item v-list-item--link theme--light">
                                <div class="v-list-item__icon">
                                    <i aria-hidden="true" class="v-icon notranslate mdi mdi-alert-octagon theme--light">
                                    </i>
                                </div>
                                <div class="v-list-item__content">
                                    <div class="v-list-item__title">
                                        Spam
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="v-navigation-drawer__border">
                    </div>
                </nav><main class="v-main" data-booted="true" style="padding: 24px 0px 0px 256px;">
                    <div class="v-main__wrap">
                        <div class="container py-8 px-6 container--fluid">
                            <div class="row">
                                <div class="col col-12">
                                    <div class="v-card v-sheet theme--light">
                                        <div class="v-subheader theme--light">
                                            Today
                                        </div>
                                        <div role="list" class="v-list v-sheet theme--light v-list--two-line">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 1
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 2
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 3
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 4
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 5
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 6
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div><!---->
                                        </div>
                                    </div>
                                </div>
                                <div class="col col-12">
                                    <div class="v-card v-sheet theme--light">
                                        <div class="v-subheader theme--light">
                                            Yesterday
                                        </div>
                                        <div role="list" class="v-list v-sheet theme--light v-list--two-line">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 1
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 2
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 3
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 4
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 5
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div>
                                            <hr role="separator" aria-orientation="horizontal" class="v-divider v-divider--inset theme--light">
                                            <div tabindex="-1" role="listitem" class="v-list-item theme--light">
                                                <div class="v-avatar v-list-item__avatar grey darken-1" style="height: 40px; min-width: 40px; width: 40px;">
                                                </div>
                                                <div class="v-list-item__content">
                                                    <div class="v-list-item__title">
                                                        Message 6
                                                    </div>
                                                    <div class="v-list-item__subtitle">
                                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique
                                                    </div>
                                                </div>
                                            </div><!---->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
        </div>
    </div>
</template>

<script>
    import MainMenu from "./Components/MainMenu.vue"
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
            "main-menu": MainMenu
        }
    }
</script>