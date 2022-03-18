
import { Nav, NavbarBrand, Navbar, Container } from "react-bootstrap";
import { Link } from "react-router-dom";
import React from "react";
import HomePage from './pages/HomePage';
import {BookPage} from './pages/BookPage';
import {LoginPage} from './pages/LoginPage';
import { BrowserRouter, Routes, Route, } from "react-router-dom";



export default function App() {
    const routes = [
        { Path: '/', Element: <HomePage></HomePage> },
        { Path: '/bookpage', Element: <BookPage></BookPage>,Name:'Book' },
        { Path: '/login', Element: <LoginPage></LoginPage>,Name:'Login' },
    ];

    console.log("app")
    return <div>
        <BrowserRouter >
            <Navbar bg="dark" variant="dark">
                < Container>
                    <NavbarBrand as={Link} to="/"  >Home</NavbarBrand>
                    <Nav>
                      {routes.map(r =><Nav.Link key={r.Path} as={Link} to={r.Path}>{r.Name}</Nav.Link>)}  
                       
                    </Nav>

                </Container>

            </Navbar>

            <Routes>
                {routes.map(route => <Route key={route.Path} path={route.Path} element={route.Element}></Route>)}
            </Routes>
        </BrowserRouter>

    </div>
}