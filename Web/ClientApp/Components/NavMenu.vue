<template>
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
    </nav>
</template>
<script>

</script>