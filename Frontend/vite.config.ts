import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [
    vue()
  ],
  server: {
    proxy: {
      '/api': {
        target: "https://localhost:7139",
        changeOrigin: true,
        secure: false,      
        rewrite: path => path.replace('/api', ''),
      }
    },
  },
  resolve: {
    alias: [{ find: '@', replacement: '/src' }],
   },
})
