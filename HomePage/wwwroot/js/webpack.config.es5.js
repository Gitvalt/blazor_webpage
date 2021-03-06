'use strict';

var path = require('path');

module.exports = {
    entry: './src/project_gallery.jsx',
    module: {
        rules: [{
            test: /\.(js|jsx)$/,
            exclude: /node_modules/,
            use: ['babel-loader']
        }, {
            test: /\.css$/i,
            use: ["style-loader", "css-loader"]
        }]
    },
    mode: "development",
    optimization: {
        minimize: false
    }, resolve: {
        extensions: ['*', '.js', '.jsx']
    },
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'scripts')
    }
};

