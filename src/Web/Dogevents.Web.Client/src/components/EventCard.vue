<template>
    <div class="event-card mdl-card mdl-card--border mdl-shadow--2dp mdl-cell mdl-cell--12-col-phone mdl-cell--6-col-tablet mdl-cell--4-col-desktop"
        v-bind:style="{ background: 'url(' + event.coverUrl + ')' }">
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
                let startTime = new Date(this.event.start_time);
                let endTime = new Date(this.event.end_time);
                let locale = 'en-EN';
                let dateFormatOptions = {
                    day: 'numeric',
                    month: 'long'
                };
                let timeFormatOptions = {
                    hour: 'numeric',
                    minute: 'numeric'
                };

                if (startTime.toLocaleDateString() === endTime.toLocaleDateString())
                    return startTime.toLocaleDateString(locale, dateFormatOptions) + ' ' + startTime.toLocaleTimeString(locale, timeFormatOptions) + ' - ' + endTime.toLocaleTimeString(locale, timeFormatOptions);

                if (this.event.start_time.substring(0, 7) == this.event.end_time.substring(0, 7))
                    return startTime.getDate() + ' - ' + endTime.getDate() + ' ' + startTime.toLocaleDateString(locale, {
                        month: 'long'
                    })

                return startTime.toLocaleDateString(locale, dateFormatOptions) + ' - ' + endTime.toLocaleDateString(locale, dateFormatOptions)
            }
        }
    }

</script>
<style>
    .event-card.mdl-card {
        /*background-size: 100%!important;*/
        background-repeat: no-repeat;
        max-width: 40%;
        border-color: rgba(255, 255, 255, 1);
        border-style: solid;
        border-width: 0.5px;
        border-radius: 5px;
    }
    
    .event-card>.mdl-card__title {
        background: rgba(0, 0, 0, 0.2)!important;
    }
    
    .event-card>.mdl-card__title a {
        color: white;
        font-size: 1em;
        text-decoration: none;
        font-weight: bold;
    }
    
    .event-card>.mdl-card__actions {
        background: rgba(0, 0, 0, 0.5);
        color: #fff;
        font-size: 0.9em;
    }
</style>