module.exports = {
    publicPath: '/',
    devServer: {
        port: 1024,
        proxy: {
            '^/api': {
                target: 'https://localhost:5001',
                changeOrigin: true
            }
        }
    }
}