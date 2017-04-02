<template>
    <div id="popular" class="popular-layout__container">
        <div class="popular-layout__content">
            <div class="popular-layout-title"><span class="popular-layout-title__text">Na topie</span></div>
            <div class="popular-layout-events__content">
                <eventview v-for="event in events" :event="event"></eventview>
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
            axios.get('http://localhost:5000/api/viewevents/getpopular')
                .then(response => this.events = response.data);
        },
        components: {
            eventview
        }
    }

</script>
<style>
    .popular-layout__container {}
    
    .popular-layout__content {
        margin: 10px 20px;
    }
    
    .popular-layout-title__text {
        font-size: 1.5em;
        font-weight: bold;
    }
    
    .popular-layout-events__content {
      
    }
</style>