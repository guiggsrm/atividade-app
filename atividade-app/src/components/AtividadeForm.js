import { useState, useEffect } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSave, faPlus, faCancel } from '@fortawesome/free-solid-svg-icons'

export default function AtividadeForm(props) {

    const [atividade, setAtividade] = useState(atividadeAtual());

    useEffect(()=>{
        if (props.atividadeSelecionada.id !== 0) setAtividade(props.atividadeSelecionada);        
    }, [props.atividadeSelecionada]);

    function atividadeAtual(){
        if(props.atividadeSelecionada.id !== 0) {
            return props.atividadeSelecionada;
        }
        
        return props.atividadeInicial;
    }

    const inputHandler = (e) =>{
        const {name, value} = e.target;

        setAtividade({...atividade, [name]: value});
    }

    const handleCancelar = (e)=> {
        e.preventDefault();

        props.cancelarAtividade();

        setAtividade(props.atividadeInicial);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        
        if(props.atividadeSelecionada.id !== 0)
            props.atualizarAtividade(atividade);
        else
            props.addAtividades(atividade);

        setAtividade(props.atividadeInicial);
    }

    return (
        <>
            <h1>{atividade.id === 0 ? "Incluir atividade" : "Atividade " + atividade.id}</h1>
            <hr/>
            <form className='row row-cols-2 g-3' onSubmit={handleSubmit}>
                <div className='col'>
                    <label className='form-label'>Titulo</label>
                    <input id="titulo" name="titulo" className='form-control' onChange={inputHandler} value={atividade.titulo} />
                </div>
                <div className='col'>
                    <label className='form-label'>Prioridade</label>
                    <select id="prioridade" name="prioridade" className='form-select' onChange={inputHandler} value={atividade.prioridade}>
                        <option defaultValue='0'>Selecione</option>
                        <option value='1'>Baixa</option>
                        <option value='2'>Normal</option>
                        <option value='3'>Alta</option>
                    </select>
                </div>
                <div className='col-12'>
                    <label className='form-label'>Descrição</label>
                    <textarea id="descricao" name="descricao" className='form-control' onChange={inputHandler} value={atividade.descricao} />
                </div>
                <div className='col-12'>
                    {
                        atividade.id === 0 ? 
                        (        
                            <button type='submit' className="btn btn-primary">
                                <FontAwesomeIcon icon={faPlus} className="me-2" />Incluir
                            </button>
                        )
                        :
                        (
                            <>
                                <button type='submit' className="btn btn-outline-success me-2">
                                    <FontAwesomeIcon icon={faSave} className="me-2" />Salvar
                                </button>
                                <button 
                                    onClick={handleCancelar} 
                                    className="btn btn-outline-warning">
                                    <FontAwesomeIcon icon={faCancel} className="me-2" />Cancelar
                                </button>
                            </>
                        )
                    }
                </div>
            </form>
        </>
    )
}
