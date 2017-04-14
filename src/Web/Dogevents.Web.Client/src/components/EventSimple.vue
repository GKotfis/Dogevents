<template>
    <!--<div class="carousel-cell" v-bind:style="{ backgroundImage: 'url(' + event.coverUrl + ')' }">-->
    <div class="carousel-cell" v-bind:style="{ backgroundImage: 'url(' + event.coverUrl + ')' }">
        <span class="md-body-2">{{ event.name }}</span>
    </div>

</template>
<script>
    export default {
        props: ['event'],
        computed: {
            eventDate: function () {
                return this.event.start_time;
            },

        }
    }

</script>
<style>
   
</style>