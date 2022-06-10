import { useContext, useEffect, useState } from 'react'
import { NavDropdown } from 'react-bootstrap';
import { Context } from '../../context/AuthProvider';
import enFlag from '../../i18n/en/flag.png';
import i18n from '../../i18n/i18n';
import ptFlag from '../../i18n/pt/flag.png';

const languages = [
    {   
        name: 'English',
        lang: 'en',
        img: enFlag
    },
    {
        name: 'Português',
        lang: 'pt',
        img: ptFlag
    }
];

export default function MenuLanguage() {
    const{handleChangeLanguage, lang} = useContext(Context);
    const[pageLang, setPageLang] = useState(languages.filter((l) => l.lang === i18n.language)[0]);

    useEffect(() => {
        const language = languages.filter((l) => l.lang === lang)[0];
        if(language) {
            setPageLang(language);
        }
    } ,[lang]);

    return (
        <>
            <NavDropdown 
                align='end' 
                title={
                    <img className="flag-img" 
                        src={pageLang.img}
                        alt={pageLang.lang}
                    />
                } 
                id="basic-nav-dropdown"
            >
                {languages.map(l => (
                    <NavDropdown.Item onClick={() => handleChangeLanguage(l.lang)} key={l.lang}>
                        <img className="flag-img me-2" 
                            src={l.img}
                            alt={l.lang}
                        />
                        {l.name}
                    </NavDropdown.Item>
                ))}
            </NavDropdown>
        </>
    )
}
