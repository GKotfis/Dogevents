<template>
    <div class="app-viewport">
        <md-toolbar class="md-dense">
            <md-layout class="main-menu" md-flex="0" md-hide-small>
                <i class="material-icons">event</i>
                <h2 class="md-title" style="flex: 1" md-hide-xsmall>Dogevents</h2>
            </md-layout>

            <md-input-container style="flex: 1">
                <md-icon >clear</md-icon>
                <vue-google-autocomplete id="map" classname="location md-input md-theme-default" placeholder="" v-on:placechanged="getAddressData"
                    types="geocode" country="pl" v-on:enter="" />
            </md-input-container>

            <md-button class="md-icon-button md-accent" @click.native="toggleSearchMenu">
                <md-icon>search</md-icon>
            </md-button>
        </md-toolbar>
        <md-sidenav class="md-left" ref="searchSideNav">
            <md-toolbar>
                <div class="md-toolbar-container">
                    <h3 class="md-title">Szukaj wydarzeń</h3>
                </div>
            </md-toolbar>
            <searchNav />
            <md-button class="md-raised md-accent" @click.native="closeSearchSideNav">
                <md-icon>close</md-icon>
            </md-button>
        </md-sidenav>
        <main>
            <popular />
            <justadded />
        </main>

        <md-layout md-hide-medium-and-up md-align="center">
            <md-bottom-bar class="bottom-fixed">
                <md-bottom-bar-item md-icon="event">Kalendarz</md-bottom-bar-item>
                <md-bottom-bar-item md-icon="near_me">W okolicy</md-bottom-bar-item>
                <md-bottom-bar-item md-icon="share" md-active>Podaj dalej</md-bottom-bar-item>
            </md-bottom-bar>
        </md-layout>
    </div>
</template>

<script>
    import Vue from 'vue'
    import VueMaterial from 'vue-material'
    import popular from './components/Popular.vue'
    import justadded from './components/JustAdded.vue'
    import searchNav from './components/SearchNav.vue'
    import VueGoogleAutocomplete from 'vue-google-autocomplete'

    export default {
        data: function () {
            return {
                address: ''
            }
        },
        components: {
            popular,
            justadded,
            searchNav,
            VueGoogleAutocomplete
        },
        methods: {
            toggleSearchMenu() {
                this.$refs.searchSideNav.toggle();
            },
            closeSearchSideNav() {
                this.$refs.searchSideNav.close();
            },
            getAddressData: function (addressData, placeResultData) {
                this.address = addressData;
            }

        }
    }

</script>

<style scoped>
    .app-viewport {
        display: flex;
        flex-flow: column;
    }

    .bottom-fixed {
        position: relative;
        /*bottom: 0;*/
        z-index: 1000;
    }

    .location {
        font-size: small;
    }
</style>