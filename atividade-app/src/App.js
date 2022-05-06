import { useState } from 'react';
import './App.css';
import AtividadeForm from './components/AtividadeForm';
import AtividadesLista from './components/AtividadesLista';

const atividadeInicial = {
    id: 0,
    titulo: '',
    descricao: '',
    prioridade: 0
};

function App() {

    const [atividades, setAtividades] = useState([]);
    const [atividade, setAtividade] = useState(atividadeInicial);

    function addAtividades(atividade){
        setAtividades([...atividades, { ...atividade, id: atividades.length <= 0 ? 1 : Math.max.apply(Math, atividades.map(ativ => ativ.id)) + 1 }]);
        setAtividade({id:0});
    }

    function deletarAtividade(id) {
        const atividadesFiltradas = atividades.filter(atividade => atividade.id !== id);
        setAtividades([...atividadesFiltradas]);
        if(atividade.id === id){
            setAtividade(atividadeInicial);
        }
    }

    function editarAtividade(id) {
        const atividade = atividades.filter(atividade => atividade.id === id);
        setAtividade(atividade[0]);
    }

    function atualizarAtividade(ativ) {
        setAtividades(atividades.map(item => item.id === ativ.id ? ativ : item));
        setAtividade(atividadeInicial);
    }

    function cancelarAtividade() {
        setAtividade(atividadeInicial);
    }

    return (
        <>
            <AtividadeForm 
                addAtividades={addAtividades} 
                atualizarAtividade={atualizarAtividade} 
                cancelarAtividade={cancelarAtividade} 
                atividadeInicial={atividadeInicial}
                atividadeSelecionada={atividade} 
                atividades={atividades} />
            <AtividadesLista 
                atividades={atividades} 
                deletarAtividade={deletarAtividade} 
                editarAtividade={editarAtividade} />
        </>
    );
}

export default App;
