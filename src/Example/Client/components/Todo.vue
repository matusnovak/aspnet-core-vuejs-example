<template>
  <div class="box">
    <article class="media">
      <div class="media-content">
        <div class="content">
          <p>
            <strong>{{todo.title}}</strong>&nbsp;
            <small>{{new Date(todo.createdAt).toLocaleString()}}</small>
          </p>
          <p>{{todo.body}}</p>
          <b-button size="is-small" type="is-danger" icon-left="delete" @click="remove" />
        </div>
      </div>
    </article>
  </div>
</template>

<script>
export default {
  props: {
    todo: {
      type: Object,
      required: true
    }
  },
  methods: {
    remove () {
      this.$http.delete(`/api/todo/${this.todo.id}`).then(() => {
        this.$emit('remove', this.todo.id)
      })
    }
  }
}
</script>
