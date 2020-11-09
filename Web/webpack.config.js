'use strict';

const webpack = require('webpack');
const path = require('path');
const bundleFolder = "./wwwroot/";
const srcFolder = "./Sripts/";
const VueLoaderPlugin = require('vue-loader/lib/plugin')

module.exports = {
    entry: {
        site: __dirname + "/ClientApp/boot.js"
    },
    devtool: "source-map",
    output: {
        path: __dirname + '/wwwroot/dist', // Folder to store generated bundle
        filename: "main.js",  // Name of generated bundle after build
        publicPath: '/' // public URL of the output directory when referenced in a browser
    },

    module: {
        rules: [
            {
                test: /\.vue$/,
                exclude: /node_modules/,
                use: 'vue-loader'
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: 'babel-loader'
            },
            {
                test: /\.css$/,
                exclude: /node_modules/,
                use: [
                    'style-loader',
                    'css-loader'
                ]
            }
        ]
    },
    plugins: [
        new VueLoaderPlugin()
    ],
    resolve: {
        alias: {
            vue: path.resolve(__dirname, './node_modules/vue/dist/vue.js')
        }
    }
};