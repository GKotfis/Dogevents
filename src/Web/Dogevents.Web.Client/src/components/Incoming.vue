<template>
    <div>
        <md-subheader class="md-accent">Nadchodzące</md-subheader>
        <md-layout md-flex="100" md-align="center">
            <eventview v-for="event in events" :event="event" :key="event.Id"></eventview>
        </md-layout>
    </div>
</template>

<script>
    import axios from 'axios'
    import eventview from './EventSimple.vue'

    export default {
        name: 'incoming',
        data: () => ({
            events: []
        }),
        mounted() {
            axios.get(process.env.API_URL + '/viewevents/getincoming')
                .then(response => this.events = response.data);

        },
        components: {
            eventview
        }
    }

</script>
<style>
    .md-subheading>i {
        vertical-align: middle !important;
        padding: 10px 5px;
    }
</style>