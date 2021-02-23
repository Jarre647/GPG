//import React, { Component } from 'react';
//import PropTypes from 'prop-types';

//export default class DisplayMap extends Component {
//    constructor(props) {
//        super(props);
//        this.state = {
//            mapLoade: false,
//            location: {
//                lat: props.location.lat,
//                lng: props.location.lng,
//                name: props.location.name
//            }
//        };
//        this.ensureMapExists = this.ensureMapExists.bind(this);
//    } 
//    static propTypes = {
//        location: PropTypes.shape({
//            lat: PropTypes.number,
//            lng: PropTypes.number,
//            name: PropTypes.string
//        }),
//        displayOnly: PropTypes.bool
//    }
//    static defaultProps = {
//        displayOnly: true,
//        location: {
//            lat: 34.1535641,
//            lng: -118.1428115,
//            name: null
//        }
//    };
//    componentDidMount() {
//        this.L = window.L;
//        if (this.state.location.lng && this.state.location.lat) this.ensureMapExists();
//    }
//    ensureMapExists() {
//        if (this.state.mapLoaded) return;
//        this.map = this.L.mapbox.map(this.mapNode,
//            'mapbox.streets', {
//                zoomControl: false,
//                scrollWheelZoom: false
//            });
//            this.map.setView(this.L.latLng(this.state.location.lat,
//                this.state.location.lng), 12);
            
//            this.setState(()=> ({ mapLoaded: true })
//            );
//    }

//    render() {
//        return [
//            <div key="displayMap">
//                <div ref={node => {
//                    this.mapNode= node;
//                }}>
//                </div>    
//            </div>
//        ]
//    }
//}