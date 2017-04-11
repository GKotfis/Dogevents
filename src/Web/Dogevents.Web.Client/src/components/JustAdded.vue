<template>
    <div id="justadded" class="justadded-layout__container">
        <div class="justadded-layout__content">
            <div class="justadded-layout-title"><h4 class="justadded-layout-title__text">Świeżaki</h4></div>
            <hr />
            <div class="mdl-grid justadded-layout-events__content">
                <eventview v-for="event in events" :event="event" :key="event.Id"></eventview>
            </div>
        </div>
    </div>
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
            axios.get('http://192.168.1.108:5000/api/viewevents/GetJustAdded')
                .then(response => this.events = response.data);
        },
        components: {
            eventview
        }
    }

</script>
<style>
    .justadded-layout__container {
        margin-top: 5em;
    }
    .justadded-layout-title__text {
        text-align: center;
    }
</style>