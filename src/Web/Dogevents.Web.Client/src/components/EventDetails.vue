<template>
  <div>
       <md-dialog ref="EventDetailsDialog">
           <md-dialog-title>{{event.name}}</md-dialog-title>
            <md-dialog-content>
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
            </md-dialog-content>
       </md-dialog>
  </div>
</template>
<script>
    import EventBus from '../main'
    export default {
        name: 'EventDetails',
        data: () => ({
            showDialog: false,
            event: {
                    'name': '',
                }
        }),
        mounted() {
            EventBus.$on('SHOW_DETAILS', payLoad => {
                this.event = payLoad;
                this.openDialog('EventDetailsDialog');
            })
        },
        computed: {
            eventDate: function() { return {'start_time': this.event.start_time, 'end_time': this.event.end_time} }
        },
        methods: {
            openDialog(ref) {
                this.$refs[ref].open();
            },
            closeDialog(ref) {
                this.$refs[ref].close();
            },
            getDefaultImageName() {
                return (
                    "/src/assets/dogevents_" + (Math.floor(Math.random() * 4) + 1) + ".png"
                );
            },
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
        }
    }
</script>
