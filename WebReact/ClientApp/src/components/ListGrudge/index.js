import React from 'react';
import "./styles.css"
function ListGrudge(props) {
    return (
        <div class="first__abuser">   
            
            <div>
                {props.abuserName}
            </div>
            <div>
                {props.reason}
            </div>               
        </div>
    )
}

export default ListGrudge;