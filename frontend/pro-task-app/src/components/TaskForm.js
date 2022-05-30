import { useState, useEffect } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSave, faPlus, faCancel } from '@fortawesome/free-solid-svg-icons'

export default function TaskForm(props) {

    const [task, setTask] = useState(currentTask());

    useEffect(()=>{
        if (props.selectedTask.id !== 0) setTask(props.selectedTask);        
    }, [props.selectedTask]);

    function currentTask(){
        if(props.selectedTask.id !== 0) {
            return props.selectedTask;
        }
        
        return props.initialTask;
    }

    const inputHandler = (e) =>{
        const {name, value} = e.target;

        setTask({...task, [name]: value});
    }

    const handleCancel = (e)=> {
        e.preventDefault();

        props.cancelTask();

        setTask(props.initialTask);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        
        if(props.selectedTask.id !== 0)
            props.updateTask(task);
        else
            props.addTask(task);

        setTask(props.initialTask);
    }

    return (
        <>
            <form className='row row-cols-2 g-3' onSubmit={handleSubmit}>
                <div className='col'>
                    <label className='form-label'>Title</label>
                    <input id="title" name="title" className='form-control' onChange={inputHandler} value={task.title} />
                </div>
                <div className='col'>
                    <label className='form-label'>Priority</label>
                    <select id="priority" name="priority" className='form-select' onChange={inputHandler} value={task.priority}>
                        <option defaultValue='NotDefined'>Select</option>
                        <option value='Low'>Low</option>
                        <option value='Normal'>Normal</option>
                        <option value='Higth'>Higth</option>
                    </select>
                </div>
                <div className='col-12'>
                    <label className='form-label'>Description</label>
                    <textarea id="description" name="description" className='form-control' onChange={inputHandler} value={task.description ?? undefined} />
                </div>
                <div className='col-12'>
                    {
                        task.id === 0 ? 
                        (        
                            <button type='submit' className="btn btn-success me-2">
                                <FontAwesomeIcon icon={faPlus} className="me-2" />Add
                            </button>
                        )
                        :
                        (
                            <button type='submit' className="btn btn-outline-success me-2">
                                <FontAwesomeIcon icon={faSave} className="me-2" />Save
                            </button>
                        )
                    }
                    <button 
                        onClick={handleCancel} 
                        className="btn btn-outline-warning">
                        <FontAwesomeIcon icon={faCancel} className="me-2" />Cancel
                    </button>
                </div>
            </form>
        </>
    )
}
