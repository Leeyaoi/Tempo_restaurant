const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const fs = require("fs");
const webpack = require("webpack");
const dotenv = require("dotenv").config({ path: __dirname + "/.env" });
const isDevelopment = process.env.NODE_ENV !== "production";

module.exports = {
  entry: "./src/index.tsx",
  output: {
    filename: "bundle.js",
    path: path.resolve(__dirname, "dist"),
  },
  resolve: {
    extensions: [".tsx", ".ts", ".js"],
  },
  module: {
    rules: [
      {
        test: /\.(ts|tsx)$/,
        exclude: /node_modules/,
        use: "babel-loader",
      },
    ],
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: "./src/index.html",
    }),
    new webpack.DefinePlugin({
      "process.env": JSON.stringify(dotenv.parsed),
      "process.env.NODE_ENV": JSON.stringify(
        isDevelopment ? "development" : "production"
      ),
    }),
  ].filter(Boolean),

  mode: "development",
  devServer: {
    server: {
      type: "https",
      options: {
        key: "./certs/cert.key",
        cert: "./certs/cert.crt",
      },
    },
  },
};
