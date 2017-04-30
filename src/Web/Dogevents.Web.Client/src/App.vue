<template>
    <div class="app-viewport">
        <md-toolbar class="top-fixed md-dense">
            <i class="material-icons">event</i>
            <h2 class="md-title" style="flex: 1" md-hide-xsmall>Dogevents</h2>
            <md-button class="md-icon-button">
                <md-icon>search</md-icon>
            </md-button>
        </md-toolbar>
        <main>
            <popular />
            <justadded />
        </main>
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

<style scoped>
    .app-viewport {
        display: flex;
        flex-flow: column;
    }
    
    .top-fixed {
        position: fixed;
        top: 0;
        z-index: 1000;
        width: 100%;
    }
    
    main {
        margin-top: 60px;
    }
</style>