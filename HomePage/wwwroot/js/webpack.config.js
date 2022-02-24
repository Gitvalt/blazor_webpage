const path = require('path');

module.exports = {
    entry: './src/index.jsx',
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: ['babel-loader'],
            },
            {
                test: /\.css$/i,
                use: ["style-loader", "css-loader"],
            },
        ],
    },
    mode: "production",
    optimization: {
        minimize: true,
    }, resolve: {
        extensions: ['*', '.js', '.jsx'],
    },
    output: {
        filename: 'bundle.js',
        hashFunction: "sha256",
        path: path.resolve(__dirname, 'scripts'),
    },
};