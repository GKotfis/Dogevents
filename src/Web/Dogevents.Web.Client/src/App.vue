<template>
    <div class="app-viewport">
        <md-toolbar>
            <h2 class="md-title" style="flex: 1">Dogevents</h2>
            <md-button class="md-icon-button">
                <md-icon>search</md-icon>
            </md-button>
        </md-toolbar>
        <md-layout>
            <popular />
            <!--<justadded />-->
        </md-layout>
    </div>
</template>

<script>
    import Vue from 'vue'
    import VueMaterial from 'vue-material'
    import popular from './components/Popular.vue'
    import justadded from './components/JustAdded.vue'

    export default {
        components: {
            popular,
            justadded
        }
    }

</script>

<style>
    .app-viewport {
        display: flex;
        flex-flow: column;
    }
</style>