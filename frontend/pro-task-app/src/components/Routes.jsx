import { useContext } from 'react';
import { Navigate, Route, Routes } from 'react-router-dom';
import Task from '../pages/tasks/Task';
import Client from '../pages/clients/Client';
import ClientView from '../pages/clients/ClientView';
import Home from '../pages/home/Home';
import Register from '../pages/authenticate/Register';
import Login from '../pages/authenticate/Login';
import { Context } from '../context/AuthProvider';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSpinner } from '@fortawesome/free-solid-svg-icons'

const ProtectedRoute = ({ children }) => {
    const {authenticated, loading} = useContext(Context);
    console.log(loading);
    if(loading)
      return <FontAwesomeIcon icon={faSpinner} spin={true} />
    if (!authenticated && !loading) {
        console.log(authenticated);
        return <Navigate to="/login" replace />;
    }
  
    return children;
};

export default function AppRoutes() {    
    const {authenticated, loading} = useContext(Context);
    if(loading)
        return (<FontAwesomeIcon icon={faSpinner} spin={true} />);      
    if(!authenticated)
        return (<Routes>
            <Route path='/*' element={<Navigate to="/login" />} />
            <Route path='/register' element={<Register />} />
            <Route path='/login' element={<Login />} />
        </Routes>);
    return (
        <Routes>
            <Route path='/' element={<Home />} />
            <Route path='/*' element={<Navigate to="/" />} />
            <Route path='/tasks' element={<ProtectedRoute><Task /></ProtectedRoute>} />
            <Route path='/clients' element={<ProtectedRoute><Client /></ProtectedRoute>} />
            <Route path='/clients/:id' element={<ProtectedRoute><ClientView /></ProtectedRoute>} />
        </Routes>
    )
}
