app.component('blog-comment' , {
    props:{
        comment:{
            required:true
        },
    },

    methods: {

    },

    template:
    /*html*/
    `
    <div class="comment">
        <p class="text-muted">
            {{comment.text}}  
            <span class="time"> - posted at <time-display :time="comment.time"></time-display> by 
                <a href="javascript:void(0)"> {{comment.author}}</a> 
            </span>
        </p>
    </div>
    `
})