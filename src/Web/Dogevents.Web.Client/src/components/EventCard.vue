﻿<template>
    <md-layout class="event-card" md-flex-xsmall="40" md-flex-small="50"  md-flex-medium="30">
        <md-card>
            <md-card-area>
                <md-card-media>
                    <img 
                        :src=getDefaultImageName()
                        @error="event.coverUrl='src/assets/'+getDefaultImageName()"
                        @click="showDetails(event.id)">
                </md-card-media>
                <md-card-header>
                    <h4 class=""><a v-bind:href="event.url" target="_blank">{{event.name}}</a></h4>
                    <div class="md-subhead">
                        <a :href="getLocationLink()" v-if="getLocationLink() !== null">
                            <md-icon>location_on</md-icon>
                            <span>{{event.place.name}}</span>
                        </a>
                        <div class="md-subhead">
                            <md-icon>schedule</md-icon>
                            <span>{{eventDate | toEventDate}}</span>
                        </div>
                    </div>
                </md-card-header>
            </md-card-area>
        </md-card>
    </md-layout>
</template>
<script>
    import EventBus from '../main'
    export default {
        props: ['event'],
        computed: {
            eventDate: function() { return {'start_time': this.event.start_time, 'end_time': this.event.end_time} }
        },
        methods: {
            getLocationLink() {
                let baseUrl = "http://maps.google.com/maps?z=12&t=m"
                if (this.event.place && this.event.place.location) {
                    return baseUrl + '&q=loc:' + this.event.place.location.latitude + '+' + this.event.place.location.longitude
                }
                else if (this.event.place && this.event.place.name) {
                    return baseUrl + '&q=' + this.event.place.name
                }
                else {
                    return null
                }
            },
            getDefaultImageName() {
                return '/src/assets/dogevents_' + (Math.floor(Math.random() * 4) + 1) + '.png'
            },
            showDetails(eventId) {
                EventBus.$emit('SHOW_DETAILS', this.event);
            }
        }
    }

</script>
<style>
    .event-card {
        margin-bottom: 10px;
        margin-right: 10px;
    }

    .md-card-header {
        padding-top: 0px!important;
        padding-bottom: 0px!important;
    }
   
</style>