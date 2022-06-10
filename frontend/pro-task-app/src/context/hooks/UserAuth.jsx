import { useEffect, useState } from 'react';
import api from '../../Api/tasks';
import history from '../../Api/history';
import i18n from '../../i18n/i18n';

export default function UserAuth() {
    
    const[authenticated, setAuthenticated] = useState(false);
    const[loading, setLoading] = useState(true);
    const[user, setUser] = useState(undefined);
    const[lang, setLang] = useState(localStorage.getItem('lang') ?? i18n.language);

    useEffect(() => {
        try{
            const token = localStorage.getItem('token');
            const user = localStorage.getItem('user');
            const storageLang = localStorage.getItem('lang');
            if(token && user){
                api.defaults.headers.Authorization = `Bearer ${JSON.parse(token)}`;
                setUser(JSON.parse(user));
                changeLang(user.lang);
                setAuthenticated(true);
            } else if (storageLang !== 'undefined' && storageLang !== i18n.language) {
                changeLang(storageLang ?? i18n.language);
            }
        }catch(e) {
            handleLogout();
        }

        setLoading(false);
    }, []);

    const handleLogin = async (loginInfo) => {
        try{
            const { data: {token, user}} = await api.post('tokens/login', loginInfo);
            localStorage.setItem('token', JSON.stringify(token));
            localStorage.setItem('user', JSON.stringify(user));
            setUser(user);
            changeLang(user.lang);
            setAuthenticated(true);
            history.push('/');
        } catch(error) {
            console.log(error);
        }
    };

    const handleRegister = async (loginInfo) => {
        try{
            console.log(loginInfo);
            const response = await api.post('tokens/register', loginInfo);
            if(response){
                handleLogin(loginInfo);
            }
        } catch(error)
        {
            console.log(error);
        }
    };

    const handleLogout = () => {
        setAuthenticated(false);
        localStorage.removeItem('token');
        localStorage.removeItem('user');
        setUser({});
        history.push('/login');
    };

    const handleChangeLanguage = async (lang) => {        
        changeLang(lang);
        /*
        const response = await api.put(`users/${user.id}/changelanguage`, lang);
        if (response){
            i18n.changeLanguage(lang);
            const user = localStorage.getItem('user');
            user.lang = lang;
            localStorage.removeItem('user');
            localStorage.setItem('user', user);
        }
        */
    }

    const changeLang = (newLang) => {
        setLang(newLang);
        i18n.changeLanguage(newLang);
        localStorage.removeItem('lang');
        localStorage.setItem('lang', newLang);
    }

    return { loading, authenticated, handleLogin, handleLogout, handleRegister, handleChangeLanguage, user, lang };
}
