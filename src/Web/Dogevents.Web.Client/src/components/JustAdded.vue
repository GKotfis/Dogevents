<template>
    <div id="justadded" class="justadded-layout__container">
        <div class="justadded-layout__content">
            <div class="justadded-layout-title"><span class="justadded-layout-title__text">Świeżaki</span></div>
            <div class="justadded-layout-events__content">
                <eventview v-for="event in events" :event="event"></eventview>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    import eventview from './EventSimple.vue'

    export default {
        name: 'popular',
        data: () => ({
            events: []
        }),
        mounted() {
            axios.get('http://localhost:5000/api/viewevents/GetJustAdded')
                .then(response => this.events = response.data);
        },
        components: {
            eventview
        }
    }

</script>
<style>
    .justadded-layout__container {}
    
    .justadded-layout__content {
        margin: 10px 20px;
    }
    
    .justadded-layout-title__text {
        font-size: 1.5em;
        font-weight: bold;
    }
    
    .justadded-layout-events__content {
      
    }
</style>