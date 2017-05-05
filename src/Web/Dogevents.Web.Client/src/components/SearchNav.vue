<template>
    <div>
        <md-button-toggle md-single>
            <md-layout>
                <md-button >Seminaria</md-button>
                <md-button>Sport</md-button>
                <md-button>Warsztaty</md-button>
                <md-button>Tropy</md-button>
            </md-layout>
        </md-button-toggle>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        name: 'searchNav',
        data: () => ({
        }),
        mounted() {
        },
        components: {

        }
    }

</script>
<style>

</style>