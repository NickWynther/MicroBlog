app.component('comment-input' , {
    props:{
        postId:{
            required:true
        },
    },

    data() {
        return {
            text: "",
            author: "",
            apiUrlBase: 'https://localhost:44328/api',
            apiSendComment: '/comment',
        }
    },

    methods: {
        async SendComment(){
            var payload = {
                postId: this.postId, 
                author: this.author, 
                text: this.text 
            }

            await axios.post(this.SendCommentUrl, payload)
            .then((response) => {
                this.$emit('sent', response.data)
                console.log(response); 
            }, (error) => {
                console.log(error);
            });
            
            this.author="";
            this.text="";            
        },
    },

    computed:{
        SendCommentUrl(){
            return this.apiUrlBase + this.apiSendComment
        },
      },

    template:
    /*html*/
    `
    <div class="panel">
        <div class="panel-body">
            <input type="text" class="form-control author-name" placeholder="Nickname"  v-model="author">
            <textarea class="form-control" rows="2" placeholder="What are you thinking?" v-model="text"></textarea>
            <div class="mar-top clearfix">
            <button type="submit" class="btn btn-sm btn-primary pull-right"  @click="SendComment"><i class="fa fa-pencil fa-fw"></i> Share</button>
            </div>
        </div>
    </div>
    `
})