import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen, faFaceSmile, faFaceMeh, faFaceFrown, faTrash, faFaceGrinBeamSweat } from '@fortawesome/free-solid-svg-icons'

export default function TaskItem(props) { 

    function priorityDescription(param) {
      switch(param){
        case '1':
        case 'Low': return "Low";
        case '2':
        case 'Normal': return "Normal";
        case '3':
        case 'Higth': return "Higth";
        default: return "Not defined";
      }
    }

    function priorityIcon(param) {
      switch(param){
        case '1':
        case 'Low': return <FontAwesomeIcon icon={faFaceSmile} />;
        case '2':
        case 'Normal': return <FontAwesomeIcon icon={faFaceMeh} />;
        case '3':
        case 'Higth': return <FontAwesomeIcon icon={faFaceFrown} />;
        default: return <FontAwesomeIcon icon={faFaceGrinBeamSweat} />;
      }
    }

    function priorityBorder(param) {
      switch(param){
        case '1':
        case 'Low': return 'border-baixa';
        case '2':
        case 'Normal': return 'border-normal';
        case '3':
        case 'Higth': return 'border-alta';
        default: return 'border-sem-prioridade';
      }
    }

    function priorityTextColor(param) {
      switch(param){
        case '1':
        case 'Low': return 'text-success';
        case '2':
        case 'Normal': return 'text-warning';
        case '3':
        case 'Higth': return 'text-danger';
        default: return '';
      }
    }

    return (
        <div className='col mb-3'>
            <div className={"card shadow-sm shadow-warning " + priorityBorder(props.task.priority)}>
                <div className='card-body'>
                    <div className='d-flex justify-content-between'>
                        <h5 className='card-title'>
                            <span>
                                <span className='badge bg-secondary me-1'>{props.task.id}</span>
                                <span>{props.task.title}</span>
                            </span>
                        </h5>
                        <h6>
                            <span>
                                <span className='ms-1'>
                                    Priority:
                                </span>
                                <span className={priorityTextColor(props.task.priority)}>
                                    <span className='ms-1'>
                                        {priorityIcon(props.task.priority)}
                                    </span>
                                    <span className='ms-1'>
                                        {priorityDescription(props.task.priority)}
                                    </span>
                                </span>
                            </span> 
                        </h6>
                    </div>
                    <div className='card-text'>
                        {props.task.description}
                    </div>
                    <div className="d-flex justify-content-end pt-2 border-top">
                        <button 
                          className="btn btn-sm btn-outline-primary me-2"
                          onClick={() => props.editTask(props.task.id)}>
                            <FontAwesomeIcon icon={faPen} className="me-2" />Edit
                        </button>
                      <button className="btn btn-sm btn-outline-danger"
                        onClick={() => props.removeTask(props.task.id)}>
                          <FontAwesomeIcon icon={faTrash} className="me-2" />Remove
                      </button>
                    </div>
                </div>
            </div>
        </div>
    )
}
