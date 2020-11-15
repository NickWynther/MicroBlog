app.component('blog-post' , {
    props:{
        post:{
            required:true
        },
    },

    data() {
        return {
            comments: [],
            showPressed: false,
            showCommentsPressed: false,
            apiUrlBase: 'https://localhost:44328/api',
            apiAllComments: '/comment',
            textPreviewLength: 200,
        }
    },

    methods: {

        Show(){
            this.showPressed = !this.showPressed;
            this.ShowComments();
        },

        ShowComments(){
            if (this.showPressed){
                axios
                .get(this.AllCommentsUrl)
                .then(response => (this.comments = response.data))
            }
        },

        PreviewText(text){
            if (text.length > this.textPreviewLength){
                return text.substring(0,this.textPreviewLength) + "...";
            }
            else{
                return text;
            }
        },

        AddComment(comment){
            this.comments.push(comment)
        }
    },

    computed:{

        AllCommentsUrl(){
            return this.apiUrlBase + this.apiAllComments + "/" + this.post.id;
        },

        CommentButtonText(){
            return this.showCommentsPressed ? "Hide comments" : "Show comments";
        },

        PostText(){
            return this.showPressed ? this.post.text :  this.PreviewText(this.post.text)
        }

      },

    template:
    /*html*/
    `
    <section class="card mb-2">
       <div class="card-body p-2 p-sm-3">
           <div class="media forum-item">
               <div class="media-body">
                   <h3>
                   <a href="#" class="text-body" @click.prevent="Show">{{post.title}}</a>
                   </h3>
                   <p class="text-secondary">{{PostText}}</p>
                   <p class="text-muted"><a href="javascript:void(0)">{{post.author}}</a> 
                   posted at <span class="text-secondary font-weight-bold">
                   <time-display :time="post.time"></time-display>
                   </span></p>
               </div>
           </div>

           <p class="text-muted" v-if="showPressed">Comments:</p>

           <blog-comment v-if="showPressed" v-for="comment in comments" key="comment.id" :comment="comment"></blog-comment>
           <comment-input v-if="showPressed" :postId="post.id" @sent="AddComment"></comment-input>
       </div>
   </section>    
    `
})