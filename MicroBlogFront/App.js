const app = Vue.createApp({
  data() {
      return {
          apiUrlBase: 'https://localhost:44328/api/',
          apiAllPosts: 'Post',
          apiTodayPosts: 'Post/today',
          apiSearchPosts: 'Post/search?search=',
          apiRandomPost: 'Post/Random',
          showPostInput: false,
          posts: []
      }
  },

  methods: {

    GetPosts(url){
      axios
      .get(url)
      .then(response => (this.posts = response.data))
    },

    GetPost(url){
      axios
      .get(url)
      .then(response => (this.posts = [response.data]))
    },

    BuildApiUrl(path){
      return this.apiUrlBase + path;
    },

    GetAllPosts(){
      this.GetPosts(this.BuildApiUrl(this.apiAllPosts));
      this.HidePostInput();
    },

    GetTodayPosts(){
      this.GetPosts(this.BuildApiUrl(this.apiTodayPosts));
      this.HidePostInput();
    },

    GetRandomPost(){
      this.GetPost(this.BuildApiUrl(this.apiRandomPost));
      this.HidePostInput();
    },

    PostSent(post){
      this.posts = [post]
      this.HidePostInput()
    },

    GetSearchedPosts(query){
      if (query.length == 0){
        this.GetAllPosts()
      }else{
        this.GetPosts(this.BuildApiUrl(this.apiSearchPosts)+query);
      }
      this.HidePostInput();
    },

    CreatePost(){
      this.showPostInput = true
    },

    HidePostInput(){
      this.showPostInput = false
    }

  },

  created: function(){
    this.GetAllPosts()
  },

  template:
    /*html*/
    `
    <app-navbar  @getAll="GetAllPosts" @search="GetSearchedPosts" 
    @getRandom="GetRandomPost" @getToday="GetTodayPosts" @createPost="CreatePost"></app-navbar>
    
    <main role="main" class="container">
    <post-input v-if="showPostInput" @postSent="PostSent" ></post-input>
    <blog-post v-else v-for="post in posts" :key="post.id" :post="post"></blog-post>
    <div v-if="!posts.length"> No results </div>
    </main>

    <app-footer></app-footer>

    `
})