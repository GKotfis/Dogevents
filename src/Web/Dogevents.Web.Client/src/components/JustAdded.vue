<template>
    <div>
        <span class="md-subheading"><i class="material-icons">fiber_new</i>Ostatnio dodane</span>
        <md-layout md-flex="100">
            <eventview v-for="event in events" :event="event" :key="event.Id"></eventview>
        </md-layout>
    </div>
</template>

<script>
    import axios from 'axios'
    import eventview from './EventCard.vue'

    export default {
        name: 'justadded',
        data: () => ({
            events: []
        }),
        mounted() {
            axios.get(process.env.API_URL + '/viewevents/GetJustAdded')
                .then(response => this.events = response.data);
        },
        components: {
            eventview
        }
    }

</script>
<style>
   
</style>