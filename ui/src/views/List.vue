<template>
    <div class="sms-list">
        <h1>This is the sms list page</h1>

        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <date-picker v-model="date" :config="options" :disabledDates="disabledDates"></date-picker>
                </div>
            </div>
        </div>

        <b-row>
            <b-col>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Date Time</th>
                            <th>From</th>
                            <th>To</th>
                            <th>Message</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="record in records">
                            <td>{{ record.date_created }}</td>
                            <td>{{ record.from }}</td>
                            <td>{{ record.to }}</td>
                            <td>{{ record.body }}</td>
                        </tr>
                    </tbody>
                </table>
            </b-col>
        </b-row>
    </div>
</template>

<script>
    export default {
        data: () => ({
            records: [],
            date: new Date().toISOString().substr(0, 10),
            disabledDates: {
                from: new Date().toISOString().substr(0, 10)
            },
            options: {
                format: 'YYYY-MM-DD',
                useCurrent: false,
            }  
        }),
        beforeRouteEnter(to, from, next) {
            next(vm => vm.getAll())
        },
        methods: {
            getAll: function () {
                this.records = [];

                this.$http.get('https://localhost:44391/api/sms/' + this.date)
                    .then(response => {
                        this.records = response.data;
                    })            
            }
        },
        watch: {
            date: function (newVal, oldVal) {
                this.date = newVal.toString();
                this.getAll();
            }
        }
    }
</script>
