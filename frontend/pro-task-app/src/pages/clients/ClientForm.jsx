import { useState, useEffect } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSave, faPlus, faCancel } from '@fortawesome/free-solid-svg-icons'

export default function ClientForm(props) {

    const [client, setClient] = useState(currentClient());

    useEffect(()=>{
        if (props.selectedClient.id !== 0) setClient(props.selectedClient);        
    }, [props.selectedClient]);

    function currentClient(){
        if(props.selectedClient.id !== 0) {
            return props.selectedClient;
        }
        
        return props.initialClient;
    }

    const inputHandler = (e) =>{
        const {name, value} = e.target;

        setClient({...client, [name]: value});
    }

    const handleCancel = (e)=> {
        e.preventDefault();

        props.cancelClient();

        setClient(props.initialClient);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        
        if(props.selectedClient.id !== 0)
            props.updateClient(client);
        else
            props.addClient(client);

        setClient(props.initialClient);
    }

    return (
        <form className='row row-cols-2 g-3' onSubmit={handleSubmit}>
                <div className='col'>
                    <label className='form-label'>Name</label>
                    <input id="name" name="name" className='form-control' onChange={inputHandler} value={client.name} />
                </div>
                <div className='col'>
                    <label className='form-label'>Situation</label>
                    <select id="situation" name="situation" className='form-select' onChange={inputHandler} value={client.situation}>
                        <option defaultValue='Active'>Select</option>
                        <option value='Active'>Active</option>
                        <option value='Inactive'>Inactive</option>
                        <option value='Suspended'>Suspended</option>
                    </select>
                </div>
                <div className='col-12'>
                    {
                        client.id === 0 ? 
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
    )
}
