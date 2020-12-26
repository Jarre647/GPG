import React, { Component } from 'react';
import { render } from 'react-dom';
const node = document.getElementById('root');

// Create browser history to use in the Redux store

// Get the application-wide store instance, prepopulating with state from the server where available.
// const initialState = window.initialReduxState;
// const store = configureStore(history, initialState);
const root = React.createElement('div',
        {},
        React.createElement('h1', {}, "Hellowm world!"));
render (root, node)
