<template>
    <div id="popular" class="popular-layout__container">
        <div class="popular-layout__content">
            <div class="popular-layout-title"><h4 class="popular-layout-title__text">Na topie</h4></div>
            <hr />
            <div class="mdl-grid popular-layout-events__content">
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
            axios.get('http://192.168.1.108:5000/api/viewevents/getpopular')
                .then(response => this.events = response.data);
        },
        components: {
            eventview
        }
    }

</script>
<style>

    .popular-layout-title__text {
        text-align: center;
    }

    .popular-layout-events__content {
      max-width: 100%;
      display: flex;
      align-items: center;
    }
</style>