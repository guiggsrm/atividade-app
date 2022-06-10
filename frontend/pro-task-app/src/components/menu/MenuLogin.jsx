import React, { useContext } from 'react'
import { Nav, NavDropdown } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import { NavLink } from 'react-router-dom';
import { Context } from '../../context/AuthProvider'

export default function MenuLogin() {
    const{t} = useTranslation();
    const {authenticated, user, handleLogout} = useContext(Context);
    console.log(user);
    if (!authenticated){
        return (
            <>
                <Nav.Link as={NavLink} to="/register" className={(navData) => navData.isActive ? 'active' : ''}>{t('btn.register')}</Nav.Link>
                <Nav.Link as={NavLink} to="/login" className={(navData) => navData.isActive ? 'active' : ''}>{t('btn.login')}</Nav.Link>
            </>
        );
    }
    return (
        <>
            <NavDropdown align='end' title={user.name} id="basic-nav-dropdown">
                <NavDropdown.Item href="#action/3.1">{user.name}</NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item onClick={handleLogout}>{t("btn.logout")}</NavDropdown.Item>
            </NavDropdown>
        </>
    )
}
