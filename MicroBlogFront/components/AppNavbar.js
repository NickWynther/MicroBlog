app.component('app-navbar' , {

    data() {
        return {
            query: "",
        }
    },
    
    methods:{
        Search(){
            this.$emit('search', this.query)
        },

        GetAll(){
            this.$emit('getAll')
        },

        GetToday(){
            this.$emit('getToday')
        },

        GetRandom(){
            this.$emit('getRandom')
        },

        CreatePost(){
          this.$emit('createPost')
      }
    },

    template:
    /*html*/
    `
    <header>
    <!-- Fixed navbar -->
    <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
      <a class="navbar-brand" href="#">MicroBlog</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarCollapse">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item">
            <a class="nav-link" href="#"  @click="GetAll">All </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#" @click="GetToday">Today</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#"  @click="GetRandom">Random </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="https://localhost:44328/swagger/index.html">API</a>
          </li>
          <li class="nav-item">
          <a class="nav-link" href="#"  @click="CreatePost">Create </a>
          </li>

          
        </ul>
        <form class="form-inline mt-2 mt-md-0">
          <input class="form-control mr-sm-2" type="text" placeholder="Search" aria-label="Search" v-model="query">
          <button class="btn btn-outline-success my-2 my-sm-0" type="submit" @click="Search"> Search</button>
        </form>
      </div>
    </nav>
  </header>
    `
})