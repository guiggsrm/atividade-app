import React, { useContext } from 'react'
import { Nav } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
import { Context } from '../../context/AuthProvider'

export default function MenuControl() {
    const{authenticated} = useContext(Context);
    if (authenticated)
    {        
        return (
            <>
                <Nav.Link as={NavLink} to="/" className={(navData) => navData.isActive ? 'active' : ''}>Home</Nav.Link>
                <Nav.Link as={NavLink} to="/clients" className={(navData) => navData.isActive ? 'active' : ''}>Clients</Nav.Link>
                <Nav.Link as={NavLink} to="/tasks" className={(navData) => navData.isActive ? 'active' : ''}>Tasks</Nav.Link>
            </>
        );
    }
}
