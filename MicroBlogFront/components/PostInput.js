app.component('post-input' , {
    
    data() {
        return {
            text: "",
            title: "",
            author: "",
            apiUrlBase: 'https://localhost:44328/api',
            apiSendPost: '/post',
        }
    },

    methods: {
        async SendPost(){
            var payload = {
                title: this.title, 
                author: this.author, 
                text: this.text 
            }

            await axios.post(this.SendPostUrl, payload)
            .then((response) => {
                this.$emit('postSent', response.data)
                console.log(response); 
            }, (error) => {
                console.log(error);
            });
            
            this.author="";
            this.text="";
            this.title="";           
        },
    },

    computed:{
        SendPostUrl(){
            return this.apiUrlBase + this.apiSendPost
        },
      },

    template:
    /*html*/
    `
    <div class="panel">
        <div class="panel-body">
            <input type="text" class="form-control author-name" placeholder="Nickname"  v-model="author">
            <input type="text" class="form-control title" placeholder="Title"  v-model="title">
            <textarea class="form-control" rows="5" placeholder="What are you thinking?" v-model="text"></textarea>
            <div class="mar-top clearfix">
            <button type="submit" class="btn btn-sm btn-primary pull-right"  @click="SendPost"><i class="fa fa-pencil fa-fw"></i> Share</button>
            </div>
        </div>
    </div>
    `
})