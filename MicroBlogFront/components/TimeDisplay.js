app.component('time-display' , {
    props:{
        time:{
            required:true
        },
    },

    methods: {

        FormattedTime(time){
            var date = new Date(Date.parse(time));
            return date.getFullYear() + "/" + (date.getMonth() + 1) + "/" + (date.getDate() + 1) 
                + " " + date.getHours()+ ":" + date.getMinutes();
        },
    },

    template:
    /*html*/
    `
    <span>{{FormattedTime(time)}}</span> 
    `
})