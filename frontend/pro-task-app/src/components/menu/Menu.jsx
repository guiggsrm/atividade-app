import { Navbar, Container, Nav } from 'react-bootstrap'
import { NavLink } from 'react-router-dom'
import MenuLogin from './MenuLogin'
import Logo from '../logo/Logo'
import MenuControl from './MenuControl'
import MenuLanguage from './MenuLanguage'

export default function Menu() {
    return (
        <Navbar bg="primary" expand="lg" variant='dark'>
            <Container>
                <Navbar.Brand as={NavLink} to="/">
                    <Logo />
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <MenuControl />
                    </Nav>
                    <Nav>
                        <MenuLanguage />
                        <MenuLogin />
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}
