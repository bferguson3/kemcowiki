<template> 
    <h3> Users:</h3>
</template>

<script> 
    import axios from "axios";

    let endpoint = 'https://jsonplaceholder.typicode.com/users';

    export default { 
        name: "Users",
        data() 
        { 
            let o = { users: null };
            return o;
        },
        created: function() {
            axios
                .get(endpoint)
                .then(response => {
                        this.users = response.data;
                    }
                )
        }
    }
</script> 

<style> 
h3 {
    margin-bottom: 5%
}
</style>