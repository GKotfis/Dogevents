<template>
    <div class="app-viewport">
        <md-toolbar class="md-dense">
            <md-layout class="main-menu" md-flex="0" md-hide-small>
                <i class="material-icons">event</i>
                <h2 class="md-title" style="flex: 1" md-hide-xsmall>Dogevents</h2>
            </md-layout>
    
            <md-input-container style="flex: 1">
                <md-icon>clear</md-icon>
                <!--<md-input @focus="selectText" />
                <input @focus="selectText" />-->
                <vue-google-autocomplete id="map" classname="location md-input md-theme-default" placeholder="dowolna lokalizacja" @placechanged="getAddressData" types="geocode" country="pl" @click.native="selectText"/>
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
            <md-theme class="complete-example">
            <md-button class="md-fab">
                <md-icon v-if="!done">pets</md-icon>
            </md-button>
            <md-spinner :md-size="74" :md-stroke="2.2" :md-progress="progress" v-if="transition && progress < 115"></md-spinner>
            </md-theme>
            <popular />
            <incoming />
            <justadded />
            <eventDetails />
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
import incoming from './components/Incoming.vue'
import justadded from './components/JustAdded.vue'
import searchNav from './components/SearchNav.vue'
import VueGoogleAutocomplete from 'vue-google-autocomplete'
import eventDetails from './components/EventDetails.vue'
import EventBus from './main'

export default {
    data: function () {
        return {
            address: '',
            progress: 0,
            progressInterval: null,
            done: false,
            transition: true
        }
    },
    components: {
        popular,
        incoming,
        justadded,
        eventDetails,
        searchNav,
        VueGoogleAutocomplete
    },
    created() {

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
            EventBus.$emit('CHANGE_LOCATION', { location: addressData });
        },
        selectText: function () {
            console.log(this.$target)
        },
         startProgress() {
      this.progressInterval = window.setInterval(() => {
        this.progress += 3;

        if (this.progress > 115) {
          this.done = true;
          window.clearInterval(this.progressInterval);
          window.setTimeout(() => {
            this.done = false;
          }, 3000);
        }
      }, 100);
    },
    restartProgress() {
      this.progress = 0;
      this.transition = false;
      this.done = false;

      window.clearInterval(this.progressInterval);
      window.setTimeout(() => {
        this.transition = true;
        this.startProgress();
      }, 600);
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