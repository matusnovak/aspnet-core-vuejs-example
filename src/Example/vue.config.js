const path = require('path')

module.exports = {
  pages: {
    index: {
      entry: 'Client/main.js',
      template: 'public/index.html',
      filename: 'index.html',
      title: '.NET VueJs Example'
    }
  },
  configureWebpack: {
    resolve: {
      alias: {
        '@': path.resolve(__dirname, 'Client/')
      }
    }
  }
}
