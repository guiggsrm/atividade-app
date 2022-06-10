import React from 'react';
import ReactDOM from 'react-dom/client';
import './i18n/i18n';
import 'bootstrap/dist/css/bootstrap.min.css';
import "bootswatch/dist/sandstone/bootstrap.min.css";
import './index.css';
import App from './App';
import Menu from './components/menu/Menu';
import { BrowserRouter as Router } from 'react-router-dom';
import { AuthProvider } from './context/AuthProvider';
import Footer from './components/footer/Footer';


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <Router>
            <AuthProvider>
                <Menu />
                <div className='container mt-3'>
                    <App />
                </div>
                <Footer />
            </AuthProvider>
        </Router>
    </React.StrictMode>
);