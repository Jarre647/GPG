import React from 'react';

function ListGrudge(props) {
    return (
        <tr>
            <td>
                {props.abuserName}
            </td>
            <td>
                {props.reason}
            </td>
        </tr>
    )
}

export default ListGrudge;