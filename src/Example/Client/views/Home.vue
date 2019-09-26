<template>
  <div class="home">
    <div class="todos columns">
      <div class="column is-6 is-offset-3">
        <todo v-for="todo in todos" :todo="todo" v-on:remove="onRemove" v-bind:key="todo.Id" />
      </div>
    </div>

    <div class="columns">
      <form class="column is-6 is-offset-3">
        <b-field label="Title">
          <b-input v-model="form.title"></b-input>
        </b-field>

        <b-field label="Body">
          <b-input v-model="form.body" maxlength="1024" type="textarea"></b-input>
        </b-field>

        <div class="actions">
          <b-button type="is-primary" @click="submit">Submit</b-button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import Todo from '@/components/Todo'

export default {
  name: 'Home',
  data () {
    return {
      todos: [],
      form: {
        title: '',
        body: ''
      }
    }
  },
  mounted () {
    this.fetch()
  },
  methods: {
    fetch () {
      this.$http.get('/api/todo').then(response => {
        this.todos = response.data
      })
    },
    submit () {
      this.$http.post('/api/todo', this.form).then(response => {
        this.todos.push(response.data)
        this.form = {
          title: '',
          body: ''
        }
      })
    },
    onRemove (id) {
      this.todos = this.todos.filter(t => t.id !== id)
    }
  },
  components: {
    Todo
  }
}
</script>

<style scoped>
.actions {
  text-align: center;
}
</style>
