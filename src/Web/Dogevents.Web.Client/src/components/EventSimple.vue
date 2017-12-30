<template>
    <md-layout class="event-card-simple" md-flex-xsmall="40" md-flex-small="50"  md-flex-medium="30">
        <md-card>
            <md-card-media-cover md-solid md-text-scrim>
                <md-card-media>
                    <img :src="getDefaultImageName()" />
                </md-card-media>
                <md-card-area>
                    <md-card-header>
                        <md-layout>
                            <md-layout md-flex>
                                <div class="md-subhead"  @click="showDetails(event.id)">{{event.name}}</div>
                            </md-layout>
                        </md-layout>
                    </md-card-header>   
                </md-card-area>
            </md-card-media-cover>
        </md-card>
    </md-layout>
</template>
<script>
import EventBus from "../main";
export default {
  props: ["event"],
  computed: {
    eventDate: function() {
      return {
        start_time: this.event.start_time,
        end_time: this.event.end_time
      };
    }
  },
  methods: {
    getLocationLink() {
      let baseUrl = "http://maps.google.com/maps?z=12&t=m";
      if (this.event.place && this.event.place.location) {
        return (
          baseUrl +
          "&q=loc:" +
          this.event.place.location.latitude +
          "+" +
          this.event.place.location.longitude
        );
      } else if (this.event.place && this.event.place.name) {
        return baseUrl + "&q=" + this.event.place.name;
      } else {
        return null;
      }
    },
    getDefaultImageName() {
      return (
        "/src/assets/dogevents_" + (Math.floor(Math.random() * 4) + 1) + ".png"
      );
    },
    showDetails(eventId) {
      EventBus.$emit("SHOW_DETAILS", this.event);
    }
  }
};
</script>
<style>
    .event-card-simple {
        margin-bottom: 10px;
        margin-right: 10px;
    }

    .event-card-simple img {
        opacity: 0.8;
    }
    .event-card-simple > .md-card {
        border-radius: 5px;
    }

    .event-card-simple .md-card-header {
        padding-top: 5px !important;
    }
</style>