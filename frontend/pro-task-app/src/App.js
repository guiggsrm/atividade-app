import './App.css';
import AppRoutes from './components/Routes';
import history from './Api/history'

export default function App() {
    return (
        <>             
            <AppRoutes history={history} />
        </>
    )
}