import React from 'react';

function ListGrudge(props) {
    return (
        <div>       
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