<template>
  <v-container class="sms-composer">
    <v-layout row wrap>
      <v-flex xs12>
          <v-form v-model="valid">
              <p v-if="errors.length">
                  <b style="color:red">Please correct the indicated errors:</b>
                  <ul>
                      <li style="color:red" v-for="error in errors">{{error}}</li>
                  </ul>
              </p>

              <p v-if="result.length">
                  <b style="color:green">{{result}}</b>
              </p>

              <v-text-field v-model="number"
                            label="Mobile Number">{{number}}</v-text-field>
              <v-textarea v-model="content"
                          label="Sms Content">{{content}}</v-textarea>
              <button v-on:click="sendSMS">Send</button>
          </v-form>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
        name: 'SmsComposer',
        data: () => ({
            valid: true,
            errors: [],
            result: '',
            number: '',
            content: ''
        }),
        methods: {
            sendSMS: function () {
                this.errors = [];
                this.result = '';

                if (this.content.length > 160) {
                    this.errors.push('Only be able to send a message of no more than 160 characters.');
                }

                if (this.content.length === 0) {
                    this.errors.push('Empty message.');
                }

                if (this.number.length > 13 || this.number.length === 0) {
                    this.errors.push('Please enter a valid phone number');
                }
                let data = JSON.stringify({
                    Number: this.number,
                    Content: this.content
                })

                if (!this.errors.length) {

                    this.$http.post("https://localhost:44391/api/sms", data, { headers: { "content-type": "application/json" } }).then(result => {

                        if (result.data.success) {
                            this.result = 'Successfully';

                            this.number = '';
                            this.content = '';
                        }
                        else {
                            this.errors.push(result.data.errors);
                        }
                        
                    }, error => {
                        console.error(error);
                        });
                    
                }              
            }
        }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="stylus">
</style>
