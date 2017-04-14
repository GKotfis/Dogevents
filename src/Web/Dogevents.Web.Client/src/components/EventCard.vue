<template>
    <md-layout class="event-card" md-flex="40" md-flex-offset="5">
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
                            <span>{{eventDate}}</span>
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
            eventDate: function () {
                return this.getEventTime();
            }
        },
        methods: {
            getEventTime: function () {
                let startTime = new Date(this.event.start_time);
                let endTime = new Date(this.event.end_time);
                let locale = 'en-EN';
                let dateFormatOptions = {
                    day: 'numeric',
                    month: 'long'
                };
                let timeFormatOptions = {
                    hour: 'numeric',
                    minute: 'numeric'
                };

                if (startTime.toLocaleDateString() === endTime.toLocaleDateString())
                    return startTime.toLocaleDateString(locale, dateFormatOptions) + ' ' + startTime.toLocaleTimeString(locale, timeFormatOptions) + ' - ' + endTime.toLocaleTimeString(locale, timeFormatOptions);

                if (this.event.start_time.substring(0, 7) == this.event.end_time.substring(0, 7))
                    return startTime.getDate() + ' - ' + endTime.getDate() + ' ' + startTime.toLocaleDateString(locale, {
                        month: 'long'
                    })

                return startTime.toLocaleDateString(locale, dateFormatOptions) + ' - ' + endTime.toLocaleDateString(locale, dateFormatOptions)
            },
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
    }
    
    .md-card-header {
        padding-top: 0px!important;
        padding-bottom: 0px!important;
    }
   
</style>