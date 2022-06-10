import { useState, useEffect } from "react";
import { Button, ButtonGroup, Modal, NavLink } from 'react-bootstrap'
import TitlePage from '../../components/TitlePage';
import api from '../../Api/tasks';
import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSpinner, faPlus, faCancel, faCheck, faSearch, faTrash, faEdit } from '@fortawesome/free-solid-svg-icons'
import ClientForm from "./ClientForm";
import Moment from 'moment';

const initialClient = {
    id: 0,
    name: '',
    situation: 1
}

export default function Client() {
    const[data, setData] = useState([]);
    const[loadingData, setLoadingData] = useState(true);
    const[client, setClient] = useState(initialClient);
    const[show, setShow] = useState(false);
    const[showRemove, setShowRemove] = useState(false);

    const toggleModal = () => setShow(!show);
    const toggleRemoveModal = () => setShowRemove(!showRemove);

    const newClient = async () => {
        setClient(initialClient);
        toggleModal();
    }

    const addClient = async (client) => {
        console.log(client);
        const response = await api.post('clients', client);
        console.log(response.data);
        setData([...data, response.data]);
        setClient({id:0});
        toggleModal();
    }

    const cancelClient = async () => {
        setClient(initialClient);
        toggleModal();
    }

    const updateClient = async (client) => {
        const response = await api.put(`clients/${client.id}`, client);
        console.log(response.data);
        setData(data.map(item => item.id === response.data.id ? response.data : item));
        setClient(initialClient);
        toggleModal();
    }

    const removeClient = async (id) => {
        if (await api.delete(`clients/${id}`)) {
            const tasksFiltradas = data.filter(task => task.id !== id);
            setData([...tasksFiltradas]);
            if(client.id === id){
                setClient(initialClient);
                toggleRemoveModal();
            }
        }
    }
    
    const editClient = (id) => {
        const client = data.filter(client => client.id === id);
        setClient(client[0]);
        toggleModal();
    }

    const modalRemove = (id) => {
        const client = data.filter(task => task.id === id);
        setClient(client[0]);
        toggleRemoveModal();
    }

    function formatLinks(cell, row) {
        return (
            <ButtonGroup aria-label={"btn-group-"+row.id} size="sm">
                <Button variant="primary" href={`/clients/${cell}`}><FontAwesomeIcon icon={faSearch}/></Button>
                <Button variant="outline-secondary" onClick={() => editClient(cell)}><FontAwesomeIcon icon={faEdit}/></Button>
                <Button variant="outline-danger"onClick={() => modalRemove(cell)}><FontAwesomeIcon icon={faTrash}/></Button>
            </ButtonGroup>
        );
    }

    function formatDate(cell, row) {
        if (cell)
        return (
            Moment(cell).format('YYYY/MM/YY')            
        );
    }

    const columns = [
        {
            dataField: "id",
            text: "",
            formatter: formatLinks
        },
        {
            dataField: "name",
            text: "Name",
            sort: true
        },
        {
            dataField: "situation",
            text: "Situation",
            sort: true
        },
        {
            dataField: "creationDate",
            text: "Creation date",
            sort: true,
            formatter: formatDate,
            classes: "text-end",
            headerClasses: "text-end",
        },
        {
            dataField: "modificationDate",
            text: "Modification date",
            sort: true,
            formatter: formatDate,
            classes: "text-end",
            headerClasses: "text-end",
        }
    ];

    const getClients = async () => {
        try{
            const response = await api.get('clients');
            console.log(response);
            if (response) {
                setData(response.data);
                setLoadingData(false);
            }
        } catch(e)
        {
            console.log(e);
        }
    };

    useEffect(() => {
        const getAll = async () => {
            await getClients();
        }
        if (loadingData) {
            getAll();
        }
    }, [loadingData]);

    return (
        <>
            <TitlePage title='Clients'>
                <Button variant="primary" onClick={newClient}>
                    <FontAwesomeIcon icon={faPlus} className="me-2" />New client
                </Button>
            </TitlePage>
            <div className="mt-3">
                {
                    loadingData ? 
                        <FontAwesomeIcon icon={faSpinner} spin={true} />
                    :
                        <BootstrapTable
                            keyField="id" 
                            data={data}
                            columns={columns}
                            pagination={paginationFactory()}
                            classes="table table-striped table-hover"
                            bordered={false}
                        />
                }
            </div>

            <Modal show={show} onHide={toggleModal}>
                <Modal.Header closeButton>
                <Modal.Title><h1>{client.id === 0 ? "Add client" : "Client " + client.id}</h1></Modal.Title>
                </Modal.Header>
                <Modal.Body>                    
                    <ClientForm 
                        addClient={addClient} 
                        updateClient={updateClient} 
                        cancelClient={cancelClient} 
                        initialClient={initialClient}
                        selectedClient={client} 
                        clients={data} />
                </Modal.Body>
            </Modal>

            <Modal show={showRemove} onHide={toggleRemoveModal}>
                <Modal.Header closeButton>
                <Modal.Title><h1>Confirm</h1></Modal.Title>
                </Modal.Header>
                <Modal.Body>    
                    <p>Do you want to remove the client {client.id + " - " + client.name}</p>                
                    <Button variant="success me-2" onClick={() => removeClient(client.id)}>
                        <FontAwesomeIcon icon={faCheck} className="me-2" />Yes
                    </Button>
                    <Button variant="outline-danger" onClick={toggleRemoveModal}>
                        <FontAwesomeIcon icon={faCancel} className="me-2" />No
                    </Button>
                </Modal.Body>
            </Modal>
        </>
    )
}
