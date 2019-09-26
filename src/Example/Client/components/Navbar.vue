<template>
  <nav class="navbar is-white has-shadow" role="navigation" aria-label="main navigation">
    <div class="container bring-to-front">
      <div class="navbar-brand">
        <a class="navbar-item" href="https://bulma.io">
          <img src="https://bulma.io/images/bulma-logo.png" width="112" height="28" />
        </a>

        <a
          role="button"
          class="navbar-burger burger"
          aria-label="menu"
          aria-expanded="false"
          data-target="navbarBasicExample"
          @click.prevent="showMenu = !showMenu"
        >
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
        </a>
      </div>

      <div id="navbarBasicExample" class="navbar-menu" v-bind:class="{ 'is-active': showMenu }">
        <slot></slot>
      </div>
    </div>
    <div class="overlay" v-bind:class="{ 'is-active': showMenu }" @click.prevent="showMenu = false"></div>
  </nav>
</template>

<script>
export default {
  data () {
    return {
      showMenu: false
    }
  }
}
</script>

<style scoped>
nav.navbar {
  margin-bottom: 1rem;
}
.bring-to-front {
  z-index: 999;
}
.overlay {
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  top: 0;
  display: none;
}
.overlay.is-active {
  display: flex;
}
</style>
