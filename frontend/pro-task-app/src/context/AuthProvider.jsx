import { createContext } from 'react'
import UserAuth from './hooks/UserAuth'

const Context = createContext();

function AuthProvider({ children}) {
    const { loading, authenticated, handleLogin, handleLogout, handleRegister, handleChangeLanguage, user, lang } = UserAuth();

    return (
        <Context.Provider value={ { loading, authenticated, handleLogin, handleLogout, handleRegister, handleChangeLanguage, user, lang } }>
            {children}
        </Context.Provider>
    )
}

export { Context, AuthProvider }