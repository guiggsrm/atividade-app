import i18n from 'i18next';
import {initReactI18next} from 'react-i18next';
import translationEN from './en/translationEN.json';
import translationPT from './pt/translationPT.json';

// translations
const resources = {
    en: {
        translation: translationEN
    },
    pt: {
        translation: translationPT
    },
}

i18n.use(initReactI18next).init({
    resources,
    lng: 'en',
    keySepareator: false,
    interpolation: {
        escapeValue: false
    }
});

export default i18n;