<template>
    <mdl-layout>
        <mdl-layout md-flex="100" md-flex-offset="5">
            <span class="md-body-2">Popularne</span>
            <md-layout>
                <eventview v-for="event in events" :event="event" :key="event.Id"></eventview>
            </md-layout>
        </mdl-layout>
    </mdl-layout>
</template>

<script>
    import axios from 'axios'
    import eventview from './EventCard.vue'

    export default {
        name: 'popular',
        data: () => ({
            events: []
        }),
        mounted() {
            axios.get(process.env.API_URL + '/viewevents/getpopular')
                .then(response => this.events = response.data);

        },
        components: {
            eventview
        }
    }

</script>
<style>

</style>