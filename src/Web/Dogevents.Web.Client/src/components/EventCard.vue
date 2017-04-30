<template>
    <md-layout class="event-card" md-flex-xsmall="40" md-flex-small="50"  md-flex-medium="30">
        <md-card>
            <md-card-area>
                <md-card-media>
                    <img :src="event.coverUrl">
                </md-card-media>
                <md-card-header>
                    <h4 class="">{{event.name}}</h4>
                    <div class="md-subhead">
                        <a :href="getLocationLink()">
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
    export default {
        props: ['event'],
        computed: {
            eventDate: function() { return {'start_time': this.event.start_time, 'end_time': this.event.end_time} }
        },
        methods: {
            getLocationLink() {
                let baseUrl = "http://maps.google.com/maps?z=12&t=m"
                if (this.event.place.location) {
                    return baseUrl + '&q=loc:' + this.event.place.location.latitude + '+' + this.event.place.location.longitude
                }
                else {
                    return baseUrl + '&q=' + this.event.place.name
                }
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