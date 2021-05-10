import axios from 'axios';
import React, { Component } from 'react';
import PropTypes from 'prop-types';



class CreateGrudge extends Component {
    static propTypes = {

    }
    constructor(props) {
        super(props);

        this.state = {
            content: '',
            name: '',
            validContent: false,
            validName: false
        }

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleGrudgeContentChange = this.handleGrudgeContentChange.bind(this);
        this.handleNameAbuserChange = this.handleNameAbuserChange.bind(this);
    }

    handleNameAbuserChange(event) {
        const name = event.target.value;
        this.setState(() => {
            return {
                name,
                validName: name.length <= 280
            }
        });
    }

    handleGrudgeContentChange(event) {
        const content = event.target.value;
        this.setState(() => {
            return {
                content,
                validContent: content.length <= 280
            }
        });
    }


    handleSubmit() {
        if (!this.state.validContent && !this.state.validName) return;
        axios
            .post("/api/grudges",
                {
                    AbuserName: this.state.name,
                    Reason: this.state.content
                })
            .then(function(response) {
                console.log(response);
            });
    }

    render() {
        return (
            <div>
                <input
                    value={this.state.name}
                    onChange={this.handleNameAbuserChange}
                    placeholder="name"
                />

                <textarea
                    value={this.state.content}
                    onChange={this.handleGrudgeContentChange}
                    placeholder="What's happened?"
                />

                <button onClick={this.handleSubmit}>Post</button>
            </div>

        );
    }
}

export default CreateGrudge;