import React, { Fragment, useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import ListGrudge from '../../components/ListGrudge'
import CreateGrudge from '../../components/CreateGrudge'
//import Map from '../../components/Map'
import axios from 'axios';

function App(){
    const [grudges, setGrudges] = useState([]);
    useEffect(() => {
        axios
        .get("https://localhost:44369/api/grudges")
        .then(res => setGrudges(res.data))
    }, []);
    
    return(
        <Fragment>
            <p>Поиск по имени</p>
            <input></input>
            {grudges.map((grudge) => <ListGrudge abuserName={grudge.abuserName}
                                                 reason={grudge.reason}/> ) }     
            <CreateGrudge/>  
        </Fragment>
    )
}

export default App;