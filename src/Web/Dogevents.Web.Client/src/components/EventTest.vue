<template>
    <div class="mdl-card mdl-cell mdl-cell--12-col-phone mdl-cell--3-col-tablet mdl-cell--4-col-desktop" v-bind:style="{ background: 'url(' + event.coverUrl + ')' }">
        <div class="mdl-card__title mdl-card--expand">
            <span><a v-bind:href="event.url" target="_blank">{{event.name}}</a></span>
        </div>
        <div class="mdl-card__actions mdl-card--border">
            <span>{{eventDate}}</span>
        </div>
    </div>

</template>
<script>
    export default {
        props: ['event'],
        computed: {
            eventDate: function () {
                return this.getEventTime();
            }
        },
        methods: {
            getEventTime: function () {
                let result = '';
                let startTime = new Date(this.event.start_time);
                let endTime = new Date(this.event.end_time);

                if (startTime.toDateString() === endTime.toDateString())
                    return startTime.toLocaleDateString() + ' ' + startTime.toLocaleTimeString() + ' - ' + endTime.toLocaleTimeString();

                return startTime.toLocaleDateString() + ' - ' + endTime.toLocaleDateString();
            }
        }
    }

</script>
<style>
    
</style>