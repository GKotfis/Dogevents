<template>
    <div class="event-card mdl-card mdl-shadow--4dp" v-bind:style="{ backgroundImage: 'url(' + event.coverUrl + ')' }">
        <div class="mdl-card__title mdl-card--expand">
            <span class="event-card__title-text">{{ event.start_time }}</span>
        </div>
        <div class="mdl-card__actions">
            <span class="event-card__name">{{ event.name }}</span>
        </div>
    </div>

</template>
<script>
    export default {
        props: ['event'],
        computed: {
            eventDate: function () {
                return this.event.start_time;
            }
        },
    }

</script>
<style>
    .event-card {
        margin: 5px 10px;
    }
    
    .event-card__title-text {
        color: white;
        font-size: 1em;
        font-weight: bold;
    }
    
    .event-card > .mdl-card__actions {
        height: 52px;
        padding: 16px;
        background: rgba(0, 0, 0, 0.5);
    }
    
    .event-card__name {
        color: #fff;
        font-size: 1em;
        font-weight: 500;

    }
</style>