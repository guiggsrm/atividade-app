import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen, faFaceSmile, faFaceMeh, faFaceFrown, faTrash, faFaceGrinBeamSweat } from '@fortawesome/free-solid-svg-icons'

export default function Atividade(props) { 

    function descricaoPrioridade(param) {
      switch(param){
        case '1': return "Baixa";
        case '2': return "Normal";
        case '3': return "Alta";
        default: return "Não definido";
      }
    }

    function iconePrioridade(param) {
      switch(param){
        case '1': return <FontAwesomeIcon icon={faFaceSmile} />;
        case '2': return <FontAwesomeIcon icon={faFaceMeh} />;
        case '3': return <FontAwesomeIcon icon={faFaceFrown} />;
        default: return <FontAwesomeIcon icon={faFaceGrinBeamSweat} />;
      }
    }

    function bordaPrioridade(param) {
      switch(param){
        case '1': return 'border-baixa';
        case '2': return 'border-normal';
        case '3': return 'border-alta';
        default: return 'border-sem-prioridade';
      }
    }

    function textColorPrioridade(param) {
      switch(param){
        case '1': return 'text-success';
        case '2': return 'text-warning';
        case '3': return 'text-danger';
        default: return '';
      }
    }

    return (
        <div className='col mb-3'>
            <div className={"card shadow-sm shadow-warning " + bordaPrioridade(props.atividade.prioridade)}>
                <div className='card-body'>
                    <div className='d-flex justify-content-between'>
                        <h5 className='card-title'>
                            <span>
                                <span className='badge bg-secondary me-1'>{props.atividade.id}</span>
                                <span>{props.atividade.titulo}</span>
                            </span>
                        </h5>
                        <h6>
                            <span>
                                <span className='ms-1'>
                                    Prioridade:
                                </span>
                                <span className={textColorPrioridade(props.atividade.prioridade)}>
                                    <span className='ms-1'>
                                        {iconePrioridade(props.atividade.prioridade)}
                                    </span>
                                    <span className='ms-1'>
                                        {descricaoPrioridade(props.atividade.prioridade)}
                                    </span>
                                </span>
                            </span> 
                        </h6>
                    </div>
                    <div className='card-text'>
                        {props.atividade.descricao}
                    </div>
                    <div className="d-flex justify-content-end pt-2 border-top">
                        <button 
                          className="btn btn-sm btn-outline-primary me-2"
                          onClick={() => props.editarAtividade(props.atividade.id)}>
                            <FontAwesomeIcon icon={faPen} className="me-2" />Editar
                        </button>
                      <button className="btn btn-sm btn-outline-danger"
                        onClick={() => props.deletarAtividade(props.atividade.id)}>
                          <FontAwesomeIcon icon={faTrash} className="me-2" />
                          Deletar
                      </button>
                    </div>
                </div>
            </div>
        </div>
    )
}
